using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolModel;
using JMongolDBHelp;
using System.Data.SqlClient;
using JMongolDal.Config;

namespace JMongolDal.Admin
{
    public class AdminDal : BaseDal
    {
        /// <summary>
        /// 添加用户，一般用于注册
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="userID">用户ID</param>
        /// <param name="userIP">用户IP</param>
        /// <param name="moduleName">模块名称</param>
        /// <returns>返回是否添加成功</returns>
        public override bool Update(DataRow row, int userID, string userIP, string moduleName)
        {
            AdminDataSet.tAdminRow r = (AdminDataSet.tAdminRow)row;
            //判断该账号是否存在
            if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Detached)
            {
                string strSql = Const.Select + Const.One + Const.From + tAdmin.Name + Const.Where + base.DeleteFalse + Const.AND + tAdmin.LoginNO + Const.EqualMark + Const.AT + Const.SingleQuotes + r.LoginNO + Const.SingleQuotes;
                bool flag = BaseDBHelp.IsExists(strSql);
                if (flag == true)
                {
                    return false;
                }
            }
            return base.Update(r, userID, userIP, moduleName);
        }

        /// <summary>
        /// 根据用户名获取用户信息
        /// </summary>
        /// <param name="strLoginNO">用户名</param>
        /// <param name="table">待填充的数据集</param>
        /// <param name="userIP">用户IP</param>
        /// <param name="strModuleName">模块名称</param>
        /// <returns>返回数据结果</returns>
        public int GetUserInfoByLoginNO(string strLoginNO, AdminDataSet.tAdminDataTable table, string userIP, string strModuleName)
        {
            string strSql = Const.Select + Const.StarSign + Const.From + tAdmin.Name + Const.Where + base.DeleteFalse + Const.AND + tAdmin.LoginNO + Const.EqualMark + Const.AT + tAdmin.LoginNO;
            SqlParameter para = new SqlParameter(Const.AT + tAdmin.LoginNO, strLoginNO);
            int count = QueryDBHelp.QueryDataTable(strSql, table, para);
            if (count == 1)
            {
                LogDal logDal = new LogDal();
                logDal.WriteLog(0, userIP, strModuleName, tAdmin.Name, Convert.ToInt32(table.Rows[0][Const.ID]));
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strLogin"></param>
        /// <param name="strPwd"></param>
        /// <param name="table"></param>
        /// <param name="userIP"></param>
        /// <returns></returns>
        public int GetUserRecordByLogin(string strLogin, string strPwd, AdminDataSet.tAdminDataTable table, string userIP)
        {
            string strSql = Const.Select + Const.StarSign + Const.From + tAdmin.Name + Const.Where + base.DeleteFalse + Const.AND + tAdmin.LoginNO + Const.EqualMark + Const.AT + tAdmin.LoginNO + Const.AND + tAdmin.Password + Const.EqualMark + Const.AT + tAdmin.Password;
            SqlParameter[] para = { new SqlParameter(Const.AT + tAdmin.LoginNO, strLogin), 
                                      new SqlParameter(Const.AT + tAdmin.Password, strPwd) };
            int count = QueryDBHelp.QueryDataTable(strSql, table, para);
            if (count == 1)
            {
                LogDal logDal = new LogDal();
                logDal.WriteLog(LogType.LogIn, Convert.ToInt32(table.Rows[0][Const.ID]), userIP);
            }
            return count;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="newPassword">新密码</param>
        /// <returns>返回结果</returns>
        public int UpdatePassword(string userID, string newPassword)
        {
            string strSql = Const.Update + tAdmin.Name + Const.Set + tAdmin.Password + Const.EqualMark + Const.AT + tAdmin.Password + Const.Where + base.DeleteFalse + Const.AND + tAdmin.ID + Const.EqualMark + Const.AT + tAdmin.ID;
            SqlParameter[] para = { new SqlParameter(Const.AT + tAdmin.ID, userID) ,
                                  new SqlParameter(Const.AT+tAdmin.Password,newPassword)};
            return BaseDBHelp.ExecuteSql(strSql, para);
        }
    }
}
