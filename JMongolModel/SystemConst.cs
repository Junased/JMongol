
namespace JMongolModel
{
    /// <summary>
    /// 系统处理中常用到的常量
    /// </summary>
    public class SystemConst
    {
        #region 应用主页模板后的控件默认名称
        public const string CtlContentMain = "ctl00$ContentPlaceHolderMain$";
        public const string MasterContentHolder = "ContentPlaceHolderMain";
        public const string GridView = "GridViewMain";
        public const string GridViewData = "GridViewData";
        public const string DataListData = "DataListData";
        public const string ViewStateData = "ViewStateData";
        public const string CheckboxSelect = "CheckboxSelect";
        public const string RadioButtonSelect = "RadioButtonSelect";
        public const string RowViewData = "RowViewData";
        public const string LabelMessage = "LabelMessage";
        public const string ButtonDelete = "ButtonDelete";

        public const string Column = "Column";
        public const string PanelLabel = "PanelLabel";
        public const string PanelColumn = "PanelColumn";
        #endregion

        #region 分页系列控件
        public const string PanelPager = "PanelPager";
        public const string LabelRecordCount = "LabelRecordCount";
        public const string LabelPageIndex = "LabelPageIndex";
        public const string LabelPageCount = "LabelPageCount";
        public const string LabelPageSize = "LabelPageSize";
        public const string LabelFirst = "LabelFirst";
        public const string LabelPreview = "LabelPreview";
        public const string LabelNext = "LabelNext";
        public const string LabelLast = "LabelLast";
        public const string LinkButtonFirst = "LinkButtonFirst";
        public const string LinkButtonPreview = "LinkButtonPreview";
        public const string LinkButtonNext = "LinkButtonNext";
        public const string LinkButtonLast = "LinkButtonLast";
        public const string TextBoxPageIndex = "TextBoxPageIndex";
        public const string ButtonChangePage = "ButtonChangePage";
        #endregion

        #region 常用的web控件名称
        public const string ControlLabel = "Label";
        public const string ControlTextBox = "TextBox";
        public const string ControlCheckBox = "CheckBox";
        public const string ControlButton = "Button";
        public const string ControlListBox = "ListBox";
        public const string ControlDropDownList = "DropDownList";
        public const string ControlRadioButtonList = "RadioButtonList";
        public const string ControlHiddenField = "HiddenField";
        public const string ControlImage = "Image";
        #endregion

        #region 数据校验常量
        public const string ControlRequiredFieldValidator = "RequiredFieldValidator";
        public const string ControlRegularExpressionValidator = "RegularExpressionValidator";
        public const string ControlRangeValidator = "RangeValidator";
        public const string ControlCompareValidator = "CompareValidator";
        public const string ControlCustomValidator = "CustomValidator";

        public const string TypeCurrency = "货币类型";
        public const string TypeDate = "日期类型";
        public const string TypeDouble = "浮点数类型";
        public const string TypeInteger = "整数类型";
        public const string TypeString = "字符串类型";
        #endregion

        #region 数据集常量
        public const string DataSet = "DataSet";
        public const string DataTable = "DataTable";
        public const string DataRow = "DataRow";
        public const string CountID = "CountID";
        public const string ConKey = "ConKey";

        #endregion

        #region
        public const string DutyInputer = "3"; //录入人员

        #endregion


        #region 日志类型常量
        public const string LogIn = "登录";
        public const string LogOut = "注销";
        public const string Add = "添加";
        public const string Update = "修改";
        public const string Delete = "删除";
        public const string LogicDelete = "假删";
        public const string View = "查看";
        #endregion

        /// <summary>
        /// 树形结构类别
        /// </summary>
        public const string Information = "信息发布";
        public const string Product = "产品发布";

        #region 系统信息常量
        public const string MsgTypeError = "错误";
        public const string MsgTypeWarning = "警告";
        public const string MsgTypeInformation = "提示";
        public const string MsgTypeConfirmation = "确认";
        public const string MsgTypeOther = "其它";
        public const string MsgCodeError = "E";
        public const string MsgCodeWarning = "W";
        public const string MsgCodeInformation = "I";
        public const string MsgCodeConfirmation = "C";
        public const string MsgCodeOther = "O";

