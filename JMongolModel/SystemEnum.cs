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
    
    public class SystemEnum
    {
        public static string PutByKey(string text, string key)
        {
            return "";
        }

    }

    /// <summary>
    /// 框架中将会用到的所有枚举汇总
    /// </summary>
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

    #region 树形结构
    /// <summary>
    /// 树形结构类别
    /// </summary>
    public enum TreeStructFlag
    {
        /// <summary>
        /// 信息发布类型
        /// </summary>
        Information = 1,
        /// <summary>
        /// 产品发布类型
        /// </summary>
        Product = 2
    }

    /// <summary>
    /// 树形结构名称
    /// </summary>
    public enum TreeStructName
    {
        /// <summary>
        /// 信息发布
        /// </summary>
        信息发布,

        /// <summary>
        /// 产品发布
        /// </summary>
        产品发布
    }
    #endregion

    #region 用户标志
    public enum UserFlag
    {
        /// <summary>
        /// 管理员
        /// </summary>
        管理员,

        /// <summary>
        /// 顾客会员
        /// </summary>
        顾客会员,
    }
    #endregion

    #region
    #endregion

    #region BBS 社区
    public enum Integral
    {
        /// <summary>
        /// 登陆次数：对系统的关注度
        /// </summary>
        LoginCount,
        /// <summary>
        /// 财富分数：对系统的贡献
        /// </summary>
        FortuneCount,
        /// <summary>
        /// 社区分数：在系统中停留时间的长短
        /// </summary>
        CommunityCount,
        /// <summary>
        /// 名誉分数：在系统中得到的奖励参数
        /// </summary>
        HonorCount,
        /// <summary>
        /// 技能分数：在系统中的能力的体现
        /// </summary>
        SkillCount
    }

    /// <summary>
    /// 论坛主题的状态
    /// </summary>
    public enum BBSStateFlag
    {
        /// <summary>
        /// 版块置顶
        /// </summary>
        Top,
        /// <summary>
        /// 区置顶
        /// </summary>
        AreaTop,
        /// <summary>
        /// 总置顶
        /// </summary>
        All,
        /// <summary>
        /// 精华主题
        /// </summary>
        OK
    }
    #endregion
}
