using System;
namespace JMongolModel.Table
{
    /// <summary>
    /// 管理员，包含数据库中管理员表的所有字段
    /// </summary>
    public struct tAdmin
    {
        /// <summary>
        /// 名称
        /// </summary>
        public const string Name = "tAdmin";

        /// <summary>
        /// 主键ID
        /// </summary>
        public const string ID = "ID";

        /// <summary>
        /// 排序ID
        /// </summary>
        public const string SortID = "SortID";

        /// <summary>
        /// 创建人ID
        /// </summary>
        public const string CreateID = "CreateID";

        /// <summary>
        /// 创建时间
        /// </summary>
        public const string CreateDate = "CreateDate";

        /// <summary>
        /// 更新人ID
        /// </summary>
        public const string UpdateID = "UpdateID";

        /// <summary>
        /// 更新时间
        /// </summary>
        public const string UpdateDate = "UpdateDate";

        /// <summary>
        /// 是否删除
        /// </summary>
        public const string DeleteFlag = "DeleteFlag";

        /// <summary>
        /// 版本号
        /// </summary>
        public const string VersionFlag = "VersionFlag";

        /// <summary>
        /// 登录账号
        /// </summary>
        public const string LoginNO = "LoginNO";

        /// <summary>
        /// 登录密码实际长度6-20个
        /// </summary>
        public const string Password = "Password";

        /// <summary>
        /// 用户的真实姓名
        /// </summary>
        public const string UserName = "UserName";

        /// <summary>
        /// 联系电话
        /// </summary>
        public const string LinkTel = "LinkTel";

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public const string Email = "Email";

        /// <summary>
        /// QQ
        /// </summary>
        public const string QQ = "QQ";

        /// <summary>
        /// 对应角色表OID
        /// </summary>
        public const string RoleID = "RoleID";

        /// <summary>
        /// 对应部门表OID
        /// </summary>
        public const string DeptmentID = "DeptmentID";

        /// <summary>
        /// 对应职位表OID
        /// </summary>
        public const string DutyID = "DutyID";

        /// <summary>
        /// 密码提示问题
        /// </summary>
        public const string PromptQuestion = "PromptQuestion";

        /// <summary>
        /// 密码找回答案
        /// </summary>
        public const string ReturnAnswer = "ReturnAnswer";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "Remark";

    }
}