        public const string MsgRequired = "I000001";

        public const string MsgRange = "I000002";

        public const string MsgDataTypeCheck = "I000003";

        public const string MsgEqual = "I000006";
        public const string MsgGreaterThan = "I000007";
        public const string MsgGreaterThanEqual = "I000008";
        public const string MsgLessThan = "I000009";
        public const string MsgLessThanEqual = "I000010";
        public const string MsgNotEqual = "I000011";

        public const string MsgSaveSuccess = "I000019";
        public const string MsgSaveFail = "E000005";
        public const string MsgSaveed = "I199999";

        public const string MsgDeleteSuccess = "I000018";
        public const string MsgDeleteFail = "E000004";
        public const string MsgDeleteSystem = "E000011";
        public const string MsgDeleteKey = "E000012";
        public const string MsgDeleteSysKey = "E000013";
        public const string MsgNotLogin = "E000010";
        public const string MsgRepeatName = "E000006";

        public const string MsgSearchSelect = "I000013";
        public const string MsgDeleteSelect = "I000014";
        public const string MsgPWSuccess = "I000020";

        public const string MsgCharValidate = "I000021";
        public const string MsgEmailValidate = "I000022";
        public const string MsgURLValidate = "I000023";
        public const string MsgIPValidate = "I000026";
        public const string MsgRepeatValidate = "I000027";

        //手机、固定电话、邮编、QQ
        public const string MsgMobileValidate = "I000028";
        public const string MsgPhoneValidate = "I000029";
        public const string MsgPostValidate = "I000030";
        public const string MsgQQValidate = "I000031";
        public const string MsgIDValidate = "I000032";
        #endregion

        #region C#数据类型字符串常量
        public const string String = "string";
        public const string Char = "char";
        public const string Byte = "byte";
        public const string ByteArray = "byte[]";
        public const string Integer = "int";
        public const string Number = "decimal";
        public const string Int16 = "int16";
        public const string Int32 = "int32";
        public const string Int64 = "int64";
        public const string UInt16 = "uint16";
        public const string UInt32 = "uint32";
        public const string UInt64 = "uint64";
        public const string Double = "double";
        public const string Decimal = "decimal";
        public const string DateTime = "datetime";
        public const string Boolean = "boolean";
        #endregion

        #region 数据库常量
        /// <summary>
        /// 用户模块，客户类别
        /// </summary>
        public const int ParterType = 1;

        /// <summary>
        /// 用户模块，所在市场
        /// </summary>
        public const int Market = 7;

        /// <summary>
        /// 业务部门
        /// </summary>
        public const int Businesser = 12;

        /// <summary>
        /// 广告图片管理：广告图片类型
        /// </summary>
        public const int ImgType = 25;
        #endregion

        #region 数据库常量
        /// <summary>
        /// 用户模块，用户学历
        /// </summary>
        public const int Education = 1;
        /// <summary>
        /// 用户模块，用户职业
        /// </summary>
        public const int Job = 10;
        /// <summary>
        /// 用户模块，所属行业
        /// </summary>
        public const int Trade = 47;
        /// <summary>
        /// 用户模块，获知本站方式
        /// </summary>
        public const int LearnWays = 59;
        /// <summary>
        /// 用户模块，用户密码提示问题
        /// </summary>
        public const int PromptQuestion = 66;

        /// <summary>
        /// 站内消息，消息类别
        /// </summary>
        public const int NewsType = 73;

        /// <summary>
        /// 站内消息，消息类别
        /// </summary>
        public const int BrandGroup = 77;

        /// <summary>
        /// 功能特性
        /// </summary>
        public const int FeatureID = 80;

        /// <summary>
        /// 适宜人群
        /// </summary>
        public const int HumanID = 84;

        /// <summary>
        /// 产品颜色
        /// </summary>
        public const int ProductColor = 108;

        /// <summary>
        /// 计量单位
        /// </summary>
        public const int ProductSpec = 109;

