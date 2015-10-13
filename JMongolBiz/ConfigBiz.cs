using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel;
using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolDal.Config;

namespace JMongolBiz
{
    public class ConfigBiz : BaseBiz
    {
        #region 记录日志，对外提供登录、注销、查看，对于其它日志类型，系统自动记载

        /// <summary>
        /// 记录日志，用于用户登录或者注销
        /// </summary>
        /// <param name="logType">日志类型</param>
        /// <param name="userID">登录用户ID</param>
        /// <param name="userIP">登录用户IP</param>
        public void WriteLog(LogType logType, int userID, string userIP)
        {
            try
            {
                LogDal dal = new LogDal();
                dal.WriteLog(logType, userID, userIP);
            }
            catch (Exception ex)
            {

                BaseBiz.WriteException(ex);
            }
        }

        /// <summary>
        /// 记录日志，用于查看数据记录
        /// </summary>
        /// <param name="userID">登录用户ID</param>
        /// <param name="userIP">登录用户IP</param>
        /// <param name="moduleName">操作模块</param>
        /// <param name="tableName">物理表名称</param>
        /// <param name="id">行记录ID</param>
        public void WriteLog(int userID, string userIP, string moduleName, string tableName, int id)
        {
            try
            {
                LogDal dal = new LogDal();
                dal.WriteLog(userID, userIP, moduleName, tableName, id);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
            }
        }

        /// <summary>
        /// 通过传入筛选条件、排序条件,查询简洁日志列表数据集
        /// </summary>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="sqlOrder">排序条件</param>
        /// <param name="start">开始的记录号</param>
        /// <param name="count">要检索的记录数</param>
        /// <param name="table">待填充的数据集</param>
        /// <returns>满足查询条件的数据记录数</returns>
        public int GetDataTable(string strSQLWhere, string strSQLOrder, int start, int count, ConfigDataSet.tLogListDataTable table)
        {
            try
            {
                LogDal dal = new LogDal();
                return dal.GetDataTable(strSQLWhere, strSQLOrder, start, count, table);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        } 
        #endregion

        #region 查询异常列表

        /// <summary>
        /// 通过传入筛选条件、排序条件,查询数据集
        /// </summary>
        /// <param name="sqlWhere">筛选条件</param>
        /// <param name="sqlOrder">排序条件</param>
        /// <param name="start">开始的记录号</param>
        /// <param name="count">要检索的记录数</param>
        /// <param name="table">待填充的数据集</param>
        /// <returns>满足查询条件的数据记录数</returns>
        public int GetDataTable(string strSQLWhere, string strSQLOrder, int start, int count, ConfigDataSet.tExceptionListDataTable table)
        {
            try
            {
                ExceptionDal dal = new ExceptionDal();
                return dal.GetDataTable(strSQLWhere, strSQLOrder, start, count, table);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        } 
        #endregion

        #region 取得系统信息方法

        /// <summary>
        /// 通过msgID取得对应的信息内容
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <returns>信息内容</returns>
        public static string GetMessage(string strMsgID)
        {
            try
            {
                return MessageDal.GetMessage(strMsgID);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return string.Empty;
            }
        } 
        #endregion
    }
}
