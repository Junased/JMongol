using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using JMongolModel;

namespace JMongolDBHelp
{
    /// <summary>
    /// 通过SQL语句查询相应的数据集、数据值
    /// </summary>
    public class QueryDBHelp : BaseDBHelp
    {
        #region 查询强类型数据集DataSet

        /// <summary>
        /// 执行查询语句，返回强类型数据集DataSet
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="strSQL">待执行的查询语句</param>
        /// <param name="start">开始位置</param>
        /// <param name="count">要查询的记录数量</param>
        /// <param name="table">待填充的数据表的表名</param>
        /// <param name="t">待装载的数据实例</param>
        /// <returns>强类型数据集DataSet</returns>
        public static T Query<T>(string strSQL, int start, int count, string table, T t) where T : DataSet
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                    if (count == 0)
                    {
                        da.Fill(t, table);
                    }
                    else
                    {
                        da.Fill(t, start, count, table);
                    }
                    return t;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条查询语句，返回DataTale
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <returns>数据DataTable</returns>
        public static DataTable QueryDataTable(string strSQL)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                DataTable dt = new DataTable();
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                    da.Fill(dt);
                    return dt;
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 执行存储过程(无返回值)，返回数据集dataset
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="storeProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="t">待装载的数据实例</param>
        /// <param name="tableName">待填充的数据表的表名</param>
        /// <returns>强类型数据集DataSet</returns>
        public static T QueryDataSet<T>(string storeProcName, IDataParameter[] parameters, T t, string tableName) where T : DataSet
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    try
                    {
                        conn.Open();
                        da.SelectCommand = CreateSQLCommendForStoreProcedureWithoutReturn(conn, storeProcName, parameters);
                        da.Fill(t, tableName);
                        return t;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        #endregion

        #region 查询满足条件的记录数


        /// <summary>
        /// 执行查询语句，返回满足查询条件的记录数
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="strCount">查询记录数</param>
        /// <param name="strSQL">查询语句</param>
        /// <param name="start">查询开始的位置</param>
        /// <param name="count">要查询的记录数</param>
        /// <param name="isPage">是否分页</param>
        /// <param name="t">待装载的数据实例</param>
        /// <returns>满足查询条件的记录数</returns>
        public static int QueryDataTable<T>(string strCount, string strSQL, int start, int count, bool isPage, T t) where T : DataTable
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand(strCount, conn);
                    var obj = comm.ExecuteScalar();

                    SqlDataAdapter da = new SqlDataAdapter(strSQL, conn);
                    if (count == 0 || isPage == true)
                    {
                        da.Fill(t);
                    }
                    else
                    {
                    }
                    return int.Parse(obj.ToString());
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// 执行查询语句，返回满足查询条件的记录数
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="strCount">查询记录数</param>
        /// <param name="strSQL">查询语句</param>
        /// <param name="start">查询开始的位置</param>
        /// <param name="count">要查询的记录数</param>
        /// <param name="t">待装载的数据实例</param>
        /// <returns>满足查询条件的记录数</returns>
        public static int QueryDataTable<T>(string strCount, string strSQL, int start, int count, T t) where T : DataTable
        {
            return QueryDBHelp.QueryDataTable(strCount, strSQL, start, count, false, t);
        }


        /// <summary>
        /// 执行查询语句，并且带有参数，返回满足查询条件的记录数
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="strSQL">查询语句</param>
        /// <param name="t">待装载的数据实例</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回满足实例的记录数</returns>
        public static int QueryDataTable<T>(string strSQL, T t, params SqlParameter[] parameters) where T : DataTable
        {
            using (SqlConnection conn=new SqlConnection(BaseDBHelp.ConnectionString))
            {
                SqlCommand comm = new SqlCommand();
                BaseDBHelp.PrepareCommand(comm, conn, null, strSQL, parameters);
                using (SqlDataAdapter da = new SqlDataAdapter(comm))
                {
                    try
                    {
                        da.Fill(t);
                        comm.Parameters.Clear();
                        return t.Rows.Count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行存储过程，并带有参数，返回满足查询条件的数据记录数
        /// </summary>
        /// <typeparam name="T">待装载的数据类型</typeparam>
        /// <param name="storeProcedureName">存储过程名</param>
        /// <param name="t">待装载的数据实例</param>
        /// <param name="parameters">参数</param>
        /// <returns>返回满足查询条件的数据记录数</returns>
        public static int QueryDataTable<T>(string storeProcedureName, SqlParameter[] parameters,T t) where T : DataTable
        {
            using (SqlConnection conn=new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlDataAdapter da=new SqlDataAdapter())
                {
                    try
                    {
                        conn.Open();
                        da.SelectCommand = CreateSQLCommendForStoreProcedureWithoutReturn(conn, storeProcedureName, parameters);
                        da.Fill(t);
                        return t.Rows.Count;
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        } 
	#endregion
    }
}
