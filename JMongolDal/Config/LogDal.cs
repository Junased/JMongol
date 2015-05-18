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
            string strSQL = " Select OID, CreateID, CreateDate, LogType, LogIP, ModuleName From tLog Where " + base.DeleteFalse;
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
        private ConfigDataSet.tLogRow InitRow(Common.LogType logType,string strUserIP)
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

        public void WriteLog(Common.LogType logType,int userID,string strUserIP)
        {
            ConfigDataSet.tLogRow row = this.InitRow(logType, strUserIP);
            row.SourceContent = row.LogType;
            row.UpdateContent = row.LogType;
            row.ModuleName = row.LogType;
            
        }

    }
}
