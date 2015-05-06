using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

using JMongolDBHelp;
using JMongolModel;

namespace JMongolDal
{
    public class BaseDal
    {
        #region 常用属性

        /// <summary>
        /// 数据表中删除标记为false的条件
        /// </summary>
        protected string DeleteFalse
        {
            get
            {
                return Const.Delete + Const.EqualMark + Const.Zero;
            }
        }

        /// <summary>
        /// 数据表中删除标记为true的条件
        /// </summary>
        protected string DeleteTrue
        {
            get
            {
                return Const.Delete + Const.EqualMark + Const.One;
            }
        } 
        #endregion
    }
}
