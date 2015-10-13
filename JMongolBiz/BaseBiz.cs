using JMongolDal.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolBiz
{
    public class BaseBiz
    {

        #region  异常
        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex">异常</param>
        public static void WriteException(System.Exception ex)
        {
            BaseBiz.WriteException(ex, 0);
        }

        /// <summary>
        /// 记录异常
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="userID">当前用户ID</param>
        public static void WriteException(System.Exception ex, int userID)
        {
            try
            {
                ExceptionDal rule = new ExceptionDal();
                rule.WriteException(ex, userID);
                throw (ex);  // todo:屏蔽
            }
            catch
            {
                //记录异常时候发生异常，暂时隐藏！
            }
        }
        #endregion

        #region 事务
        //todo
        #endregion

    }
}
