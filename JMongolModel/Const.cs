using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JMongolModel
{

    public class Const
    {
        #region 常用单字符号及省略号和不等号
        /// <summary>
        /// 空字符串
        /// </summary>
        public const string Empty = "";
        /// <summary>
        /// 空格
        /// </summary>
        public const string Blank = " ";
        /// <summary>
        /// 换行符号Environment.NewLine
        /// </summary>
        public const string BreakLine = "\r\n";
        /// <summary>
        /// 分隔符符号
        /// </summary>
        public const string Separator = "[~]";
        /// <summary>
        /// 问号?
        /// </summary>
        public const string QuestionMark = "?";
        /// <summary>
        /// 感叹号!
        /// </summary>
        public const string ExcalmatoryMark = "!";
        /// <summary>
        /// @
        /// </summary>
        public const string AT = "@";
        /// <summary>
        /// 井号#
        /// </summary>
        public const string NumberSign = "#";
        /// <summary>
        /// 人民币货币符号￥
        /// </summary>
        public const string RMB = "￥";
        /// <summary>
        /// 美元货币符号$
        /// </summary>
        public const string Dollar = "$";
        /// <summary>
        /// 百分号%
        /// </summary>
        public const string PercentSign = "%";
        /// <summary>
        /// 与运算符&
        /// </summary>
        public const string AndSign = "&";
        /// <summary>
        /// 星号*
        /// </summary>
        public const string StarSign = "*";
        /// <summary>
        /// 左括号(
        /// </summary>
        public const string LeftBracket = "(";
        /// <summary>
        /// 右括号)
        /// </summary>
        public const string RightBracket = ")";
        /// <summary>
        /// 连字符号、减(负)号-
        /// </summary>
        public const string Minus = "-";
        /// <summary>
        /// 连字符号、加(正)号+
        /// </summary>
        public const string Plus = "+";
        /// <summary>
        /// 竖线|
        /// </summary>
        public const string Vertical = "|";
        /// <summary>
        /// 反斜线，多用于物理路径\
        /// </summary>
        public const string Backlash = @"\";
        /// <summary>
        /// 斜线，多用于网址/
        /// </summary>
        public const string Bias = @"/";
        /// <summary>
        /// 点号:
        /// </summary>
        public const string Dot = ".";
        /// <summary>
        /// 冒号:
        /// </summary>
        public const string Colon = ":";
        /// <summary>
        /// 中文冒号：
        /// </summary>
        public const string ChineseColon = "：";
        /// <summary>
        /// 逗号,
        /// </summary>
        public const string Comma = ",";
        /// <summary>
        /// 分号;
        /// </summary>
        public const string Semicolon = ";";
        /// <summary>
        /// 单引号'
        /// </summary>
        public const string SingleQuotes = "'";
        /// <summary>
        /// 省略号...
        /// </summary>
        public const string SuspensionPoint = @"...";
        /// <summary>
        /// 等号=
        /// </summary>
        public const string EqualMark = "=";
        /// <summary>
        /// 大于号>
        /// </summary>
        public const string GreaterThanMark = ">";
        /// <summary>
        /// 大于等于号>=
        /// </summary>
        public const string GreaterThanEqualMark = ">=";
        /// <summary>
        /// 小于号<
        /// </summary>
        public const string LessThanMark = "<";
        /// <summary>
        /// 小于等于号<=
        /// </summary>
        public const string LessEqualMark = "<=";
        /// <summary>
        /// 不等号<>
        /// </summary>
        public const string Inequality = "<>";
        #endregion

        #region 数据库SQL语句常用关键字
        /// <summary>
        /// Insert连接字符串
        /// </summary>
        public const string Insert = " Insert into ";
        /// <summary>
        /// Update连接字符串
        /// </summary>
        public const string Update = " Update ";
        /// <summary>
        /// Set连接字符串
        /// </summary>
        public const string Set = " Set ";
        /// <summary>
        /// Delete连接字符串
        /// </summary>
        public const string Delete = " Delete from ";
        /// <summary>
        /// Select连接字符串
        /// </summary>
        public const string Select = " Select ";
        /// <summary>
        /// From连接字符串
        /// </summary>
        public const string From = " From ";
        /// <summary>
        /// Inner Join连接字符串
        /// </summary>
        public const string InnerJoin = " Inner Join ";
        /// <summary>
        /// Left Join连接字符串
        /// </summary>
        public const string LeftJoin = " Left Join ";
        /// <summary>
        /// Right Join连接字符串
        /// </summary>
        public const string RightJoin = " Right Join ";
        /// <summary>
        /// Where连接字符串
        /// </summary>
        public const string Where = " Where ";
        /// <summary>
        /// Order连接字符串
        /// </summary>
        public const string OrderBy = " Order by ";
        /// <summary>
        /// Desc连接字符串
        /// </summary>
        public const string Desc = " Desc ";
        /// <summary>
        /// Asc连接字符串
        /// </summary>
        public const string Asc = " Asc ";
        /// <summary>
        /// Distinct连接字符串
        /// </summary>
        public const string Distinct = " Distinct ";
        /// <summary>
        /// Top连接字符串
        /// </summary>
        public const string Top = " Top ";
        /// <summary>
        /// Top 1连接字符串
        /// </summary>
        public const string Top1 = " Top 1 ";
        /// <summary>
        /// Count函数字符串
        /// </summary>
        public const string Count = "Count";
        /// <summary>
        /// Max函数字符串
        /// </summary>
        public const string Max = "Max";
        /// <summary>
        /// Min函数字符串
        /// </summary>
        public const string Min = "Min";
        /// <summary>
        /// Sum函数字符串
        /// </summary>
        public const string Sum = "Sum";
        /// <summary>
        /// LIKE连接字符串
        /// </summary>
        public const string LIKE = " Like ";
        /// <summary>
        /// Not连接字符串
        /// </summary>
        public const string Not = " Not ";
        /// <summary>
        /// In连接字符串
        /// </summary>
        public const string In = " In ";
        /// <summary>
        /// AND连接字符串
        /// </summary>
        public const string AND = " AND ";
        /// <summary>
        /// ON连接字符串
        /// </summary>
        public const string ON = " ON ";
        /// <summary>
        /// OR连接字符串
        /// </summary>
        public const string OR = " OR ";
        /// <summary>
        /// Between连接字符串
        /// </summary>
        public const string Between = " Between ";
        /// <summary>
        /// ParamOne连接字符串
        /// </summary>
        public const string ParamOne = " ={0} ";
        /// <summary>
        /// TableName字符串
        /// </summary>
        public const string TableName = "TableName";

        /// <summary>
        /// AS字符串
        /// </summary>
        public const string AS = " AS ";

        #endregion

        #region 数据库表常用字段名称
        /// <summary>
        /// ID字符串
        /// </summary>
        public const string ID = " ID ";
        /// <summary>
        ///SortID字符串
        /// </summary>
        public const string SortID = " SortID ";
        /// <summary>
        /// CreateID字符串
        /// </summary>
        public const string CreateID = " CreateID ";
        /// <summary>
        /// CreateDate字符串
        /// </summary>
        public const string CreateDate = " CreateDate ";
        /// <summary>
        /// UpdateID字符串
        /// </summary>
        public const string UpdateID = " UpdateID ";
        /// <summary>
        /// UpdateDate字符串
        /// </summary>
        public const string UpdateDate = " UpdateDate ";
        /// <summary>
        /// VersionFlag字符串
        /// </summary>
        public const string VersionFlag = " VersionFlag ";
        /// <summary>
        /// DeleteFlag字符串
        /// </summary>
        public const string DeleteFlag = " DeleteFlag ";

        /// <summary>
        /// UserID字符串
        /// </summary>
        public const string UserID = " UserID ";
        /// <summary>
        /// UserName字符串
        /// </summary>
        public const string UserName = " UserName ";
        /// <summary>
        /// MemberName字符串
        /// </summary>
        public const string MemberName = " MemberName ";
        /// <summary>
        /// <summary>
        /// UserIP字符串
        /// </summary>
        public const string UserIP = " UserIP ";
        /// <summary>
        /// DeptID字符串
        /// </summary>
        public const string DeptID = " DeptID ";
        /// <summary>
        /// RoleID字符串
        /// </summary>
        public const string RoleID = " RoleID ";
        /// <summary>
        /// TypeID字符串
        /// </summary>
        public const string TypeID = " TypeID ";
        /// <summary>
        /// PopedomList字符串
        /// </summary>
        public const string PopedomList = " PopedomList ";
        /// <summary>
        /// 换行字符串Char(13) + Char(10)
        /// </summary>
        public const string NewLine = " Char(13) + Char(10) ";
        /// <summary>
        /// Flag字符串
        /// </summary>
        public const string Flag = " Flag ";

        /// <summary>
        /// IsSend字符串
        /// </summary>
        public const string IsSend = " IsSend ";

        /// <summary>
        /// IsEffect字符串
        /// </summary>
        public const string IsEffect = " IsEffect ";

        /// <summary>
        /// True字符串
        /// </summary>
        public const string TrueFlag = " True ";

        /// <summary>
        ///false字符串
        /// </summary>
        public const string FalseFlag = " False ";

        /// <summary>
        ///UserFlag字符串
        /// </summary>
        public const string UserFlag = " UserFlag ";

        #endregion
        
        #region 0到9、-1十一个数字
        /// <summary>
        /// 0
        /// </summary>
        public const string Zero = "0";
        /// <summary>
        /// 1
        /// </summary>
        public const string One = "1";
        /// <summary>
        /// 2
        /// </summary>
        public const string Two = "2";
        /// <summary>
        /// 3
        /// </summary>
        public const string Three = "3";
        /// <summary>
        /// 4
        /// </summary>
        public const string Four = "4";
        /// <summary>
        /// 5
        /// </summary>
        public const string Five = "5";
        /// <summary>
        /// 6
        /// </summary>
        public const string Six = "6";
        /// <summary>
        /// 7
        /// </summary>
        public const string Seven = "7";
        /// <summary>
        /// 8
        /// </summary>
        public const string Eight = "8";
        /// <summary>
        /// 9
        /// </summary>
        public const string Nine = "9";
        /// <summary>
        /// -1
        /// </summary>
        public const string Negative = "-1";
        #endregion

        #region 日期及格式化字符串
        /// <summary>
        /// 0001-01-01
        /// </summary>
        public const string MinDate = "0001-01-01";
        /// <summary>
        /// 9999-12-31
        /// </summary>
        public const string MaxDate = "9999-12-31";
        /// <summary>
        /// 1753-01-01
        /// </summary>
        public const string SmallDate = "1753-01-01";
        /// <summary>
        /// yyyy-MM
        /// </summary>
        public const string YearMonth = "yyyy-MM";
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public const string FormatDate = "yyyy-MM-dd";
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public const string FormatLongDate = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// HH:mm:ss
        /// </summary>
        public const string FormatTime = "HH:mm:ss";
        /// <summary>
        /// 0:00:00
        /// </summary>
        public const string FormatZeroTime = "0:00:00";
        #endregion

        #region 其他常用常量字符串

        /// <summary>
        /// 默认字符串长度，多用于Web'.Config
        /// </summary>
        public const int StringLength = 25;

        /// <summary>
        /// 数字10000
        /// </summary>
        public const string TenThousand = "10000";

        /// <summary>
        /// .html后缀符
        /// </summary>
        public const string HtmlSuffix = @".html";
        /// <summary>
        /// Http前缀符
        /// </summary>
        public const string HttpSuffix = @"http://";
        /// <summary>
        /// JavaScript前缀符
        /// </summary>
        public const string JavaScript = @"javascript:;";

        /// <summary>
        /// 错误页面地址，多用于Web.Config
        /// </summary>
        public const string ErrorPageURL = "ErrorPageURL";

        /// <summary>
        /// 返回地址URL
        /// </summary>
        public const string ReturnURL = "ReturnURL"; 
        #endregion
        
    }
}
