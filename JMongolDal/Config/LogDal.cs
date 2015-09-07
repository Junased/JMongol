using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolModel;
using JMongolDBHelp;

using System.Data;

namespace JMongolDal.Config
{
    public class LogDal : BaseDal
    {
        /// <summary>
        /// 通过传入筛选条件、排序条件,查询数据集
        /// </summary>
        /// <param name="strSQLWhere">筛选条件</param>
        /// <param name="strSQLOrder">排序条件</param>
        /// <param name="start">开始的记录号</param>
        /// <param name="count">要检索的记录数</param>
        /// <param name="table">待填充的数据集</param>
        /// <returns>满足查询条件的数据记录数</returns>
        public int GetDataTable(string strSQLWhere,string strSQLOrder,int start,int count,ConfigDataSet.tLogListDataTable table)
        {
            //string strSQL = " Select OID, CreateID, CreateDate, LogType, LogIP, ModuleName From tLog Where " + base.DeleteFalse;
            string strSQL = Const.Select + Const.ID + Const.Comma + Const.CreateID + Const.Comma + Const.CreateDate + Const.Comma + tLog.LogType + Const.Comma + tLog.LogIP + Const.Comma + tLog.ModuleName + Const.From + tLog.Name + Const.Where + base.DeleteFalse;
            if (strSQLWhere != string.Empty)
            {
                strSQL += Const.AND + strSQLWhere;
            }
            if (strSQLOrder!=string.Empty)
            {
                strSQL += Const.OrderBy + strSQLOrder;
            }

            return QueryDBHelp.QueryDataTable(base.GetSQLCountString(tLog.Name, strSQLWhere), strSQL, start, count, table);
        }

        
        /// <summary>
        /// 初始化日志表的某行
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="strUserIP">登录ip</param>
        /// <returns>日志数据行</returns>
        private ConfigDataSet.tLogRow InitRow(LogType logType,string strUserIP)
        {
            ConfigDataSet.tLogDataTable table = new ConfigDataSet.tLogDataTable();
            ConfigDataSet.tLogRow row = table.NewtLogRow();
            row.LogIP = strUserIP;
            row.LogType = logType.ToString();
            return row;
        }

        /// <summary>
        /// 将表中的某行数据拼接成一个字符串，列与列之间换行
        /// </summary>
        /// <param name="row">要操作的数据行</param>
        /// <param name="version">版本</param>
        /// <returns>当前行所有列拼接成的字符串</returns>
        private string OperateRow(DataRow row,DataRowVersion version)
        {
            string strTmp = string.Empty;
            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                strTmp += row.Table.Columns[i].ColumnName + Const.EqualMark + (row[i, version] ?? string.Empty).ToString() + Const.Separator + Const.BreakLine;
            }
            return strTmp;
        }

        /// <summary>
        /// 记录日志，用于用户登录或者注销
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="userID">当前登录用的ID</param>
        /// <param name="strUserIP">当前登录用的IP</param>
        public void WriteLog(LogType logType,int userID,string strUserIP)
        {
            ConfigDataSet.tLogRow row = this.InitRow(logType, strUserIP);
            row.SourceContent = row.LogType;
            row.UpdateContent = row.LogType;
            row.ModuleName = row.LogType;
            base.Update(row, userID, strUserIP, row.ModuleName);
        }

        /// <summary>
        /// 记录日志，用于查看数据记录
        /// </summary>
        /// <param name="userID">当前登录用户的ID</param>
        /// <param name="strUserIP">当前登录用户的IP</param>
        /// <param name="moduleName">模块名称</param>
        /// <param name="tableName">表名</param>
        /// <param name="oid">行记录oid</param>
        public void WriteLog(int userID,string strUserIP,string moduleName,string tableName,int oid)
        {
            ConfigDataSet.tLogRow row = this.InitRow(LogType.View, strUserIP);
            row.SourceContent = tableName;
            row.UpdateContent = oid.ToString();
            row.ModuleName = moduleName;
            base.Update(row, userID, strUserIP, moduleName);
        }

        /// <summary>
        /// 记录日志，用于查看数据记录
        /// </summary>
        /// <param name="userID">登录用户ID</param>
        /// <param name="userIP">登录用户IP</param>
        /// <param name="moduleName">操作模块</param>
        /// <param name="tableName">物理表名称</param>
        /// <param name="oid">行记录OID</param>
        public void WriteLog<T>(T t, LogType logType, int userID, string userIP, string moduleName)
            where T : DataRow
        {
            if (t is ConfigDataSet.tLogRow || t is ConfigDataSet.tExceptionRow) return;

            if (logType == LogType.LogIn || logType == LogType.LogOut)
                this.WriteLog(logType, userID, userIP);

            string oid = string.Empty;
            if (t.Table.Columns.IndexOf(Const.ID) >= 0)
            {
                oid = (t[Const.ID] ?? Const.Zero).ToString();
            }
            else
            {
                oid = Const.Zero;
            }

            if (logType == LogType.View)
                this.WriteLog(userID, userIP, moduleName, t.Table.TableName, int.Parse(oid));

            ConfigDataSet.tLogRow row = this.InitRow(logType, userIP);

            string sourceContent = Const.TableName + Const.EqualMark + t.Table.TableName + Const.Separator + Const.BreakLine;
            string updateContent = Const.TableName + Const.EqualMark + t.Table.TableName + Const.Separator + Const.BreakLine;
            if (logType == LogType.Update || logType == LogType.LogicDelete)
            {
                if (t.Table.Columns.IndexOf(Const.DeleteFlag) >= 0 && ((bool)t[Const.DeleteFlag]) == true)
                {
                    row.LogType = LogType.LogicDelete.ToString();
                }
                sourceContent += this.OperateRow(t, DataRowVersion.Original);
                updateContent += this.OperateRow(t, DataRowVersion.Current);
            }
            else if (logType == LogType.Add || logType == LogType.Delete)
            {
                sourceContent += this.OperateRow(t, DataRowVersion.Current);
            }

            row.SourceContent = sourceContent;
            row.UpdateContent = updateContent;

            row.ModuleName = moduleName;

            this.Update(row, userID, userIP, moduleName);
        }


    }
}
