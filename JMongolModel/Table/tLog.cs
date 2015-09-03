using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel.Table
{
    public class tLog : tBase
    {

        /// <summary>
        /// 名称
        /// </summary>
        public const string Name = "tLog";        

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
