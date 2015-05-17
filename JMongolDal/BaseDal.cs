using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using JMongolDBHelp;
using JMongolModel;

namespace JMongolDal
{
    public class BaseDal
    {

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
