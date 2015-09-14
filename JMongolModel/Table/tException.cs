using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    /// <summary>
    /// 异常处理，包含数据库中异常表中的所有字段
    /// </summary>
    public struct tException
    {
        /// <summary>
        /// 名称
        /// </summary>
        public const string Name = "tException";

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
        /// 异常标题
        /// </summary>
        public const string ExceptionTitle = "ExceptionTitle";

        /// <summary>
        /// 指示异常的发生点
        /// </summary>
        public const string ExceptionSource = "ExceptionSource";

        /// <summary>
        /// 异常的相信信息
        /// </summary>
        public const string ExceptionContent = "ExceptionContent";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "Remark";
    }
}
