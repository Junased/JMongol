using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using JMongolDBHelp;
using JMongolModel;
using JMongolDal.Config;

namespace JMongolDal
{
    public class BaseDal
    {

        #region 数据update

        /// <summary>
        /// 记录日志，添加数据
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="userID">当前登录用的ID</param>
        /// <param name="strUserIP">当前登录用户的IP</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns>返回是否成功更新数据</returns>
        public virtual bool Update(DataRow row,int userID,string strUserIP,string moduleName)
        {
            bool b = false;
            DataRowState state = row.RowState;
            if (state == DataRowState.Unchanged)
            { 
                return b;
            }
            this.SetRowUpdateValue(row, userID);
            if (state == DataRowState.Added)
            {
                //添加数据
                b = AdapterDBHelp.Update(row);
                //记录日志
                this.WriteLog(row, Common.LogType.Add, userID, strUserIP, moduleName);
            }
            else if (state == DataRowState.Deleted)
            {
                //记录日志
                this.WriteLog(row, Common.LogType.Delete, userID, strUserIP, moduleName);
                //添加数据
                b = AdapterDBHelp.Update(row);
            }
            else
            {
                //记录日志
                this.WriteLog(row, Common.LogType.Update, userID, strUserIP, moduleName);
                //添加数据
                b = AdapterDBHelp.Update(row);
            }
            row.AcceptChanges();
            return b;
        }

        /// <summary>
        /// 设置数据行中默认字段：
        /// SortID
        /// CreateID
        /// CreateDate
        /// UpdateID
        /// UpdateDate
        /// DeleteFlag
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="userID">用户ID</param>
        /// <returns>返回更改过的数据行</returns>
        protected virtual DataRow SetRowUpdateValue(DataRow row,int userID)
        {
            DataRowState state = row.RowState;
            if (state == DataRowState.Detached || state == DataRowState.Added)
            {
                if (row.Table.Columns.IndexOf(Const.SortID) >= 0)
                {
                    if (row[Const.SortID] == DBNull.Value || row[Const.SortID] == null)
                        row[Const.SortID] = 0;
                }

                if (row.Table.Columns.IndexOf(Const.CreateID) >= 0)
                    row[Const.CreateID] = userID;

                if (row.Table.Columns.IndexOf(Const.CreateDate) >= 0)
                    row[Const.CreateDate] = DateTime.Now;

                if (row.Table.Columns.IndexOf(Const.DeleteFlag) >= 0)
                    row[Const.DeleteFlag] = false;
            }
            if (row.Table.Columns.IndexOf(Const.UpdateID) >= 0)
            {
                row[Const.UpdateID] = userID; 
            }
            if (row.Table.Columns.IndexOf(Const.UpdateDate) >= 0)
            { 
                row[Const.UpdateDate] = DateTime.Now;
            }

            if (state == DataRowState.Detached)
            {
                DataTable table = row.Table;
                table.Rows.Add(row);
            }
            return row;
        }
        #endregion


        public virtual string GetSQLString(string strTabelName,string strSQLWhere,string strSQLOrder,int start,int count)
        {
            //定义语句
            string strSQL = Const.Select + Const.StarSign + Const.From + Const.LeftBracket + Const.Select + "ROW_NUMBER() OVER" + Const.LeftBracket + Const.OrderBy;
            //定义排序
            if (strSQLOrder == string.Empty)
            {
                strSQL += Const.ID + Const.Asc;
            }
            else
            {
                strSQL += strSQLOrder;
            }
            strSQLOrder += Const.RightBracket + Const.AS + " ROWID " + Const.Comma + Const.StarSign + Const.From;

            //定义条件
            strSQL += strTabelName + Const.Where + this.DeleteFalse;
            if (strSQLWhere != string.Empty)
            {
                strSQL += Const.AND + strSQLWhere;
            }
            return "";
        }


        /// <summary>
        /// 获取特定表中的符合筛选条件的条目个数
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="strSQLWhere">筛选条件</param>
        /// <returns></returns>
        protected string GetSQLCountString(string tableName, string strSQLWhere)
        {
            string sqlString = Const.Select + Const.Count + Const.LeftBracket + Const.StarSign + Const.RightBracket + Const.From + tableName + Const.Where + this.DeleteFalse;
            if (strSQLWhere != string.Empty)
            {
                sqlString += Const.AND + strSQLWhere;
            }
            return sqlString.Trim();
        }


        #region 记录日志
        /// <summary>
        /// 系统操作自动记录日志
        /// </summary>
        /// <typeparam name="T">强类型数据行</typeparam>
        /// <param name="t">带操作的强类型数据行</param>
        /// <param name="logType">日志操作类型</param>
        /// <param name="userID">当前操作的用户ID</param>
        public void WriteLog<T>(T t, Common.LogType logType, int userID, string userIP, string moduleName) where T : DataRow
        {
            //当前非实名用户操作，则不记载日志
            if (userID == 0) return;

            LogDal rule = new LogDal();
            rule.WriteLog(t, logType, userID, userIP, moduleName);
        }
        #endregion

        #region 常用属性

        /// <summary>
        /// 数据表中删除标记为false的条件
        /// </summary>
        protected string DeleteFalse
        {
            get
            {
                return Const.Delete + Const.EqualMark + Const.Zero;
            }
        }

        /// <summary>
        /// 数据表中删除标记为true的条件
        /// </summary>
        protected string DeleteTrue
        {
            get
            {
                return Const.Delete + Const.EqualMark + Const.One;
            }
        } 
        #endregion
    }
}
