using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 类目发布类型
    /// </summary>
    public enum CategoryTradeType
    {
        /// <summary>
        /// 产品
        /// </summary>
        product=1,
        /// <summary>
        /// 加工
        /// </summary>
        process=2,
        /// <summary>
        /// 代理
        /// </summary>
        agent=3,
        /// <summary>
        /// 合作
        /// </summary>
        cooperation=4,
        /// <summary>
        /// 商务服务
        /// </summary>
        business=5

    }
    /// <summary>
    /// 发布类目信息
    /// </summary>
   public class Category
    {
       /// <summary>
        /// 类目ID
       /// </summary>
       public long catsId { get; set; }
       /// <summary>
       /// 类目名称
       /// </summary>
       public string catsName { get; set; }
       /// <summary>
       /// 是否支持混批
       /// </summary>
        public bool supportMixWholesale { get; set; }
       /// <summary>
        /// 是否支持SPU
       /// </summary>
        public bool applySpu { get; set; }
       /// <summary>
        /// 是否支持SKU报价
       /// </summary>
        public bool supportSKUPrice { get; set; }
       /// <summary>
        /// 是否支持网上订购
       /// </summary>
        public bool supportOnlineTrade { get; set; }
        public bool batchPost { get; set; }
        public bool applyRealPrice { get; set; }
        public bool spuPriceExt { get; set; }
       /// <summary>
       /// 发布类型
       /// </summary>
       public CategoryTradeType tradeType { get; set; }
       /// <summary>
       /// 是否叶子类目
       /// </summary>
       public bool leaf { get; set; }
       /// <summary>
       /// 类目描述
       /// </summary>
       public string catsDescription { get; set; }
       /// <summary>
       /// 父类目数组，包含order与parentCatsId两个元素
       /// </summary>
       public List<ParentCategory> parentCats { get; set; }
      
    }

    public class ParentCategory
    {
         /// <summary>
       /// 父类目排序号
       /// </summary>
        public int order { get; set; }
       /// <summary>
       /// 父类目ID
       /// </summary>
        public int parentCatsId { get; set; }
    }
    /// <summary>
    /// 类目产品属性信息
    /// </summary>
    public class ProductAttributesInfo
    {
        /// <summary>
        /// 产品属性ID
        /// </summary>
        public long fid { get; set; }
        /// <summary>
        /// 产品属性单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 属性值ID
        /// </summary>
        public long[] valueIds { get; set; }
        /// <summary>
        /// 产品属性枚举值.当‘填写类型’为单选或者多选时，该变量有效。多个枚举值之间使用;号（半角分号）分隔
        /// </summary>
        public string[] values { get; set; }
        /// <summary>
        /// 填写输入的长度限制，比如‘30’。若无限制，则返回null
        /// </summary>
        public int? inputMaxLength { get; set; }
        /// <summary>
        /// 产品属性名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 填写类型枚举值。 -1: 数字输入框; 0: 文本输入框（input）;1=下拉（list_box）;2=多选（check_box）;3=单选（radio）
        /// </summary>
        public string showType { get; set; }
        /// <summary>
        /// 该属性是否为必填项。true：必填；false：非必填
        /// </summary>
        public bool required { get; set; }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int order { get; set; }
        /// <summary>
        /// 交易Flag
        /// </summary>
        public string fieldFlag { get; set; }
        /// <summary>
        /// 属性类型。0:产品属性 3:交易属性 5:SPU属性
        /// </summary>
        public string aspect { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string note { get; set; }
        /// <summary>
        /// Offer类型。2:供应
        /// </summary>
        public string offerType { get; set; }
        /// <summary>
        /// 引导文案
        /// </summary>
        public string precomment { get; set; }
        /// <summary>
        /// 默认的属性值ID
        /// </summary>
        public string defaultValueId { get; set; }
        /// <summary>
        /// 默认值
        /// </summary>
        public string defaultValue { get; set; }
        /// <summary>
        /// 类目ID
        /// </summary>
        public long categoryId { get; set; }
        /// <summary>
        /// 是否关键属性
        /// </summary>
        public bool keyAttr { get; set; }
        /// <summary>
        /// 是否规格属性
        /// </summary>
        public bool specAttr { get; set; }
        /// <summary>
        /// 是否输入建议框
        /// </summary>
        public bool suggestType { get; set; }
        /// <summary>
        /// 是否支持自定义属性
        /// </summary>
        public bool supportDefinedValues { get; set; }
        /// <summary>
        /// 是否是规格扩展属性（和规格属性相关的属性，目前包括：价格、可售数量、建议零售价、已售数量）
        /// </summary>
        public bool specExtendedAttr { get; set; }
    }
    /// <summary>
    ///类目属性信息
    /// </summary>
    public class CategoryFeature
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        public long fid { get; set; }
        /// <summary>
        /// 父属性id
        /// </summary>
        public long parentId { get; set; }
        /// <summary>
        /// 产品属性单位
        /// </summary>
        public string unit { get; set; }
       
   
        /// <summary>
        /// 属性名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 属性类别
        /// </summary>
        public string fieldType { get; set; }
       
       
        /// <summary>
        /// 属性排列顺序
        /// </summary>
        public int order { get; set; }

        public int inputType { get; set; }
        /// <summary>
        /// 是否必填
        /// </summary>
        public string isNeeded { get; set; }
        /// <summary>
        /// 是否关键属性
        /// </summary>
        public bool isKeyAttr { get; set; }
        /// <summary>
        /// 是否建议属性
        /// </summary>
        public bool isSuggestion { get; set; }
        /// <summary>
        /// 是否特殊属性
        /// </summary>
        public bool isSpecAttr { get; set; }
        /// <summary>
        /// 是否支持预定义值域
        /// </summary>
        public bool isSupportDefinedValues { get; set; }
        /// <summary>
        /// 是否支持扩展属性
        /// </summary>
        public bool isSpecExtendedAttr { get; set; }
        /// <summary>
        /// 是否图片属性
        /// </summary>
        public bool isSpecPicAttr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string featureType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string precomment { get; set; }
        /// <summary>
        /// 属性类型
        /// </summary>
        public int attrType { get; set; }
        /// <summary>
        /// 标准类型
        /// </summary>
        public string standardType { get; set; }
        /// <summary>
        /// 标准单位
        /// </summary>
        public string standardUnit { get; set; }
        /// <summary>
        /// 展示类型
        /// </summary>
        public int outputType { get; set; }
        /// <summary>
        /// 子属性id和值对
        /// </summary>
        public List<CategoryFeatureIdValue> featureIdValues { get; set; }
    }
    /// <summary>
    /// 类目属性键值对
    /// </summary>
    public class CategoryFeatureIdValue
    {
        /// <summary>
        /// 属性键
        /// </summary>
        public long vid { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string value { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CategoryFeatureResult
    {
        public List<CategoryFeature> categoryFeatures { get; set; }
    }
    /// <summary>
    /// SPU对象信息
    /// </summary>
    public class StandardSpuAttrValues
    {
        /// <summary>
        /// 属性ID
        /// </summary>
        public long fid { get; set; }
        /// <summary>
        /// 属性单位
        /// </summary>
        public string unit { get; set; }
        /// <summary>
        /// 属性值
        /// </summary>
        public string value { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 该属性是否为关键属性
        /// </summary>
        public bool key { get; set; }
    }
    /// <summary>
    /// 类目产品属性的SPU信息
    /// </summary>
    public class SpubyattributeResult
    {
        /// <summary>
        ///  SPU Id
        /// </summary>
        public long spuId { get; set; }
        /// <summary>
        ///  SPU对象信息
        /// </summary>
        public List<StandardSpuAttrValues> standardSpuAttrValues { get; set; }
    }
}
