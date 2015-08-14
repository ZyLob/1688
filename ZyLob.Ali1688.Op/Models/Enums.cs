using ZyLob.Ali1688.Op.Common;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 阿里相册类型
    /// </summary>
    public enum AliAlbumType
    {
        /// <summary>
        /// 自定义相册
        /// </summary>
        [EnumDescription("自定义相册", "CUSTOM")]
        Custom = 0,
        /// <summary>
        /// 我的相册
        /// </summary>
        [EnumDescription("我的相册", "MY")]
        My = 1,
        /// <summary>
        /// 下架相册
        /// </summary>
        [EnumDescription("下架相册", "OFF")]
        Off = 2
    }

    /// <summary>
    /// 阿里相册访问权限
    /// </summary>
    public enum AliAlbumAuthority
    {
        /// <summary>
        /// 不公开的相册
        /// </summary>
        PrivateAlbum = 0,

        /// <summary>
        /// 公开的相册
        /// </summary>
        PublicAlbum = 1,

        /// <summary>
        /// 密码访问的相册
        /// </summary>
        PasswordAlbum = 2
    }

    /// <summary>
    /// 应用购买订单服务状态
    /// </summary>
    public enum AliApplyOrderState
    {
        /// <summary>
        /// 服务前
        /// </summary>
        [EnumDescription("服务前")]
        B = 0,
        /// <summary>
        /// 服务中
        /// </summary>
        [EnumDescription("服务中")]
        S = 1,
        /// <summary>
        /// 挂起
        /// </summary>
        [EnumDescription("挂起")]
        P = 2,
        /// <summary>
        /// 关闭
        /// </summary>
        [EnumDescription("关闭")]
        E = 3,
        /// <summary>
        /// 作废
        /// </summary>
        [EnumDescription("作废")]
        C = 4,

    }
    /// <summary>
    /// 应用购买订单详细状态
    /// </summary>
    public enum AliApplyDetailOrderState
    {
        /// <summary>
        /// 审核通过
        /// </summary>
        [EnumDescription("审核通过", "audit_pass")]
        AuditPass = 0,
        /// <summary>
        /// 待发布
        /// </summary>
        [EnumDescription("待发布", "issue_ready")]
        IssueReady = 1,
        /// <summary>
        /// 服务中 
        /// </summary>
        [EnumDescription("服务中", "service")]
        Service = 2,
        /// <summary>
        /// 挂
        /// </summary>
        [EnumDescription("挂", "suspend")]
        Suspend = 3,
        /// <summary>
        /// 欠费挂起
        /// </summary>
        [EnumDescription("欠费挂起", "arrear_suspend")]
        ArrearSuspend = 4,
        /// <summary>
        /// 关闭
        /// </summary>
        [EnumDescription("关闭", "closed")]
        Closed = 5,
        /// <summary>
        /// 作废
        /// </summary>
        [EnumDescription("作废", "cancel")]
        Cancel = 6,
    }
    /// <summary>
    /// 阿里会员状态
    /// </summary>
    public enum AliMemberStatus
    {
        /// <summary>
        /// 有效
        /// </summary>
        Enabled = 0,
        /// <summary>
        /// 无效
        /// </summary>
        Disabled = 1
    }
    /// <summary>
    ///会员开启或关闭自定义分类
    /// </summary>
    public enum OfferGroupSwitchType
    {
        /// <summary>
        /// On对应设置显示标记的开启，即：显示
        /// </summary>
        On,
        /// <summary>
        /// Off对应显示标记的关闭，即：不显示
        /// </summary>
        Off
    }
}
