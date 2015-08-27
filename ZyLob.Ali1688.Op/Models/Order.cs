using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 批发设置
    /// </summary>
    public class WholesaleSetting
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long Id { get; set; }
        public bool ActivityReady { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }

        public string WholesaleDetail { get; set; }
        /// <summary>
        ///混批设置 数量要求：订单货品总数大于等于MixNumber件
        /// </summary>
        public int MixNumber { get; set; }
        /// <summary>
        /// 混批设置 金额要求： 订单货品总价大于等于MixAmount元
        /// </summary>
        public int MixAmount { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }

        public bool ActivityInvalid { get; set; }
        public bool ActivityRunning { get; set; }
        public bool ActivityFinish { get; set; }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 是否支持发票
        /// </summary>
        public bool SupportInvoice { get; set; }
    }
    #region 新版订单接口
    /// <summary>
    /// 订单搜索模型
    /// </summary>
    public class OrderSeachModel
    {
        public OrderSeachModel()
        {
            Page = 1;
            PageSize = 20;
        }
        /// <summary>
        /// 是否历史订单
        /// </summary>
        public bool His { get; set; }
        /// <summary>
        /// 订单创建时间（查询开始值）
        /// </summary>
        public DateTime CreateStartTime { get; set; }
        /// <summary>
        /// 订单创建时间（查询结束值）
        /// </summary>
        public DateTime CreateEndTime { get; set; }
        /// <summary>
        /// 买家memberId，买卖家memberId必填其一
        /// </summary>
        public string BuyerMemberId { get; set; }
        /// <summary>
        /// 卖家memberId，买卖家memberId必填其一
        /// </summary>
        public string SellerMemberId { get; set; }
        /// <summary>
        /// 货品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 支付时间（查询开始值）, 已废弃
        /// </summary>
        public DateTime PayStartTime { get; set; }
        /// <summary>
        /// 支付时间（查询结束值），已废弃
        /// </summary>
        public DateTime PayEndTime { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        public OldTradeType? TradeTypeEnum { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus? OrderStatusEnum { get; set; }
        /// <summary>
        /// 页面大小
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }
        /// <summary>
        /// 修改时间（查询开始值）
        /// </summary>
        public DateTime ModifyStartTime { get; set; }
        /// <summary>
        /// 修改时间（查询结束值）
        /// </summary>
        public DateTime ModifyEndTime { get; set; }
        /// <summary>
        /// 订单id列表，不能多于20个
        /// </summary>
        public long[] OrderIdSet { get; set; }
        /// <summary>
        /// 卖家评论状态
        /// </summary>
        public EvaluateStatus? SellerRateStatus { get; set; }
        /// <summary>
        /// 买家评论状态
        /// </summary>
        public EvaluateStatus? BuyerRateStatus { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public RefundStatus? RefundStatus { get; set; }
    }

    /// <summary>
    /// 阿里订单搜索结果
    /// </summary>
    public class AliOrderSearchResult
    {
        /// <summary>
        /// 订单搜索结果
        /// </summary>
        public OrderListResult OrderListResult { get; set; }
    }
    /// <summary>
    /// 订单列表结果
    /// </summary>
    public class OrderListResult
    {
        public int RealPrePageSize { get; set; }

        public int Count { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 订单集合
        /// </summary>
        public List<OrderModel> ModelList { get; set; }
    }
    /// <summary>
    /// 订单详情结果
    /// </summary>
    public class OrderDetailResult
    {
        public OrderModel OrderModel { get; set; }
    }
    /// <summary>
    /// 阿里订单
    /// </summary>
    public class OrderModel
    {
        public List<OrderEntry> OrderEntries { get; set; }

        public string SellerSex { get; set; }

        public string StatusStr { get; set; }
        /// <summary>
        /// 买家承担的服务费
        /// </summary>
        public long CodBuyerFee { get; set; }


        public string GmtPayExpireTime { get; set; }
        /// <summary>
        /// 是否一次性付款
        /// </summary>
        public bool StepPayAll { get; set; }

        public bool PayOnline { get; set; }
        public int AccountPeriodDateType { get; set; }
        /// <summary>
        /// 买家登录id
        /// </summary>
        public string BuyerLoginId { get; set; }

        public bool SupportDae { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime GmtPayment { get; set; }

        public long AliloanSecurityFee { get; set; }
        /// <summary>
        /// cod状态。
        /// </summary>
        public CodStatus CodStatus { get; set; }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string AlipayTradeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TrustDeceit { get; set; }
        /// <summary>
        /// 买家email
        /// </summary>
        public string BuyerEmail { get; set; }
        /// <summary>
        /// 卖家电话
        /// </summary>
        public string SellerPhone { get; set; }

        public int AccountPeriodDate { get; set; }
        /// <summary>
        /// 折扣，单位分
        /// </summary>
        public long Discount { get; set; }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string ToArea { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public PayStatus PayStatus { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }

        public bool Virtual { get; set; }

        /// <summary>
        /// 交易类型。UNIFY统一交易流程，STEPPAY分阶段交易，COD货到付款交易，CERTIFICATE信用凭证支付交易（注：该字段已不再维护，替换为tradeTypeStr，请新业务使用新字段）
        /// </summary>
        public OldTradeType TradeType { get; set; }

        /// <summary>
        /// 订单来源(已废弃)
        /// </summary>
        public string OrderFrom { get; set; }

        public OrderSign OrderSign { get; set; }

        public string BizTypeEnum { get; set; }

        public bool SingleStepForNewStep { get; set; }

        public bool OverSold { get; set; }

        public DateTime GmtGoodsReceived { get; set; }

        public long TbId { get; set; }
        /// <summary>
        /// 明细完成时间
        /// </summary>
        public DateTime GmtCompleted { get; set; }

        public string SourceType { get; set; }

        public int Belonging { get; set; }
        /// <summary>
        /// 买家评价状态。5未评价，4已评价
        /// </summary>
        public EvaluateStatus BuyerRateStatus { get; set; }

        public string FreightBillNo { get; set; }
        public long CertificateSumPayment { get; set; }
        /// <summary>
        /// 买家支付宝id
        /// </summary>
        public string BuyerAlipayId { get; set; }
        /// <summary>
        /// 买家阿里会员编号
        /// </summary>
        public string BuyerMemberId { get; set; }
        /// <summary>
        /// cod交易的实付款（买家实际支付给物流的费用）	
        /// </summary>
        public long CodActualFee { get; set; }
        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime GmtGoodsSend { get; set; }
        /// <summary>
        /// 买家电话
        /// </summary>
        public string BuyerPhone { get; set; }

        public string ToFullName { get; set; }
        public string BuyerSex { get; set; }
        /// <summary>
        /// 买家数字id
        /// </summary>
        public long BuyerUserId { get; set; }

        public bool SLsjOrder { get; set; }
        public string NormalInstantFlag { get; set; }
        /// <summary>
        /// 卖家数字id
        /// </summary>
        public long SellerUserId { get; set; }
        /// <summary>
        /// 买家公司名称
        /// </summary>
        public string BuyerCompanyName { get; set; }
        /// <summary>
        /// 卖家支付宝id
        /// </summary>
        public string SellerAlipayId { get; set; }
        /// <summary>
        /// 是否COD订单并且清算成功
        /// </summary>
        public bool CodAudit { get; set; }
        /// <summary>
        /// 运费，单位分
        /// </summary>
        public long Carriage { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus Status { get; set; }
        /// <summary>
        /// 卖家名称
        /// </summary>
        public string SellerName { get; set; }
        /// <summary>
        /// 买家手机号
        /// </summary>
        public string BuyerMobile { get; set; }

        public string SellerFlag { get; set; }

        public string DataFromType { get; set; }
        /// <summary>
        /// 卖家会员编号
        /// </summary>
        public string SellerMemberId { get; set; }

        public string BizType { get; set; }
        /// <summary>
        /// 卖家登录id
        /// </summary>
        public string SellerLoginId { get; set; }

        public JObject OrderOfferEntries { get; set; }

        public OrderPaymentSign OrderPaymentSign { get; set; }

        public long AccountPeriodExtendCount { get; set; }
        /// <summary>
        /// 总货品金额
        /// </summary>
        public long SumProductPayment { get; set; }
        /// <summary>
        /// 收货人邮编
        /// </summary>
        public string ToPost { get; set; }
        /// <summary>
        /// 买家承担的服务费初始值
        /// </summary>
        public long CodBuyerInitFee { get; set; }
        /// <summary>
        /// 付款总金额，单位（分）订单需要支付的总金额=产品总金额+运费-折扣金额-抵价券（如果有的话），如果是COD订单，不包括COD服务费
        /// </summary>
        public long SumPayment { get; set; }
        /// <summary>
        /// 卖家评价状态。5未评价，4已评价
        /// </summary>
        public EvaluateStatus SellerRateStatus { get; set; }
        /// <summary>
        /// cod服务费
        /// </summary>
        public long CodFee { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        public long Id { get; set; }

        public long SumConfirmPaidPayment { get; set; }

        public string SourceTypeStr { get; set; }
        /// <summary>
        /// 退款状态
        /// </summary>
        public RefundStatus RefundStatus { get; set; }

        public ComplaintStatus NewComplaintStatus { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public LogisticsStatus LogisticsStatus { get; set; }
        /// <summary>
        ///  交易类型
        /// </summary>
        public TradeType TradeTypeStr { get; set; }

        public long PromotionsFee { get; set; }

        public bool TocManagedTimeout { get; set; }

        public bool WirelessOrder { get; set; }
        /// <summary>
        /// 买家签收时间(COD)
        /// </summary>
        public DateTime GmtSign { get; set; }

        public long OrderPromotionsFee { get; set; }


        public string TocSign { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }

        public bool LadderGroup { get; set; }
        public string BuyerFlag { get; set; }
        /// <summary>
        /// 卖家公司名称
        /// </summary>
        public string SellerCompanyName { get; set; }
        /// <summary>
        /// 买家名字
        /// </summary>
        public string BuyerName { get; set; }

        public string CreditCard { get; set; }
        /// <summary>
        /// 卖家承担的服务费
        /// </summary>
        public long CodSellerFee { get; set; }

        public long SumProductPaymentWithCoupon { get; set; }
        /// <summary>
        /// 退款金额，单位分
        /// </summary>
        public long RefundPayment { get; set; }

        public long SuccSumPayment { get; set; }

        public Dictionary<string, string> Attributes { get; set; }
        /// <summary>
        /// 订单(产品)名称
        /// </summary>
        public string ProductName { get; set; }
    }

    /// <summary>
    /// 订单明细模型
    /// </summary>
    public class OrderEntry
    {

        public int ConfirmGoodsAmount { get; set; }

        /// <summary>
        /// 买家数字id
        /// </summary>
        public long BuyerUserId { get; set; }

        public long RefundFee { get; set; }

        /// <summary>
        /// 明细单价
        /// </summary>
        public long UnitPrice { get; set; }
        /// <summary>
        /// 快照图片组
        /// </summary>
        public SnapshotImageModel[] SnapshotImages { get; set; }

        public bool MaliciousOrder { get; set; }

        public long ActivityId { get; set; }

        /// <summary>
        /// 产品金额
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// 支付状态，与淘宝一致
        /// </summary>
        public int EntryPayStatus { get; set; }

        /// <summary>
        /// 子订单退款状态，waitselleragree等待卖家同意，refundsuccess退款成功，refundclose退款关闭，waitbuyermodify待买家修改，waitbuyersend等待买家退货，waitsellerreceive等待卖家确认收货
        /// </summary>
        public string EntryRefundStatus { get; set; }

        /// <summary>
        /// 子订单状态，取值范围同主订单状态
        /// </summary>
        public string EntryStatusStr { get; set; }

        public long SkuId { get; set; }
        public bool IsMaliciousOrder { get; set; }

        /// <summary>
        /// 数量  
        /// </summary>
        public decimal Quantity { get; set; }

        public long PriceAfterPromotion { get; set; }

        public bool SevenDayFlag { get; set; }

        public string[] AllCommissionSceneType { get; set; }

        /// <summary>
        /// 卖家数字id
        /// </summary>
        public long SellerUserId { get; set; }

        public string ReduceInv { get; set; }

        /// <summary>
        /// COD物流状态，与淘宝一致
        /// </summary>
        public int CodStatus { get; set; }

        public CommissionModel CommissionModel { get; set; }
        /// <summary>
        /// 商品规格属性数据模型
        /// </summary>
        public SpecInfoModel SpecInfoModel { get; set; }

        public string EntryStatus { get; set; }
        /// <summary>
        /// offer的类目id；非offer订单为空
        /// </summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 该订单明细是否有买家保障服务
        /// </summary>
        public bool BuyerSecuritySupport { get; set; }
        /// <summary>
        /// 产品打折单价
        /// </summary>
        public long DiscountPrice { get; set; }
        /// <summary>
        /// 产品图片
        /// </summary>
        public string[] ProductPics { get; set; }

        public int ActualDeliveryAmount { get; set; }
        /// <summary>
        /// 折扣价
        /// </summary>
        public long Discount { get; set; }
        /// <summary>
        /// 订单明细单价，单位：分
        /// </summary>
        public long Price { get; set; }

        public int AmountWithDiscountAndPromotion { get; set; }
        /// <summary>
        /// 快照ID
        /// </summary>
        public string SnapshotId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }
        /// <summary>
        /// 订单来源(已废弃)
        /// </summary>
        public string OrderFrom { get; set; }
        /// <summary>
        /// 付款时分摊后的每笔子订单金额
        /// </summary>
        public long ActualPayFee { get; set; }

        public string MainSummImageUrl { get; set; }

        public string ProductPic { get; set; }
        public long LogisticsOrderId { get; set; }
        /// <summary>
        /// 该订单明细订购的来源，比如大额批发、普通大市场或者拿样，对应Detail的来源不同
        /// </summary>
        public string OrderSourceType { get; set; }
        /// <summary>
        /// 卖家评价状态(4:未评论,5:已评论,6;不需要评论)
        /// </summary>
        public EvaluateStatus SellerRateStatus { get; set; }

        public long DetailItemToSellerFee { get; set; }

        public bool OverSold { get; set; }
        /// <summary>
        /// 订单明细来源ID，如offer的id
        /// </summary>
        public long SourceId { get; set; }
        /// <summary>
        /// 订单明细涨价或折扣
        /// </summary>
        public long EntryDiscount { get; set; }
        /// <summary>
        /// 订单明细ID
        /// </summary>
        public long Id { get; set; }

        public long TbId { get; set; }
        /// <summary>
        /// 物流状态，取值范围同主订单物流状态
        /// </summary>
        public int LogisticsStatus { get; set; }

        public bool FromOffer { get; set; }
        /// <summary>
        ///  优惠价格 - 如满100立减
        /// </summary>
        public long PromotionsFee { get; set; }
        /// <summary>
        /// 明细完成时间
        /// </summary>
        public DateTime GmtCompleted { get; set; }

        public int RefundGoodsAmount { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long OrderId { get; set; }
        /// <summary>
        /// 货币种类
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }
        /// <summary>
        /// 买家评价状态(4:未评论,5:已评论,6;不需要评论)
        /// </summary>
        public EvaluateStatus BuyerRateStatus { get; set; }
        /// <summary>
        /// 售后投诉状态，'-'初始值，'1'首次投诉中，'0'投诉自行撤销，'2'投诉后台无效，'3'再次投诉中，'8'投诉资格关闭，'9'投诉处理完成
        /// </summary>
        public ComplaintStatus ComplaintStatus { get; set; }

        public string MainImageUrl { get; set; }

        public long ItemId { get; set; }
        /// <summary>
        /// 订单明细业务标识
        /// </summary>
        public BizSign BizSign { get; set; }
        /// <summary>
        /// 货物单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 售中退款单ID
        /// </summary>
        public string RefundId { get; set; }
        /// <summary>
        /// 商品规格属性ID
        /// </summary>
        public string SpecId { get; set; }
        /// <summary>
        /// 明细扩展属性,用于保存交易不关心，但需要打在订单上的属性。目前只有“是否已导入行业产品库"
        /// </summary>
        public Dictionary<string, string> Attributes { get; set; }
        public long OrderSharedPromotionFee { get; set; }
        /// <summary>
        /// 订单明细(产品)名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 该订单明细是否有保障卡支持
        /// </summary>
        public bool GuaranteeSupport { get; set; }
    }
    
    #endregion
    #region 辅助模型
    /// <summary>
    /// 快照图片模型
    /// </summary>
    public class SnapshotImageModel
    {
        /// <summary>
        /// 大图图片：全路径
        /// </summary>
        public string ImageUrl { get; set; }
        /// <summary>
        /// 小图图片：全路径，目前动态生成小图规格：64x64
        /// </summary>
        public string SummImageUrl { get; set; }
        /// <summary>
        ///小图图片：全路径，目前动态生成小图规格：64x64
        /// </summary>
        public string MidImageUrl { get; set; }

    }

    public class CommissionModel
    {
        public bool ValidCommissionSceneType { get; set; }

    }
    /// <summary>
    /// 商品规格属性数据模型
    /// </summary>
    public class SpecInfoModel
    {
        /// <summary>
        /// 规格属性条目列表
        /// </summary>
        public List<SpecItem> SpecItems { get; set; }
    }
    /// <summary>
    /// 规格属性条目
    /// </summary>
    public class SpecItem
    {
        /// <summary>
        /// 规格属性名称
        /// </summary>
        public string SpecName { get; set; }
        /// <summary>
        /// 规格属性值
        /// </summary>
        public string SpecValue { get; set; }
        /// <summary>
        /// 规格属性单位
        /// </summary>
        public string Unit { get; set; }
    }
    /// <summary>
    /// 售后投诉状态
    /// </summary>
    public class ComplaintStatus
    {

        public bool RefundComplaintDoing { get; set; }
        public bool Valid { get; set; }
        public bool AfterSalesComplaintDoing { get; set; }

    }
    /// <summary>
    /// 订单明细业务标识
    /// </summary>
    public class BizSign
    {
        public long Sign { get; set; }
        public bool SalePromotion { get; set; }

        public bool YiFenSample { get; set; }

        public bool JiCaiGoods { get; set; }

        public bool CommonSample { get; set; }
        public string BinaryString { get; set; }
        public bool Mix { get; set; }
        public bool FreePostage { get; set; }

        public bool VirtualGoods { get; set; }

    }

    public class OrderSign
    {
        public bool Transfer { get; set; }
        public bool CouponUnFreezed { get; set; }
        public bool StepTradeHuopinOffer { get; set; }
        public bool AssurePayed { get; set; }
        public bool BuyerSeeLogistics { get; set; }
        public bool CouponConsume { get; set; }
        public bool FreezePayed { get; set; }
        public long Sign { get; set; }
        public bool SellerSeeLogistics { get; set; }
        public bool SellerNotifyLogistics { get; set; }
        public bool SendGoodsArranged { get; set; }
        public bool GoodsReadyToShip { get; set; }
        public bool EnsureReleased { get; set; }
        public bool Suspected { get; set; }
        public bool CouponFreezed { get; set; }
        public bool SupportInvoice { get; set; }
        public bool BuyerNotifyLogistics { get; set; }

    }

    public class OrderPaymentSign
    {
        public bool BankInstant { get; set; }
        public long PaymentSign { get; set; }
        public bool AlipayAssure { get; set; }
    } 
    #endregion

    /// <summary>
    /// （原）订单详情
    /// </summary>
    public class TradeDetail
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }
        /// <summary>
        ///  交易类型
        /// </summary>
        public TradeType TradeType { get; set; }
        /// <summary>
        /// 买家数字id
        /// </summary>
        public long BuyerUserId { get; set; }

        public List<TradeEntry> OrderEntries { get; set; }
        /// <summary>
        /// 总货品金额
        /// </summary>
        public long SumProductPayment { get; set; }
        /// <summary>
        /// 卖家评论状态
        /// </summary>
        public EvaluateStatus? SellerRateStatus { get; set; }
        public long CertificateSumPayment { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime GmtPayment { get; set; }
        /// <summary>
        /// 卖家数字id
        /// </summary>
        public long SellerUserId { get; set; }
        /// <summary>
        /// 卖家支付宝id
        /// </summary>
        public string SellerAlipayId { get; set; }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string AlipayTradeId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }
        /// <summary>
        /// 买家评论状态
        /// </summary>
        public EvaluateStatus? BuyerRateStatus { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public string  Status { get; set; }
        /// <summary>
        /// 运费，单位分
        /// </summary>
        public long Carriage { get; set; }
        /// <summary>
        /// 卖家公司名称
        /// </summary>
        public string SellerCompanyName { get; set; }
        /// <summary>
        /// 卖家电话
        /// </summary>
        public string SellerPhone { get; set; }
        /// <summary>
        /// 买家支付宝id
        /// </summary>
        public string BuyerAlipayId { get; set; }
        /// <summary>
        /// 买家会员编号
        /// </summary>
        public string BuyerMemberId { get; set; }

        /// <summary>
        /// 折扣，单位分
        /// </summary>
        public long Discount { get; set; }
        /// <summary>
        /// 买家电话
        /// </summary>
        public string BuyerPhone { get; set; }
        /// <summary>
        /// 卖家会员编号
        /// </summary>
        public string SellerMemberId { get; set; }
        /// <summary>
        /// 退款金额，单位分
        /// </summary>
        public long RefundPayment { get; set; }
    }
    /// <summary>
    /// （原）订单明细
    /// </summary>
    public class TradeEntry
    {
        /// <summary>
        /// 订单明细ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 订单明细单价，单位：分
        /// </summary>
        public long Price { get; set; }
    
        public string OfferSnapshotImageUrl { get; set; }

        public string EntryStatus { get; set; }

        public string ProductPic { get; set; }
         /// <summary>
        /// cod状态。
        /// </summary>
        public CodStatus EntryCodStatus { get; set; }
        /// <summary>
        /// 商品规格属性ID
        /// </summary>
        public string SpecId { get; set; }
        /// <summary>
        /// 数量  
        /// </summary>
        public decimal Quantity { get; set; }
        /// <summary>
        /// 货品名称
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 订单明细涨价或折扣
        /// </summary>
        public long EntryDiscount { get; set; }
        /// <summary>
        /// 订单明细来源ID，如offer的id
        /// </summary>
        public long SourceId { get; set; }
    }

}