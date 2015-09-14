using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using JMongolModel.Entity;
using JMongolModel.Entity.ConfigDataSetTableAdapters;

namespace JMongolDBHelp
{
    public class AdapterDBHelp
    {
        /// <summary>
        /// 传入强类型数据行DataRow，调用相应的DataSetTableAdapters对数据行进行增加、修改、删除操作
        /// </summary>
        /// <param name="row">强类型数据行DataRow</param>
        /// <returns>更新成功，返回True，否则返回False</returns>
        public static bool Update(DataRow row)
        {
            #region 系统管理ConfigDataSet的三个表（日志、异常、信息）

            //日志
            if (row is ConfigDataSet.tLogRow)
            {
                tLogTableAdapter ad = new tLogTableAdapter();
                return (1 == ad.Update(row));
            }
            //异常
            if (row is ConfigDataSet.tExceptionRow)
            {
                tExceptionTableAdapter ad = new tExceptionTableAdapter();
                return (1 == ad.Update(row));
            }
            //信息
            if (row is ConfigDataSet.tMessageRow)
            {
                tMessageTableAdapter ad = new tMessageTableAdapter();
                return (1 == ad.Update(row));
            }

            #endregion

            else
            {
                return false;
            }
        }
    }
}
