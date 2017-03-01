﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using ZyLob.Ali1688.Op.Common;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 产品详细信息
    /// </summary>
    public class OfferDetailInfo
    {

        public Dictionary<string, JArray> SkuPics { get; set; }

        /// <summary>
        /// 是否有私密信息
        /// </summary>
        public bool IsPrivateOffer { get; set; }
        /// <summary>
        /// 是否价格私密
        /// </summary>
        public bool IsPriceAuthOffer { get; set; }
        /// <summary>
        /// 是否图片私密
        /// </summary>
        public bool IsPicAuthOffer { get; set; }
        /// <summary>
        /// 商品ID
        /// </summary>
        public long OfferId { get; set; }
        /// <summary>
        /// 是否为私密offer的标志位。true：私密产品 false：普通产品
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// 商品详情地址
        /// </summary>
        public string DetailsUrl { get; set; }
        /// <summary>
        /// 商品类型。Sale：供应信息，Buy：求购信息
        /// </summary>
        public OfferType Type { get; set; }
        /// <summary>
        /// 贸易类型。1：产品，2：加工，3：代理，4：合作，5：商务服务
        /// </summary>
        public long TradeType { get; set; }
        /// <summary>
        /// 所属叶子类目ID
        /// </summary>
        public long PostCategryId { get; set; }
        /// <summary>
        /// 状态。auditing：审核中；online：已上网；FailAudited：审核未通过；outdated：已过期；member delete(d)：用户删除；delete：审核删除
        /// </summary>
        public string OfferStatus { get; set; }
        /// <summary>
        /// 卖家会员ID
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 详情说明
        /// </summary>
        public string Details { get; set; }
        /// <summary>
        /// 商品信息质量星级( 取值为1到5)。1：一星；2：二星；3：三星；4：四星；5：五星
        /// </summary>
        public string QualityLevel { get; set; }
        /// <summary>
        /// 商品图片列表
        /// </summary>
        public List<OfferImageInfo> ImageList { get; set; }
        /// <summary>
        /// 商品属性信息
        /// </summary>
        public List<ProductFeatureInfo> ProductFeatureList { get; set; }
        /// <summary>
        /// 是否支持网上交易。
        /// 首先需要类目支持，如果类目支持，需要有价格，供货总量，最小起订量。true：支持网上订购；false：不支持网上订购
        /// </summary>
        public bool IsOfferSupportOnlineTrade { get; set; }
        /// <summary>
        /// 支持的交易方式。
        /// 当isOfferSupportOnlineTrade为true的时候本字段有效：
        /// Escrow:支付宝担保交易； 
        /// PreCharge：支付宝预存款交易；
        /// ForexPay：支付宝境外支付交易；
        /// 多种交易方式间通过;分隔。
        /// </summary>
        public string TradingType { get; set; }
        /// <summary>
        /// 是否支持混批。true：支持混批；false：不支持混批
        /// </summary>
        public bool IsSupportMix { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 交易币种
        /// </summary>
        public string PriceUnit { get; set; }
        /// <summary>
        /// 供货量
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// 可售数量
        /// </summary>
        public long AmountOnSale { get; set; }
        /// <summary>
        /// 已销售量
        /// </summary>
        public long SaledCount { get; set; }
        /// <summary>
        /// 建议零售价
        /// </summary>
        public ProductPrice RetailPrice { get; set; }
        /// <summary>
        /// 单价
        /// </summary>
        public ProductPrice UnitPrice { get; set; }
        /// <summary>
        /// 价格区间
        /// </summary>
        public List<PriceRangeInfo> PriceRanges { get; set; }
        /// <summary>
        /// 有效期(单位：天)
        /// </summary>
        public long TermOfferProcess { get; set; }
        /// <summary>
        /// 物流模板id
        /// </summary>
        public long FreightTemplateId { get; set; }
        /// <summary>
        /// 发货地址id
        /// </summary>
        public long SendGoodsId { get; set; }

        /// <summary>
        /// 单位重量
        /// </summary>
        public string ProductUnitWeight { get; set; }
        /// <summary>
        /// T:运费模板 D：运费说明 F：卖家承担运费
        /// </summary>
        public string FreightType { get; set; }
        /// <summary>
        /// 是否为SKU商品
        /// </summary>
        public bool IsSkuOffer { get; set; }
        /// <summary>
        /// 是否支持按照规格报价
        /// </summary>
        public bool IsSkuTradeSupported { get; set; }
        /// <summary>
        /// SKU规格属性信息{fid:value}当有多个值时用"#"联接
        /// </summary>
        public List<SkuInfo> SkuArray { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime GmtCreate { get; set; }
        /// <summary>
        /// 最近修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }
        /// <summary>
        /// 最近重发时间
        /// </summary>
        public DateTime GmtLastRepost { get; set; }
        /// <summary>
        /// 审核通过时间
        /// </summary>
        public DateTime GmtApproved { get; set; }
        /// <summary>
        /// 过期日期
        /// </summary>
        public DateTime GmtExpire { get; set; }
    }

    /// <summary>
    /// 商品图片
    /// </summary>
    public class OfferImageInfo
    {
        /// <summary>
        /// 图片URL（推荐用这个）
        /// </summary>
        public string ImageUri { get; set; }
        /// <summary>
        /// 原图URL
        /// </summary>
        public string OriginalImageUri { get; set; }
        /// <summary>
        ///图片URL
        /// </summary>
        public string Size64X64Url { get; set; }
        /// <summary>
        /// 图片URL
        /// </summary>
        public string SummUrl { get; set; }
        /// <summary>
        /// 图片URL
        /// </summary>
        public string Size310X310Url { get; set; }
    }
    /// <summary>
    /// 商品属性信息
    /// </summary>
    public class ProductFeatureInfo
    {
        /// <summary>
        /// 属性ID。
        /// </summary>
        public long Fid { get; set; }
        /// <summary>
        /// 属性值集合
        /// </summary>
        public string[] Values { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string Value { get; set; }
    }
    /// <summary>
    /// 价格区间
    /// </summary>
    public class PriceRangeInfo
    {
        /// <summary>
        /// 最小起订量
        /// </summary>
        public string Range { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double ConvertPrice { get; set; }
        /// <summary>
        /// 价格。商品批发价格
        /// </summary>
        public double Price { get; set; }
    }
    /// <summary>
    /// 建议零售价
    /// </summary>
    public class ProductPrice
    {
        /// <summary>
        /// 总额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 分
        /// </summary>
        public double Cent { get; set; }
        /// <summary>
        /// 分的计数
        /// </summary>
        public double CentFactor { get; set; }
        /// <summary>
        /// 货币信息
        /// </summary>
        public Currency Currency { get; set; }

    }
    /// <summary>
    /// 货币
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// 默认编号
        /// </summary>
        public int DefaultFractionDigits { get; set; }
        /// <summary>
        /// 货币代码
        /// </summary>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// 交易货币符号
        /// </summary>
        public string Symbol { get; set; }
    }


  
    /// <summary>
    /// 产品属性值
    /// </summary>
    public class SkuInfo
    {
        public long Fid { get; set; }
        public string Value { get; set; }
        public string RetailPrice { get; set; }
        public string Price { get; set; }
        public int CanBookCount { get; set; }
        public string CargoNumber { get; set; }
        public string SpecId { get; set; }
        
        public int SaleCount { get; set; }
        public List<SkuInfo> Children { get; set; }

    }
    /// <summary>
    /// 产品搜索模型
    /// </summary>
    public class ProductSeachModel
    {
        public ProductSeachModel()
        {
            PageNo = 1;
            PageSize = 20;
            StatusList=new List<OfferStatus>();
        }
        /// <summary>
        /// 当分页查询时指定请求的数据页
        /// </summary>
        public int PageNo { get; set; }
        /// <summary>
        /// 返回字段，默认为空，全部返回
        /// </summary>
        public string ReturnFields { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public long OfferId { get; set; }
        /// <summary>
        /// 每页记录数，默认为20 最大50 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 排序字段：gmtexpire:asc|desc,gmt_modified:asc|desc
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 搜索关键字，现在主要支持按标题搜索
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// 发布类目编号
        /// </summary>
        public long Category { get; set; }
        /// <summary>
        /// 查询修改时间结束时刻.要求 gmtModifedBegin 早于 gmtModifiedEnd
        /// </summary>
        public DateTime GmtModifiedBegin { get; set; }
        /// <summary>
        /// 查询修改时间结束时刻.要求 gmtModifedEnd 晚于 gmtModifiedBegin
        /// </summary>
        public DateTime GmtModifiedEnd { get; set; }
        /// <summary>
        /// 供货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 会员ID 
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 诚信通开能年限
        /// </summary>
        public string TpYear { get; set; }
        /// <summary>
        /// 诚信保障金额
        /// </summary>
        public string CreditMoney { get; set; }
        /// <summary>
        /// 最低销售额
        /// </summary>
        public string SoldQuantity { get; set; }
        /// <summary>
        /// 省份中文名
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 城市中文名                  
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 价格区间
        /// </summary>
        public string Price { get; set; }
        /// <summary>
        /// 供应产品星级
        /// </summary>
        public string QualityLevel { get; set; }
        /// <summary>
        /// 最小起批量
        /// </summary>
        public string QuantityBegin { get; set; }
        /// <summary>
        /// 会员自定义类别ID
        /// </summary>
        public string GroupIds { get; set; }

        /// <summary>
        /// Offer状态
        /// </summary>
        public OfferStatus? Status { get; set; }
        /// <summary>
        /// Offer集合状态
        /// </summary>
        public List<OfferStatus> StatusList { get; set; }
        /// <summary>
        /// 获取状态标识
        /// </summary>
        internal string GetStatusStr
        {
            get
            {
              
                if (Status != null && StatusList.All(e => e != Status))
                {
                    StatusList.Add(Status.Value);
                }
                var statuDis = StatusList.Distinct();
                var statusDesc = EnumUtils.FindAll<OfferStatus, EnumDescription>();
                var statusStrList=new List<string>();
                foreach (var offerStatuse in statuDis)
                {
                    statusStrList.Add(statusDesc[offerStatuse].TextTag);
                }
               return string.Join(",", statusStrList);
            }
        }
    }

    /// <summary>
    /// 产品重发结果
    /// </summary>
    public class ProductRepostResult
    {
        /// <summary>
        /// 是否成功标记位
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string Failure { get; set; }
        /// <summary>
        /// 产品id
        /// </summary>
        public long OfferId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime GmtExpire { get; set; }

        /// <summary>
        /// 重发时间
        /// </summary>
        public DateTime GmtRepublished { get; set; }
    }
    /// <summary>
    /// 产品增量修改
    /// </summary>
    public class OfferIncrementAttr
    {
        /// <summary>
        /// 产品编号
        /// </summary>
        public long OfferId { get; set; }
        /// <summary>
        /// 产品详情
        /// </summary>
        public string OfferDetail { get; set; }
        /// <summary>
        /// 产品标题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 自定义分类
        /// </summary>
        public string UserCategorys { get; set; }
        /// <summary>
        /// 运费类型
        /// </summary>
        public string FreightType { get; set; }
        /// <summary>
        /// 单位重量
        /// </summary>
        public string OfferWeight { get; set; }
         /// <summary>
        /// 图片仅会员可见
        /// </summary>
        public string IsPictureAuthOffer { get; set; }
        /// <summary>
        /// 价格仅会员可见
        /// </summary>
        public string IsPriceAuthOffer { get; set; }
        /// <summary>
        /// 是否支持混批
        /// </summary>
        public string IsMixWholeSale { get; set; }
        /// <summary>
        /// 发货地址
        /// </summary>
        public string SendGoodsAddressId { get; set; }
        /// <summary>
        /// 运费模版编号
        /// </summary>
        public string FreightTemplateId { get; set; }
        /// <summary>
        /// sku价格
        /// </summary>
        public List<OfferIncrementSku> SkuList { get; set; }

    }
    /// <summary>
    /// 产品增量修改--sku价格
    /// </summary>
    public class OfferIncrementSku
    {
        public Dictionary<string, string> specAttributes { get; set; }
        public string cargoNumber { get; set; }
        public long amountOnSale { get; set; }
        public string specId { get; set; }

        public decimal price { get; set; }
        public decimal retailPrice { get; set; }
        public long saleCount { get; set; }
    }
    /// <summary>
    /// 批量修改库存
    /// </summary>
    public class ModifyStockResult
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        public Dictionary<string,string> errors { get; set; }

        /// <summary>
        /// 是否操作成功
        /// </summary>
        public bool Success { get; set; }
     
    }
    /// <summary>
    /// 产品入参信息,新发修改时的产品入参结构
    /// </summary>
    public class OfferNew
    {
        public Dictionary<string, List<Dictionary<string,string>>> skuPics { get; set; }
        /// <summary>
        /// 贸易类型。1：产品，2：加工，3：代理，4：合作，5：商务服务 不传入默认按照产品发布
        /// </summary>
        public int bizType { get; set; }
        /// <summary>
        /// 产品属性列表。key是属性id， value是值。所有的属性值都需要传入，包括产品属性和除价格之外的交易属性
        /// </summary>
        public Dictionary<string,string> productFeatures { get; set; }
        /// <summary>
        /// 自定义类目信息。如果有父ID ，则格式为：父id:子ID
        /// </summary>
        public List<string> userCategorys { get; set; }
        /// <summary>
        /// 类目ID
        /// </summary>
        public long categoryID { get; set; }
        /// <summary>
        /// 是否支持网上交易。true：支持 false：不支持
        /// </summary>
        public bool supportOnlineTrade { get; set; }
        /// <summary>
        /// 是否SKU信息
        /// </summary>
        public bool skuTradeSupport { get; set; }

        /// <summary>
        /// 是否图片私密信息
        /// </summary>
        public bool pictureAuthOffer { get; set; }

        /// <summary>
        /// 是否价格私密信息
        /// </summary>
        public bool priceAuthOffer { get; set; }

        /// <summary>
        /// 是否支持混批
        /// </summary>
        public bool mixWholeSale { get; set; }
        /// <summary>
        /// 信息有效期
        /// </summary>
        public int periodOfValidity { get; set; }
        /// <summary>
        /// 商品详情信息
        /// </summary>
        public string offerDetail { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public List<string> imageUriList { get; set; }

        /// <summary>
        /// 运费类型。T（运费模板） D（运费说明） F（卖家承担运费）
        /// </summary>
        public string freightType { get; set; }

        /// <summary>
        /// 发货地址ID
        /// </summary>
        public long sendGoodsAddressId { get; set; }

        /// <summary>
        /// 物流模板。卖家承担时模板ID为61
        /// </summary>
        public long freightTemplateId { get; set; }

        /// <summary>
        /// 可售数量
        /// </summary>
        public int amountOnSale { get; set; }

        /// <summary>
        /// 区间价格。每个区间之间用`分割，冒号前面是起订量，后面是价格 20:10`30:9`40:8
        /// </summary>
        public string priceRanges { get; set; }

        /// <summary>
        ///  单位重量
        /// </summary>
        public double offerWeight { get; set; }
        /// <summary>
        /// SKU信息。
        /// </summary>
        public List<OfferIncrementSku> skuList { get; set; }
        /// <summary>
        /// 计量单位
        /// </summary>

        public string unit { get; set; }
        /// <summary>
        /// 是否支持按照规格报价
        /// </summary>
        public bool IsSkuTradeSupported { get; set; }
    }
    /// <summary>
    /// 供品过期结果
    /// </summary>
    public class OfferExpireResult
    {
        /// <summary>
        /// 错误提醒
        /// </summary>
        public string Failure { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime GMTExpire { get; set; }
        /// <summary>
        /// 是否下架成功
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime GMTModified { get; set; }

        /// <summary>
        /// 供品编号
        /// </summary>
        public long OfferId { get; set; }

    }
    /// <summary>
    /// 产品是否可以修改的信息
    /// </summary>
    public class OfferCanModifyResult
    {
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 是否可修改
        /// </summary>

        public bool IsEditable { get; set; }
        /// <summary>
        /// 产品编号
        /// </summary>
        public long OfferId { get; set; }
    }
    /// <summary>
    /// 获取某个卖家的相关橱窗信息(目前诚信通用户可用)
    /// </summary>
    public class ShowWindowModel
    {
        /// <summary>
        /// 已用橱窗数
        /// </summary>
        public int swUsedCount { get; set; }
        /// <summary>
        /// 橱窗总数
        /// </summary>
        public int swTotalCount { get; set; }
         /// <summary>
        /// 基准橱窗数
        /// </summary>
        public int swBaseCount { get; set; }
         /// <summary>
        /// 奖励橱窗数
        /// </summary>
        public int swAwardCount { get; set; }
         /// <summary>
        /// 扣减橱窗数
        /// </summary>
        public int swReduceCount { get; set; }
         /// <summary>
        /// 剩余橱窗数
        /// </summary>
        public int swRemainCount { get; set; }
         /// <summary>
        /// 活动奖励橱窗数
        /// </summary>
        public int swActivityCount { get; set; }
         /// <summary>
        /// 版本ID
        /// </summary>
        public int versionId { get; set; }
        /// <summary>
        /// 会员ID
        /// </summary>
        public string memberId { get; set; }
        /// <summary>
        /// 基准橱窗数原因
        /// </summary>
        public string swBaseCountReason { get; set; }
        /// <summary>
        /// 奖励橱窗数原因
        /// </summary>
        public string swAwardCountReason { get; set; }
        /// <summary>
        /// 扣减橱窗数原因
        /// </summary>
        public string swReduceCountReason { get; set; }
        /// <summary>
        /// 是否黑名单会员，true为黑名单，false不为黑名单
        /// </summary>
        public bool blackListMemberStatus { get; set; }
        /// <summary>
        /// 橱窗运算时间
        /// </summary>
        public DateTime gmtCreate { get; set; }
        
    }
    /// <summary>
    /// 推荐一个产品为橱窗产品(目前诚信通用户可用)
    /// </summary>
    public class RecommendOfferResult
    {
        public DateTime modifyTime { get; set; }
        public long offerId { get; set; }
    }
    /// <summary>
    /// 橱窗错误信息
    /// </summary>
    public class ShowWindowError
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string exception { get; set; }
        public string request_id { get; set; }
    }
    /// <summary>
    /// 获取某个卖家的相关橱窗信息结果模型
    /// </summary>
    public class ShowWindowResult : ShowWindowError
    {
        public ShowWindowModel showWindowModel { get; set; }
    }
    /// <summary>
    /// 推荐一个产品为橱窗产品(目前诚信通用户可用)
    /// </summary>
    public class ShowWindowDoRecommendOfferResult : ShowWindowError
    {
        public RecommendOfferResult resultMap { get; set; }
    }
    /// <summary>
    /// 获取某个卖家已经推荐的橱窗产品列表
    /// </summary>
    public class ShowWindowDoQueryRecommOfferListResult : ShowWindowError
    {
        public List<OfferDetailInfo> showWindowOfferList { get; set; }
    }

    #region 微供
    /// <summary>
    /// (微供)根据供应商获取offerId列表
    /// </summary>
    public class GetOfferListResult
    {
        public bool success { get; set; }

        public string msgCode { get; set; }

        public string msgInfo { get; set; }

        public long[] model { get; set; }
    }

    public class ProductInfoGetResult
    {

        public ProductInfoResult result { get; set; }

        public string errMsg { get; set; }

        public string errCode { get; set; }

    }


    //(微供)获取产品的结果对象 
    public class ProductInfoResult
    {
        public DateTime createTime { get; set; }

        public DateTime lastUpdateTime { get; set; }

        public DateTime lastRepostTime { get; set; }
        public DateTime approvedTime { get; set; }

        public DateTime expireTime { get; set; }
        public ProductInfo productInfo { get; set; }
        public string productOwnerId { get; set; }

    }
    //(微供产品详细)
    public class ProductInfo
    {
        public long productID { get; set; }

        public string productType { get; set; }
        public long categoryID { get; set; }
        //商品属性
        public ProductAttribute[] attributes { get; set; }

        public long[] groupID { get; set; }

        public string status { get; set; }

        public string subject { get; set; }

        public string description { get; set; }

        public string language { get; set; }

        public int periodOfValidity { get; set; }

        public int bizType { get; set; }

        public bool pictureAuth { get; set; }

        //图片列表
        public ProductImageInfo image { get; set; }
        //sku列表
        public ProductSKUInfo[] skuInfos { get; set; }
        //商品销售信息
        public ProductSaleInfo saleInfo { get; set; }
        //商品物流信息
        public ProductShippingInfo shippingInfo { get; set; }
        //
        public ProductInternationalTradeInfo internationalTradeInfo { get; set; }
        //商品扩展信息
        public ProductExtendInfo[] extendInfos { get; set; }

    }
    //(微供)产品图片列表
    public class ProductImageInfo
    {
        //主图列表，需先使用图片上传接口上传图片
        public string[] images { get; set; }
        //是否打水印，是(true)或否(false)，1688无需关注此字段，1688的水印信息在上传图片时处理
        public bool isWatermark { get; set; }
        //水印是否有边框，有边框(true)或者无边框(false)，1688无需关注此字段，1688的水印信息在上传图片时处理
        public bool isWatermarkFrame { get; set; }
        //水印位置，在中间(center)或者在底部(bottom)，1688无需关注此字段，1688的水印信息在上传图片时处理
        public string watermarkPosition { get; set; }

    }
    //（微供）产品sku信息
    public class ProductSKUInfo
    {
        //SKU属性值，可填多组信息
        public ProductAttribute[] attributes { get; set; }
        //指定规格的货号，国际站无需关注
        public string cargoNumber { get; set; }
        //可销售数量，国际站无需关注
        public int amountOnSale { get; set; }
        //建议零售价，国际站无需关注
        public double retailPrice { get; set; }
        //报价时该规格的单价，国际站注意要点：含有SKU属性的在线批发产品设定具体价格时使用此值，若设置阶梯价格则使用priceRange
        public double price { get; set; }
        //阶梯报价，1688无需关注
        public ProductPriceRange[] priceRange { get; set; }
        //商品编码，1688无需关注
        public string skuCode { get; set; }
        //skuId, 国际站无需关注
        public long skuId { get; set; }
        //specId, 国际站无需关注
        public string specId { get; set; }


    }

    //(微供)商品属性和属性值
    public class ProductAttribute
    {
        //属性ID
        public long attributeID { get; set; }
        //属性名称
        public String attributeName { get; set; }
        //属性值ID
        // public long valueID { get; set; }
        //属性值
        public string value { get; set; }
        //是否为自定义属性，国际站无需关注
        public bool isCustom { get; set; }

    }
    //(微供)商品扩展信息
    public class ProductExtendInfo
    {
        //key
        public string key { get; set; }
        //value
        public string value { get; set; }
    }

    //商品销售信息，包含上传商品中跟销售相关的信息
    public class ProductSaleInfo
    {
        //是否支持网上交易。true：支持 false：不支持，国际站不需关注此字段
        public bool supportOnlineTrade { get; set; }

        //是否支持混批，国际站无需关注此字段
        public bool mixWholeSale { get; set; }
        //销售方式，按件卖(normal)或者按批卖(batch)，1688站点无需关注此字段
        public string saleType { get; set; }
        //是否价格私密信息，国际站无需关注此字段
        public bool priceAuth { get; set; }
        //区间价格。按数量范围设定的区间价格
        public ProductPriceRange[] priceRanges { get; set; }
        //可售数量，国际站无需关注此字段
        public double amountOnSale { get; set; }
        //计量单位
        public string unit { get; set; }
        //最小起订量，范围是1-99999。1688无需处理此字段
        public int minOrderQuantity { get; set; }
        //每批数量
        public int batchNumber { get; set; }
        //建议零售价，国际站无需关注
        public double retailprice { get; set; }
        //税率相关信息，内容由用户自定，国际站无需关注
        public string tax { get; set; }
        //售卖单位，如果为批量售卖，代表售卖的单位，例如1"手"=12“件"的"手"，国际站无需关注
        public string sellunit { get; set; }
        //普通报价
        public int quoteType { get; set; }

    }

    //(微供)商品价格区间
    public class ProductPriceRange
    {
        //
        public int startQuantity { get; set; }
        //
        public double price { get; set; }
    }
    //（微供）商品物流信息
    public class ProductShippingInfo
    {

        public long freightTemplateID { get; set; }
        public double unitWeight { get; set; }
        public string packageSize { get; set; }
        public int volume { get; set; }
        public int handlingTime { get; set; }
        public long sendGoodsAddressId { get; set; }

    }
    //（微供）商品国际贸易信息

    public class ProductInternationalTradeInfo
    {
        // 	FOB价格货币，参见FAQ 货币枚举值
        public string fobCurrency { get; set; }
        //FOB最小价格
        public string fobMinPrice { get; set; }
        //FOB最大价格
        public string fobMaxPrice { get; set; }
        //FOB计量单位，参见FAQ 计量单位枚举值
        public string fobUnitType { get; set; }
        //付款方式，参见FAQ 付款方式枚举值
        public string[] paymentMethods { get; set; }
        //最小起订量
        public int minOrderQuantity { get; set; }
        //最小起订量计量单位，参见FAQ 计量单位枚举值
        public string minOrderUnitType { get; set; }
        //supplyQuantity
        public int supplyQuantity { get; set; }
        //供货能力计量单位，参见FAQ 计量单位枚举值
        public string supplyUnitType { get; set; }
        //供货能力周期，参见FAQ 时间周期枚举值
        public string supplyPeriodType { get; set; }
        // 	发货港口
        public string deliveryPort { get; set; }
        //发货期限
        public string deliveryTime { get; set; }
        //新发货期限
        public int consignmentDate { get; set; }
        //常规包装
        public string packagingDesc { get; set; }

    }

    #endregion

}
