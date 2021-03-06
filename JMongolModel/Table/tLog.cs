﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    /// <summary>
    /// 日志处理，包含数据库中日志表中的所有字段
    /// </summary>
    public struct tLog
    {

        /// <summary>
        /// 名称
        /// </summary>
        public const string Name = "tLog";

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
        /// 登陆、注销、添加、修改、删除、假删、查看
        /// </summary>
        public const string LogType = "LogType";

        /// <summary>
        /// 日志IP：记载操作的IP
        /// </summary>
        public const string LogIP = "LogIP";

        /// <summary>
        /// 源表内容：记载表名、各列内容
        /// </summary>
        public const string SourceContent = "SourceContent";

        /// <summary>
        /// 新表内容：记载表名、各列内容
        /// </summary>
        public const string UpdateContent = "UpdateContent";

        /// <summary>
        /// 模块名称：记载相应操作的模块栏目
        /// </summary>
        public const string ModuleName = "ModuleName";

        /// <summary>
        /// 备注
        /// </summary>
        public const string Remark = "Remark";
    }
}
