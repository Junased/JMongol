using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using JMongolModel;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace JMongolDBHelp
{
    public class BaseDBHelp
    {
        //获取数据库连接字符串
        public static string con = ConfigurationManager.AppSettings["ConnectionString"];
        private static string key = ConfigurationManager.AppSettings["ConKey"];
        protected static string ConnectionString = SystemEnum.PutByKey(con, key);
        //当前记录未被删除的标志
        protected static string DeleteFalseFilter = Const.Delete + Const.EqualMark + Const.Zero;

        #region 公用方法

        /// <summary>
        /// 获得指定表中指定字段的最大值
        /// </summary>
        /// <param name="fieldName">指定字段</param>
        /// <param name="tableName">指定表</param>
        /// <returns>最大值</returns>
        public static int GetMaxID(string fieldName, string tableName)
        {
            string strSQL = Const.Select + Const.Max + Const.LeftBracket + fieldName + Const.RightBracket + Const.From + tableName;
            strSQL += Const.Where + BaseDBHelp.DeleteFalseFilter;
            object obj = BaseDBHelp.GetSingle(strSQL);
            if ((Object.Equals(obj, null) || (Object.Equals(obj, System.DBNull.Value))))
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }

        }

        /// <summary>
        /// 判断是否存在某值
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns>如果存在，返回true；否则返回false</returns>
        public static bool IsExists(string strSQL, params SqlParameter[] param)
        {
            object obj = BaseDBHelp.GetSingle(strSQL, param);
            if (obj == null || obj == DBNull.Value)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region 执行简单的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的行数
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteSql(string strSQL)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    try
                    {
                        conn.Open();
                        int rows = comm.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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
        /// 执行多条SQL语句，用数据库的事务实现
        /// </summary>
        /// <param name="strSQLList">SQL语句列表</param>
        public static void ExecuteSqlTran(ArrayList strSQLList)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    conn.Open();
                    comm.Connection = conn;
                    SqlTransaction tran = conn.BeginTransaction();
                    comm.Transaction = tran;
                    try
                    {
                        for (int i = 0; i < strSQLList.Count; i++)
                        {
                            string sql = strSQLList[i].ToString();
                            if (sql.Trim().Length > 1)
                            {
                                comm.CommandText = sql;
                                comm.ExecuteNonQuery();
                            }
                        }
                        tran.Commit();
                    }
                    catch (SqlException ex)
                    {
                        tran.Rollback();
                        conn.Close();
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
        /// 执行一条带参数的SQL语句
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="content">参数内容</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strSQL, string content)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    SqlParameter parameter = new SqlParameter("@content", SqlDbType.NText);
                    parameter.Value = content;
                    comm.Parameters.Add(parameter);
                    try
                    {
                        conn.Open();
                        int rows = comm.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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
        /// 向数据库中插入图片
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像的字节流</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    SqlParameter parameter = new SqlParameter("@fs", SqlDbType.Image);
                    parameter.Value = fs;
                    comm.Parameters.Add(parameter);
                    try
                    {
                        conn.Open();
                        int rows = comm.ExecuteNonQuery();
                        return rows;
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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
        /// 执行一条查询语句，返回查询结果的第一行第一列，忽略其他列或行
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <returns>查询结果</returns>
        public static object GetSingle(string strSQL)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    try
                    {
                        conn.Open();
                        object obj = comm.ExecuteScalar();
                        if (Object.Equals(obj, null) || Object.Equals(obj, System.DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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
        /// 执行查询语句，返回SqlDataReader
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader dataReader = comm.ExecuteReader();
                        return dataReader;
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句（含参数），返回影响的记录数
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">要插在SQL语句中的参数</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    try
                    {
                        BaseDBHelp.PrepareCommand(comm, conn, null, strSQL, parameters);
                        int rows = comm.ExecuteNonQuery();
                        comm.Parameters.Clear();
                        return rows;
                    }
                    catch (SqlException ex)
                    {
                        conn.Close();
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
        /// 执行多条SQL语句（含参数），实现数据库事务
        /// </summary>
        /// <param name="sqlStringList">SQL语句的哈希表（key为sql语句，value是该语句的SqlParameter[]）</param>
        public static void ExecuteSqlTran(Hashtable sqlStringList)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction tran = conn.BeginTransaction())
                {
                    SqlCommand comm = new SqlCommand();
                    try
                    {
                        foreach (DictionaryEntry myDE in sqlStringList)
                        {
                            string commText = myDE.Key.ToString();
                            SqlParameter[] commParams = (SqlParameter[])myDE.Value;
                            BaseDBHelp.PrepareCommand(comm, conn, tran, commText, commParams);
                            comm.ExecuteNonQuery();
                            comm.Parameters.Clear();
                            tran.Commit();
                        }
                    }
                    catch (SqlException ex)
                    {
                        tran.Rollback();
                        conn.Open();
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
        /// 执行查询语句，返回一个SqlDataReader对象实例
        /// </summary>
        /// <param name="strSQL">要执行的SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>SqlDataReader对象实例</returns>
        public static SqlDataReader ExecuteReader(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand())
                {
                    try
                    {
                        BaseDBHelp.PrepareCommand(comm, conn, null, strSQL, parameters);
                        SqlDataReader reader = comm.ExecuteReader();
                        comm.Parameters.Clear();
                        return reader;
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
        /// 执行一条计算查询结果的SQL语句（含参数），放回查询结果（object）
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="parameters">参数</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string strSQL, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                using (SqlCommand comm = new SqlCommand(strSQL, conn))
                {
                    try
                    {
                        BaseDBHelp.PrepareCommand(comm, conn, null, strSQL, parameters);
                        object obj = comm.ExecuteScalar();
                        comm.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            conn.Close();
                            return obj;
                        }
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
        /// 设置SqlCommand、SqlConnection、SqlTransaction相关性
        /// </summary>
        /// <param name="cmd">SqlCommand 对象实例</param>
        /// <param name="conn">SqlConnection 对象实例</param>
        /// <param name="tran">SqlTransaction 对象实例</param>
        /// <param name="cmdText">查询语句</param>
        /// <param name="cmdParms">数组参数</param>
        protected static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction tran, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (tran != null)
                cmd.Transaction = tran;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程，返回SqlDataReader对象实例
        /// </summary>
        /// <param name="storeProcedure">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlDataReader对象实例</returns>
        public static SqlDataReader ExecuteStoreProcedure(string storeProcedure, IDataParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                conn.Open();
                SqlDataReader reader;
                using (SqlCommand comm = CreateSQLCommandForStoreProcedureWithReturn(conn, storeProcedure, parameters))
                {
                    try
                    {
                        comm.CommandType = CommandType.StoredProcedure;
                        reader = comm.ExecuteReader();
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }
                    return reader;
                }
            }
        }

        /// <summary>
        /// 执行存储过程，返回影响的行数
        /// </summary>
        /// <param name="storeProcedure">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="rowAffected">影响的行数(默认为0即可)</param>
        /// <returns>影响的行数</returns>
        public static int ExecuteStoreProcedure(string storeProcedure, IDataParameter[] parameters, int rowAffected = 0)
        {
            using (SqlConnection conn = new SqlConnection(BaseDBHelp.ConnectionString))
            {
                try
                {
                    conn.Open();
                    rowAffected = 0;
                    SqlCommand comm = CreateSQLCommendForStoreProcedureWithoutReturn(conn, storeProcedure, parameters);
                    rowAffected = comm.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    rowAffected = 0;
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
                return rowAffected;
            }
        }

        /// <summary>
        /// 为无返回值的存储过程创建SQLCommand实例
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="StoreProcedureName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SQLCommand对象实例</returns>
        protected static SqlCommand CreateSQLCommendForStoreProcedureWithoutReturn(SqlConnection conn, string storeProcedureName, IDataParameter[] parameters)
        {
            SqlCommand comm = new SqlCommand(storeProcedureName, conn);
            comm.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                comm.Parameters.Add(parameter);
            }
            return comm;
        }

        /// <summary>
        /// 为有返回值的存储过程创建SQLCommand实例
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="storeProcedureName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SQLCommand对象实例</returns>
        protected static SqlCommand CreateSQLCommandForStoreProcedureWithReturn(SqlConnection conn, string storeProcedureName, IDataParameter[] parameters)
        {
            SqlCommand comm = CreateSQLCommendForStoreProcedureWithoutReturn(conn, storeProcedureName, parameters);
            comm.Parameters.Add(new SqlParameter("", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return comm;
        }

        #endregion
    }
}
