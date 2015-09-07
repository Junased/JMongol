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
        #region 数据Update

        public virtual bool Update(DataRow row, int userID, string userIP, string moduleName)
        {
            bool b = false;
            if (row.RowState == DataRowState.Unchanged)
            {
                return b;
            } 
            this.SetRowUpdateValue(row, userID);
            DataRowState state = row.RowState;
            if (state == DataRowState.Added)
            {
                //添加数据
                b = AdapterDBHelp.Update(row);
                //记录日志
                this.WriteLog(row, LogType.Add, userID, userIP, moduleName);
            }
            else if (state == DataRowState.Deleted)
            {
                //记录日志
                this.WriteLog(row, LogType.Delete, userID, userIP, moduleName);
                //添加数据
                b = AdapterDBHelp.Update(row);
            }
            else
            {
                //记录日志
                this.WriteLog(row, LogType.Update, userID, userIP, moduleName);
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
        protected virtual DataRow SetRowUpdateValue(DataRow row, int userID)
        {
            if (row.RowState == DataRowState.Detached || row.RowState == DataRowState.Added)
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
                row[Const.UpdateID] = userID;
            if (row.Table.Columns.IndexOf(Const.UpdateDate) >= 0)
                row[Const.UpdateDate] = DateTime.Now;

            if (row.RowState == DataRowState.Detached)
            {
                DataTable table = row.Table;
                table.Rows.Add(row);
            }
            return row;
        }

        #endregion

        #region 数据Query

        public T GetDataSet<T>(string tableName, string sqlWhere, string sqlOrder, T t) where T : DataSet
        {
            return this.GetDataSet(tableName, sqlWhere, sqlOrder, 0, 0, t);
        }

        public T GetDataSet<T>(string tableName, string sqlWhere, string sqlOrder, int start, int count, T t) where T : DataSet
        {
            return QueryDBHelp.Query(this.GetSQLString(tableName, sqlWhere, sqlOrder, start, count), start, count, tableName, t);
        }

        public int GetDataTable<T>(string tableName, string sqlWhere, string sqlOrder, T t) where T : DataTable
        {
            return this.GetDataTable(tableName, sqlWhere, sqlOrder, 0, 0, t);
        }

        public int GetDataTable<T>(string tableName, string sqlWhere, string sqlOrder, int start, int count, T t) where T : DataTable
        {
            return QueryDBHelp.QueryDataTable(this.GetSQLCountString(tableName, sqlWhere), this.GetSQLString(tableName, sqlWhere, sqlOrder, start, count), start, count, true, t);
        }

        public int GetDataTable<T>(string tableName, string sqlWhere, T t, int userID, string userIP, string moduleName) where T : DataTable
        {
            int recordCount = this.GetDataTable(tableName, sqlWhere, string.Empty, 0, 0, t);
            if (recordCount == 1)
            {
                this.WriteLog(t.Rows[0], LogType.View, userID, userIP, moduleName);
            }
            return recordCount;
        }

        /// <summary>
        /// 通过传入视图名,查询数据集
        /// </summary>
        /// <param name="viewName">表名</param>
        /// <param name="t">待填充的数据集</param>
        /// <returns>满足查询条件的数据记录数</returns>
        public static int GetDataTable(string viewName, DataTable t)
        {
            return QueryDBHelp.QueryDataTable(Const.Select + Const.StarSign + Const.From + viewName, t);
        }

        /// <summary>
        /// 构造数据查询语句
        /// </summary>
        protected virtual string GetSQLString(string tableName, string sqlWhere, string sqlOrder, int start, int count)
        {
            // 定义语句
            string sqlString = "Select * from (Select ROW_NUMBER() OVER (ORDER BY ";
            // 定义排序
            if (sqlOrder == string.Empty)
            {
                sqlString += Const.ID + Const.Asc;
            }
            else
            {
                sqlString += sqlOrder;
            }
            sqlString += ") AS ROWID,*  From ";
            // 定义条件
            sqlString += tableName + Const.Where + this.DeleteFalse;
            if (sqlWhere != string.Empty)
            {
                sqlString += Const.AND + sqlWhere;
            }
            sqlString += " ) t  ";

            // 获取部分数据 
            if (count > 0)
            {
                sqlString += "WHERE t.ROWID BETWEEN " + (start + 1).ToString() + Const.AND + (start + count).ToString();
            }
            return sqlString.Trim();
        }

        /// <summary>
        /// 针对统计分页调用的方法
        /// </summary>
        /// <param name="sql">完整的统计SQL</param>
        /// <param name="sqlOrder">排序条件</param>
        /// <param name="start">开始页码</param>
        /// <param name="count">取得数据</param>
        /// <returns></returns>
        protected string GetCountString(string sql, string sqlOrder, int start, int count)
        {
            string countSql = "Select * from (Select ROW_NUMBER() OVER (ORDER BY " + sqlOrder + ") AS ROWID,*  From (" + sql + ")) t WHERE t.ROWID BETWEEN " + (start + 1).ToString() + Const.AND + (start + count).ToString();
            return countSql;

        }

        protected string GetSQLCountString(string tableName, string sqlWhere)
        {
            string sqlString = Const.Select + Const.Count + Const.LeftBracket + Const.StarSign + Const.RightBracket + Const.From + tableName + Const.Where + this.DeleteFalse;
            if (sqlWhere != string.Empty)
            {
                sqlString += Const.AND + sqlWhere;
            }
            return sqlString.Trim();
        }
        #endregion

        #region  记录日志

        /// <summary>
        /// 系统操作自动记录日志
        /// </summary>
        /// <typeparam name="T">强类型数据行</typeparam>
        /// <param name="t">带操作的强类型数据行</param>
        /// <param name="logType">日志操作类型</param>
        /// <param name="userID">当前操作的用户ID</param>
        public void WriteLog<T>(T t, LogType logType, int userID, string userIP, string moduleName) where T : DataRow
        {
            //当前非实名用户操作，则不记载日志
            if (userID == 0) return;

            LogDal rule = new LogDal();
            //rule.WriteLog(t, logType, userID, userIP, moduleName);
            rule.WriteLog(t, logType, userID, userIP, moduleName);
        }

        #endregion

        #region 常用属性

        /// <summary>
        /// 数据表中删除标记为False的条件
        /// </summary>
        protected string DeleteFalse
        {
            get
            {
                return Const.DeleteFlag + Const.EqualMark + Const.Zero;
            }
        }

        /// <summary>
        /// 数据表中删除标记为True的条件
        /// </summary>
        protected string DeleteTrue
        {
            get
            {
                return Const.DeleteFlag + Const.EqualMark + Const.One;
            }
        }

        #endregion
    }
}
