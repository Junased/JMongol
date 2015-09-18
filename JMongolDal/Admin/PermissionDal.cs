using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using JMongolModel;
using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolDBHelp;

namespace JMongolDal.Admin
{
    public class PermissionDal : BaseDal
    {
        /// <summary>
        /// 获取权限列表
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="table">待填充的数据集</param>
        /// <returns>返回查询的数据行</returns>
        public int GetPermissionList(string roleID, AdminDataSet.tPermissionDataTable table)
        {
            string strSql = Const.Select + " p." + Const.StarSign + tPermission.Name + " p " + Const.InnerJoin + tRolePermission.Name + " t " + Const.ON + " p." + Const.ID + Const.EqualMark + " t." + tRolePermission.PermissionID + Const.Where + " t." + tRolePermission.RoleID + Const.EqualMark + Const.AT + tRolePermission.RoleID;
            SqlParameter[] para = { new SqlParameter(Const.AT + tRolePermission.RoleID, roleID) };
            return BaseDBHelp.ExecuteSql(strSql, para);
        }
    }
}
