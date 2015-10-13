using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    public struct tPermission
    {
        public const string Name = "tPermission";

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
        /// 权限代码：对应各个栏目代码
        /// </summary>
        public const string PermissionCode = "PermissionCode";

        /// <summary>Popedom
        /// 权限名称：可以根据具体模块来设定名称
        /// </summary>
        public const string PermissionName = "PermissionName";

        /// <summary>
        /// 权限说明：权限说明信息
        /// </summary>
        public const string PermissionDesc = "PermissionDesc";

        /// <summary>
        /// 选择：是或者否，默认为否，指没有此项权限
        /// </summary>
        public const string FlagSelect = "FlagSelect";

        /// <summary>
        /// 插入：是或者否，默认为否，指没有此项权限
        /// </summary>
        public const string FlagInsert = "FlagInsert";

        /// <summary>
        /// 更新：是或者否，默认为否，指没有此项权限
        /// </summary>
        public const string FlagUpdate = "FlagUpdate";

        /// <summary>
        /// 删除：是或者否，默认为否，指没有此项权限
        /// </summary>
        public const string FlagDelete = "FlagDelete";

        /// <summary>
        /// 特殊权限：根据数值来定，默认为0，指没有此项权限
        /// </summary>
        public const string SpecialFlag = "SpecialFlag";

        /// <summary>
        /// 优先级：默认为0，数字越大，优先级越高
        /// </summary>
        public const string PRI = "PRI";

        /// <summary>
        /// 权限标志：是或者否，是指系统权限，否指用户权限；默认为否
        /// </summary>
        public const string PermissionFlag = "PermissionFlag";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "Remark";

    }
}
