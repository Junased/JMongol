using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolModel;
using JMongolDBHelp;

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
    }
}
