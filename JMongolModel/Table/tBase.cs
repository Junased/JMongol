using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    public class tBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public const string ID = "OID";

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
    }
}
