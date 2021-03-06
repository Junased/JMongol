﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    /// <summary>
    /// 信息处理，包含数据库中信息表的所有字段
    /// </summary>
    public struct tMessage
    {
        /// <summary>
        /// 名称
        /// </summary>
        public const string Name = "tMessage";

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
        /// 中文、English
        /// </summary>
        public const string LanguageType = "LanguageType";

        /// <summary>
        /// 信息类别：错误、警告、提示、确认、其它
        /// </summary>
        public const string MessageType = "MessageType";

        /// <summary>
        /// 信息代码：标识信息的代码(由E、W、I、C、O和6位数字编码组成)，E、W、I、C、O分别表示错误、警告、提示、确认、其它
        /// </summary>
        public const string MessageCode = "MessageCode";

        /// <summary>
        /// 信息内容：详细信息
        /// </summary>
        public const string MessageContent = "MessageContent";

        /// <summary>
        /// 信息标志：是或否，是指系统信息，否则指用户信息；默认为是
        /// </summary>
        public const string MessageFlag = "MessageFlag";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "Remark";
    }
}
