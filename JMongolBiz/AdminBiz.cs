using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel.Table;
using JMongolModel.Entity;
using JMongolDal.Admin;


namespace JMongolBiz
{
    public class AdminBiz
    {
        /// <summary>
        /// 根据角色ID删除角色权限关系
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <returns>删除的记录数</returns>
        public int DeleteByRole(string roleId)
        {
            try
            {
                RolePermissionDal dal = new RolePermissionDal();
                return dal.DeleteByRole(roleId);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }

        /// <summary>
        /// 根据角色ID、权限ID取得角色权限关系数据
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="popedomID">权限ID</param>
        /// <param name="start">开始记录数</param>
        /// <param name="count">页大小</param>
        /// <param name="table">数据表</param>
        /// <returns>返回数据记录数</returns>
        public int GetRolePermissionData(string roleID, string PermissionID, int start, int count, AdminDataSet.tRolePermissionDataTable table)
        {
            try
            {
                RolePermissionDal dal = new RolePermissionDal();
                return dal.GetRolePermissionData(roleID, PermissionID, start, count, table);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }

        /// <summary>
        /// 根据角色ID、取得角色对应权限数据
        /// </summary>
        /// <param name="roleID">角色ID</param>
        /// <param name="table">数据表</param>
        /// <returns>返回数据记录数</returns>
        public int GetPermissionList(string roleID, AdminDataSet.tPermissionDataTable table)
        {
            try
            {
                PermissionDal dal = new PermissionDal();
                return dal.GetPermissionList(roleID, table);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }

        /// <summary>
        /// 通过用户登录账号取得用户信息
        /// </summary>
        /// <param name="loginNO">登录账号</param>
        /// <param name="table">用户表</param>
        /// <param name="userIP">用户登录IP</param>
        /// <param name="moduleName">用户操作模块</param>
        /// <returns>返回用户记录数</returns>
        public int GetUserInfoByLoginNO(string strLoginNO, AdminDataSet.tAdminDataTable table, string userIP, string strModuleName)
        {
            try
            {
                AdminDal dal = new AdminDal();
                return dal.GetUserInfoByLoginNO(strLoginNO, table, userIP, strModuleName);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }

        /// <summary>
        /// 通过用户登录账号和密码，取得单一用户记录
        /// </summary>
        /// <param name="loginNO">登录账号</param>
        /// <param name="passWord">用户密码</param>
        /// <param name="userIP">用户登录IP</param>
        /// <returns>返回用户记录数</returns>
        public int GetUserRecordByLogin(string strLogin, string strPwd, AdminDataSet.tAdminDataTable table, string strUserIP)
        {
            try
            {
                AdminDal dal = new AdminDal();
                return dal.GetUserRecordByLogin(strLogin, strPwd, table, strUserIP);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }

        /// <summary>
        /// 修改登录密码
        /// </summary>
        /// <param name="userID">用户ID</param>
        /// <param name="newpassword">要修改的密码</param>
        /// <returns>返回记录数</returns>
        public int UpdatePassword(string strUserID, string strNewPwd)
        {
            try
            {
                AdminDal dal = new AdminDal();
                return dal.UpdatePassword(strUserID, strNewPwd);
            }
            catch (Exception ex)
            {
                BaseBiz.WriteException(ex);
                return 0;
            }
        }
    }
}
