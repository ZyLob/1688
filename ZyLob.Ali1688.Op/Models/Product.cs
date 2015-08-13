using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

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
        public string Type { get; set; }
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
        //单位重量
        public long ProductUnitWeight { get; set; }
        /// <summary>
        /// T:运费模板 D：运费说明 F：卖家承担运费
        /// </summary>
        public long FreightType { get; set; }
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
   /// 产品属性
   /// </summary>
    public class SkuInfo
    {
        public long Fid { get; set; }
        public string Value { get; set; }
        public List<SkuDetail> Children { get; set; }

    }
    /// <summary>
    /// 产品属性值
    /// </summary>
    public class SkuDetail
    {
        public long Fid { get; set; }
        public string RetailPrice { get; set; }
        public string Price { get; set; }
        public int CanBookCount { get; set; }
        public string CargoNumber { get; set; }
        public string SpecId { get; set; }
        public string Value { get; set; }
        public int SaleCount { get; set; }

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
        public string OfferId { get; set; }

        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime GmtExpire { get; set; }

        /// <summary>
        /// 重发时间
        /// </summary>
        public DateTime GmtRepublished { get; set; }
    }
}