        /// <summary>
        /// 产品材质
        /// </summary>
        public const int ProductMaterial = 110;

        /// <summary>
        /// 产品风格
        /// </summary>
        public const int ProductStyle = 111;

        /// <summary>
        /// 商品模块：折扣系数
        /// </summary>
        public const int Agio = 131;

        /// <summary>
        /// 网络订单，配送方式
        /// </summary>
        public const int CarryMode = 138;
        /// <summary>
        /// 网络订单，城市类别
        /// </summary>
        public const int CityType = 142;
        /// <summary>
        /// 网络订单，送货时间
        /// </summary>
        public const int ReceiveTime = 145;
        /// <summary>
        /// 发票内容
        /// </summary>
        public const int InvoiceContent = 150;
        /// <summary>
        /// 缺货处理
        /// </summary>
        public const int ProductStockout = 156;

        #endregion



        /// <summary>
        /// 任务类别常量代码
        /// </summary>
        public const int TaskType = 7;

        /// <summary>
        /// 会员爵位
        /// </summary>
        public const int Nobility = 12;

        /// <summary>
        /// 问答类别
        /// </summary>
        public const int QuestionType = 19;

        /// <summary>
        /// 通知类别
        /// </summary>
        public const int NoticeType = 23;



        /// <summary>
        /// 商家类型
        /// </summary>
        public const int ShopType = 25;

        /// <summary>
        /// 购物币兑换方式
        /// </summary>
        public const int Mode = 16;

        /// <summary>
        /// &nbsp;
        /// </summary>
        public const string Blank = "&nbsp;";

        /// <summary>
        /// br
        /// </summary>
        public const string Br = "<br />";

        /// <summary>
        /// 地址栏
        /// </summary>
        public const string UrlReferrer = "地址栏";

        /// <summary>
        /// 系统信息缓存CacheMessage
        /// </summary>
        public const string CacheMessage = "CacheMessage";
        /// <summary>
        /// 黄金广告缓存CacheGoldAD
        /// </summary>
        public const string CacheGoldAD = "CacheGoldAD";

        public const string UserSetting = "UserSetting";
        public const string AdminSetting = "AdminSetting";
        public const string UserLoginNO = "UserLoginNO";
        public const string AdminLoginNO = "AdminLoginNO";
        public const string UserPassword = "UserPassword";
        public const string AdminPassword = "AdminPassword";
        public const string PopedomList = "PopedomList";

        public const string AdminDefault = "AdminDefault";
        public const string SystemAdmin = "SystemAdmin";
        /// <summary>
        /// 购物车中实例化的表
        /// </summary>
        public const string CartKey = "CartKey";
        /// <summary>
        /// 购物车总钱数常量名称
        /// </summary>
        public const string Money = "Money";
        /// <summary>
        /// 购物车总商品数常量名称
        /// </summary>
        public const string Amount = "Amount";

        /// <summary>
        /// 购买团购商品节省金额
        /// </summary>
        public const string JSMoney = "JSMoney";

        /// <summary>
        /// 支付宝合作者身份（partnerID）
        /// </summary>
        public const string PartnerID = "PartnerID";
        /// <summary>
        /// 交易安全校验码（key，32位）
        /// </summary>
        public const string PartnerKey = "PartnerKey";
        /// <summary>
        /// 注册支付宝时的Email
        /// </summary>
        public const string PartnerEmail = "PartnerEmail";
        /// <summary>
        /// 支付宝交易外部接口业务的名称
        /// 及时到账：create_direct_pay_by_user
        /// 实物交易：trade_create_by_buyer
        /// </summary>
        public const string AlipayService = "AlipayService";

        /// <summary>
        /// 快钱参数
        /// </summary>
        public const string BillParam = "BillParam";

        /// <summary>
        /// 财付通支付参数:商户号
        /// </summary>
        public const string Bargainor_ID = "Bargainor_ID";
        /// <summary>
        /// 财付通支付参数：初始密钥
        /// </summary>
        public const string TenPayKey = "TenPayKey";
    }
}
