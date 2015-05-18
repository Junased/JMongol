using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Security.Cryptography;
using System.IO;

namespace JMongolModel
{
    public class Common
    {
        public static string PutByKey(string text,string key)
        {
            return "";
        }



        #region 日志类型
        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogType
        {
            /// <summary>
            /// 登录
            /// </summary>
            LogIn,
            /// <summary>
            /// 注销
            /// </summary>
            LogOut,
            /// <summary>
            /// 添加
            /// </summary>
            Add,
            /// <summary>
            /// 更新
            /// </summary>
            Update,
            /// <summary>
            /// 删除
            /// </summary>
            Delete,
            /// <summary>
            /// 假删
            /// </summary>
            LogicDelete,
            /// <summary>
            /// 显示
            /// </summary>
            View
        }
        #endregion
    }
}
