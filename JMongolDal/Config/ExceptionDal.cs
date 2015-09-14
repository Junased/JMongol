using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel;
using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolDBHelp;

namespace JMongolDal.Config
{
    public class ExceptionDal : BaseDal
    {
        /// <summary>
        /// 通过传入筛选条件、排序条件,查询数据集
        /// </summary>
        /// <param name="strWhere">筛选条件</param>
        /// <param name="strOrder">排序条件</param>
        /// <param name="start">开始的记录号</param>
        /// <param name="count">要检索的记录数</param>
        /// <param name="table">待填充的数据集</param>
        /// <returns>满足查询条件的数据记录数</returns>
        public int GetDataTable(string strWhere, string strOrder, int start, int count, ConfigDataSet.tExceptionListDataTable table)
        {
            string sqlString = Const.Select + Const.ID + Const.Comma + Const.CreateID + Const.Comma + Const.CreateDate + Const.Comma + tException.ExceptionTitle + Const.Comma + tException.ExceptionSource + Const.From + tException.Name + Const.Where + base.DeleteFalse;
            //string sqlString = " Select OID, CreateID, CreateDate, ExceptionTitle, ExceptionSource From tException Where " + base.DeleteFalse;
            if (strWhere != string.Empty)
            {
                sqlString += Const.AND + strWhere;
            }
            if (strOrder != string.Empty)
            {
                sqlString += Const.OrderBy + strOrder;
            }
            return QueryDBHelp.QueryDataTable(base.GetSQLCountString(tException.Name, strWhere), sqlString, start, count, table);
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="userID">当前用户ID</param>
        public void WriteException(System.Exception ex, int userID)
        {
            ConfigDataSet.tExceptionDataTable table = new ConfigDataSet.tExceptionDataTable();
            ConfigDataSet.tExceptionRow row = table.NewtExceptionRow();
            row.ExceptionTitle = ex.Message;
            row.ExceptionSource = ex.Source;
            row.ExceptionContent = ex.StackTrace + Const.BreakLine + ex.InnerException;
            base.Update(row, userID, string.Empty, string.Empty);
        }
    }
}
