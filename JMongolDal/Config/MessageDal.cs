using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using JMongolModel;
using JMongolModel.Entity;
using JMongolModel.Table;
using JMongolDBHelp;

namespace JMongolDal.Config
{
    public class MessageDal : BaseDal
    {
        /// <summary>
        /// 通过msgID取得对应的信息内容
        /// </summary>
        /// <param name="msgID">信息ID</param>
        /// <returns>信息内容</returns>
        public static string GetMessage(string msgID)
        {
            string strSQL = Const.Select + Const.Top1 + "MessageContent" + Const.From + "tMessage";
            strSQL += Const.Where + "MessageCode" + Const.EqualMark + Const.SingleQuotes + msgID + Const.SingleQuotes;
            object obj = QueryDBHelp.GetSingle(strSQL);
            return (obj ?? string.Empty).ToString();
        }
    }
}
