using System;
using Newtonsoft.Json;
using ZyLob.Ali1688.Op.Common;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 商品所属类型
    /// </summary>
    public enum OfferType
    {
        /// <summary>
        /// 供应信息
        /// </summary>
        SALE,
        /// <summary>
        /// 所有产品信息
        /// </summary>
        ALL,
        /// <summary>
        /// 求购信息
        /// </summary>
        BUY
    }
    /// <summary>
    /// 供品状态
    /// </summary>
    public enum OfferStatus
    {
        /// <summary>
        /// 所有上线
        /// </summary>
        Tdb,
        /// <summary>
        /// 销售中
        /// </summary>
        Published,
        /// <summary>
        /// 删除
        /// </summary>
        Deleted,
        /// <summary>
        /// 待审
        /// </summary>
        New
    }
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

    /// <summary>
    /// 卖家评价状态
    /// </summary>
    public enum EvaluateStatus
    {
        未评论 = 5,
        已评论 = 4,
        不需要评论 = 6
    }

    /// <summary>
    ///  cod状态
    /// </summary>
    public enum CodStatus
    {
        初始值 = 0,
        接单 = 20,
        不接单 = -20,
        接单超时 = 2,
        揽收成功 = 30,
        揽收失败 = -30,
        揽收超时 = 3,
        签收成功 = 100,
        签收失败 = -100,
        订单等候发送给物流公司 = 10,
        用户取消物流订单 = -1
    }

    /// <summary>
    /// 支付状态
    /// </summary>
    public enum PayStatus
    {
        等待买家付款 = 1,
        已付款 = 2,
        交易关闭 = 4,
        交易成功 = 6,
        没有创建外部交易 = 7,
        交易被系统关闭 = 8,
        不可付款 = 9
    }

    /// <summary>
    /// 订单状态
    /// </summary>
    public enum OrderStatus
    {
        /// <SUMMARY>
        /// 交易关闭
        /// </SUMMARY>
        CANCEL,

        /// <SUMMARY>
        /// 交易成功
        /// </SUMMARY>
        SUCCESS,

        /// <SUMMARY>
        /// 等待买家付款
        /// </SUMMARY>
        WAIT_BUYER_PAY,

        /// <SUMMARY>
        /// 等待卖家发货
        /// </SUMMARY>
        WAIT_SELLER_SEND,

        /// <SUMMARY>
        /// 等待买家确认收货
        /// </SUMMARY>
        WAIT_BUYER_RECEIVE,

        /// <SUMMARY>
        /// 分阶段等待卖家操作
        /// </SUMMARY>
        WAIT_SELLER_ACT,

        /// <SUMMARY>
        /// 等待买家确认操作
        /// </SUMMARY>
        WAIT_BUYER_CONFIRM_ACTION,

        /// <SUMMARY>
        /// 分阶段等待卖家推进
        /// </SUMMARY>
        WAIT_SELLER_PUSH,

        /// <SUMMARY>
        /// 等待物流公司揽件COD
        /// </SUMMARY>
        WAIT_LOGISTICS_TAKE_IN,

        /// <SUMMARY>
        /// 等待买家签收COD
        /// </SUMMARY>
        WAIT_BUYER_SIGN,

        /// <SUMMARY>
        /// 买家已签收COD
        /// </SUMMARY>
        SIGN_IN_SUCCESS,

        /// <SUMMARY>
        ///  签收失败COD
        /// </SUMMARY>
        SIGN_IN_FAILED


    }

    /// <summary>
    /// 退款状态
    /// </summary>
    public enum RefundStatus
    {
        /// <summary>
        /// 等待卖家同意退款协议
        /// </summary>
        WAIT_SELLER_AGREE,
        /// <summary>
        /// 退款成功
        /// </summary>
        REFUND_SUCCESS,
        /// <summary>
        /// 退款关闭
        /// </summary>
        REFUND_CLOSED,
        /// <summary>
        /// 等待买家修改
        /// </summary>
        WAIT_BUYER_MODIFY,
        /// <summary>
        /// 等待买家退货
        /// </summary>
        WAIT_BUYER_SEND,
        /// <summary>
        /// 等待卖家确认收货
        /// </summary>
        WAIT_SELLER_RECEIVE
    }
    /// <summary>
    /// 物流状态
    /// </summary>
    public enum LogisticsStatus
    {
        未发货 = 1,
        已发货 = 2,
        已收货交易成功 = 3,
        已经退货 = 4,
        部分发货交易成功 = 5,
        还未创建物流订单 = 8,

    }
    /// <summary>
    /// 交易类型
    /// </summary>
    public enum TradeType
    {
        担保交易 = 1,
        预付款交易 = 2,
        Etc境外收单交易 = 3,
        及时到账交易 = 4,
        保障金安全交易 = 5,
        统一交易流程 = 6,
        分阶段交易 = 7,
        货到付款交易 = 8,
        信用凭证支付交易 = 9,
        帐期支付交易 = 10
    }
    /// <summary>
    /// 旧交易类型
    /// </summary>
    public enum OldTradeType
    {
        /// <summary>
        /// 普通
        /// </summary>
        UNIFY,
        /// <summary>
        /// 分阶段
        /// </summary>
        STEP
    }

    /// <summary>
    /// 交易状态
    /// </summary>
    public enum TradeStatus
    {
        /// <summary>
        /// 交易关闭
        /// </summary>
        cancel,

        /// <summary>
        /// 交易成功
        /// </summary>
        success,

        /// <summary>
        /// 等待买家付款
        /// </summary>
        waitbuyerpay,

        /// <summary>
        /// 等待卖家发货
        /// </summary>
        waitsellersend,
        /// <summary>
        /// 等待买家确认收货
        /// </summary>
        waitbuyerreceive,

        /// <summary>
        /// 分阶段等待卖家操作
        /// </summary>
        waitselleract,

        /// <summary>
        /// 等待买家确认操作
        /// </summary>
        waitbuyerconfirmaction,

        /// <summary>
        /// 分阶段等待卖家推进
        /// </summary>
        waitsellerpush,


    }
    /// <summary>
    ///顾客关系来源
    /// </summary>
    public enum RelationSource
    {
        交易成功 = 1,
        交易关闭 = 2,
        手动新增 = 3
    }
    /// <summary>
    /// 会员等级
    /// </summary>
    public enum CustomerLevel
    {
        所有的=0,
        普通会员=1,
        高级会员=2,
        VIP会员=3,
        至尊VIP会员=4
    }
       
}
