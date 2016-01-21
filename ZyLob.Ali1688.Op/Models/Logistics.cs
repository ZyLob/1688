using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 物流公司模型
    /// </summary>
    public class LogisticsCompanyModel
    {
        /// <summary>
        /// 主键id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 是否支持打印
        /// </summary>
        public bool IsSupportPrint { get; set; }
        /// <summary>
        /// 物流公司编号
        /// </summary>
        public string CompanyNo { get; set; }
        /// <summary>
        /// 物流公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string CompanyPhone { get; set; }
    }
    /// <summary>
    /// 送货地址
    /// </summary>
    public class SendGoodsAddress
    {
        /// <summary>
        /// 标识
        /// </summary>
        public long DeliveryAddressId { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Mobilephone { get; set; }
        /// <summary>
        /// 是否是常用发货地址
        /// </summary>
        public bool IsCommonUse { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 省,市,县
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string ContactName { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string Postcode { get; set; }
    }
    /// <summary>
    /// 运费模板基础描述
    /// </summary>
    public class LogisticsTemplate
    {
        /// <summary>
        /// 运费模板ID
        /// </summary>
        public string templateId { get; set; }
        /// <summary>
        /// 运费模板名称
        /// </summary>
        public string templateName { get; set; }
        /// <summary>
        /// 发货省份名称
        /// </summary>
        public string fromProvinceName { get; set; }
        /// <summary>
        /// 发货城市名称
        /// </summary>
        public string fromCityName { get; set; }
        /// <summary>
        /// 发货区县名称
        /// </summary>
        public string fromCountyName { get; set; }
        /// <summary>
        /// 模板备注
        /// </summary>
        public string descn { get; set; }
        /// <summary>
        /// 包含服务类型，0为：快递，1为：货运，2为：COD
        /// </summary>
        public int[] serviceTypes { get; set; }
    }
}
