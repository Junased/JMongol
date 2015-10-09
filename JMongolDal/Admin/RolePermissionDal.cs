using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolDBHelp;
using JMongolModel;
using JMongolModel.Entity;
using JMongolModel.Table;

namespace JMongolDal.Admin
{
    public class RolePermissionDal
    {
        /// <summary>
        /// 根据角色ID、权限ID取得角色权限关系数据
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="PermissionID">权限ID</param>
        /// <param name="start">开始记录数</param>
        /// <param name="count">页大小</param>
        /// <param name="table">数据表</param>
        /// <returns>返回数据记录数</returns>
        public int GetRolePermissionData(string roleID, string PermissionID, int start, int count, AdminDataSet.tRolePermissionDataTable table)
        {
            string sql, sqlCount, sqlString;
            sql = string.Empty;
            sqlCount = "Select Count(t.OID) ";
            sqlString = " Select t.*, r.RoleName, p.PermissionName ";
            sql += " From tRolePermission t inner join tRole r on t.RoleID = r.OID ";
            sql += " inner join tPermission p on t.PermissionID = p.OID ";
            sql += " where t.DeleteFlag = 0 and r.DeleteFlag = 0 and p.DeleteFlag = 0 ";
            if (roleID != string.Empty)
                sql += Const.AND + "t.RoleID=" + roleID;
            if (PermissionID != string.Empty)
                sql += Const.AND + "t.PermissionID=" + PermissionID;
            sqlString += sql + " Order by t.SortID, t.RoleID, t.PermissionID ";

            return QueryDBHelp.QueryDataTable(sqlCount + sql, sqlString, start, count, table);
        }

        /// <summary>
        /// 根据角色ID删除角色权限关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>删除的记录数</returns>
        public int DeleteByRole(string roleID)
        {
            if (roleID == string.Empty) return 0;
            string sql = Const.Delete + tRolePermission.Name + Const.Where + tRolePermission.RoleID + Const.EqualMark + roleID;
            return BaseDBHelp.ExecuteSql(sql);
        }
    }
}
