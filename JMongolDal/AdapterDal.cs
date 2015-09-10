using System;

using JMongolModel;
using System.Data;
using JMongolModel.Entity;

namespace JMongolDal
{
    /// <summary>
    /// 系统自动更新数据方法，提供给Biz的接口方法
    /// </summary>
    public static class AdapterDal
    {
        /// <summary>
        /// 当前操作用户的ID
        /// </summary>
        private static int UserID = 0;

        /// <summary>
        /// 当前操作用户的IP
        /// </summary>
        private static string UserIP = string.Empty;

        /// <summary>
        /// 当前操作的模块的名称
        /// </summary>
        private static string ModuleName = string.Empty;

        /// <summary>
        /// 提供给AdapterBiz的更新数据库的接口方法
        /// </summary>
        /// <typeparam name="T">数据类型，可以DataSet、DataTable、DataRow</typeparam>
        /// <param name="t">待更新的数据集</param>
        /// <param name="userID">操作当前数据的用户ID</param>
        /// <param name="userIP">操作当前数据的用户IP</param>
        /// <param name="moduleName">操作当前数据的模块名称</param>
        /// <returns>影响的行数</returns>
        public static int Update<T>(T t,int userID,string userIP,string moduleName)
        {
            AdapterDal.UserID = userID;
            AdapterDal.UserIP = userIP;
            AdapterDal.ModuleName = moduleName;
            return AdapterDal.Update(t, userID);
        }

        /// <summary>
        /// 提供给AdapterBiz的更新数据库的接口方法
        /// </summary>
        /// <typeparam name="T">数据类型，可以DataSet、DataTable、DataRow</typeparam>
        /// <param name="t">待更新的数据集</param>
        /// <param name="userID">操作当前数据的用户ID</param>
        /// <returns>影响的行数</returns>
        public static int Update<T>(T t, int userID)
        {
            AdapterDal.UserID = userID;
            Type type = t.GetType();
            switch (type.BaseType.Name)
            {
                case SystemConst.DataSet: 
                    return AdapterDal.UpdateDataSet(t as DataSet);
                case SystemConst.DataTable: 
                    return AdapterDal.UpdateDataTable(t as DataTable);
                case SystemConst.DataRow: 
                    return AdapterDal.UpdateDataRow(t as DataRow);
                default:
                    return 0;
            }
        }
        /// <summary>
        /// 遍历DataSet中所有的表，调用AdapterRU.UpdateDataTable方法更新
        /// </summary>
        /// <typeparam name="T">强类型数据集DataSet</typeparam>
        /// <param name="t">待更新的数据集</param>
        /// <returns>影响的行数</returns>
        public static int UpdateDataSet<T>(T t) where T : DataSet
        {
            int result = 0;
            foreach (DataTable table in t.Tables)
            {
                result += UpdateDataTable(table);
            }
            return result;
        }

        /// <summary>
        /// 遍历DataTable中所有的行，调用AdapterRU.UpdateDataRow方法更新
        /// </summary>
        /// <typeparam name="T">强类型数据集DataTable</typeparam>
        /// <param name="t">待更新的数据集</param>
        /// <returns>影响的行数</returns>
        public static int UpdateDataTable<T>(T t) where T : DataTable
        {
            int result = 0;
            foreach (DataRow row in t.Rows)
            {
                result += AdapterDal.UpdateDataRow(row);
            }
            return result;
        }

        /// <summary>
        /// 通过传入的强类型DataRow，动态映射到该处理的类，更新数据行
        /// </summary>
        /// <typeparam name="T">强类型数据集DataRow</typeparam>
        /// <param name="t">待更新的数据集</param>
        /// <returns>影响的行数</returns>
        public static int UpdateDataRow<T>(T t) where T : DataRow
        {
            if (t.RowState == DataRowState.Unchanged)
            {
                return 0;
            }

            BaseDal baseDal = null;
            bool result = true;

            #region 系统管理 ConfigDataSet 3个表
            if (t is ConfigDataSet.tExceptionRow)
            {
                baseDal = new Config.ExceptionDal();
            }
            else if (t is ConfigDataSet.tMessageRow)
            {
                baseDal = new Config.MessageDal();
            }
            else if (t is ConfigDataSet.tLogRow)
            {
                baseDal = new Config.LogDal();
            }
            #endregion

            /***********************************************************
            * 增加新的强类型数据行
            ***********************************************************/

            result = baseDal.Update(t, AdapterDal.UserID, AdapterDal.UserIP, AdapterDal.ModuleName);
            return (result == true) ? 1 : 0;

        }
    }
}
