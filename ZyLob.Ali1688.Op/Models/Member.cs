using System;
using System.Collections.Generic;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 会员详细信息
    /// </summary>
    public class AliMemberInfo
    {
        /// <summary>
        /// 阿里会员ID
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 会员状态
        /// </summary>
        public AliMemberStatus Status { get; set; }

        /// <summary>
        /// 会员账户类型。true：诚信通会员；false：免费账户会员
        /// </summary>
        public bool IsTp { get; set; }

        /// <summary>
        /// 是否开通了网站。true：已开通；false：未开通
        /// </summary>
        public bool HaveSite { get; set; }

        /// <summary>
        /// 是否个人诚信通。true：个人诚信通会员；false：非个人诚信通会员
        /// </summary>
        public bool IsPersonalTp { get; set; }

        /// <summary>
        /// 是否企业诚信通。true：企业诚信通会员；false：非企业诚信通会员
        /// </summary>
        public bool IsEnterpriseTp { get; set; }

        /// <summary>
        /// 是否专业市场诚信通会员。true：专业市场诚信通会员；false：非专业市场诚信通会员
        /// </summary>
        public bool IsMarketTp { get; set; }

        /// <summary>
        /// 是否ETC会员。true：ETC海外诚信通会员；false：非ETC海外诚信通会员
        /// </summary>
        public bool IsEtctp { get; set; }

        /// <summary>
        /// 会员是否具有开通分销平台资格。true：具有分销平台资格；false：没有分销平台资格
        /// </summary>
        public bool HaveDistribution { get; set; }

        /// <summary>
        /// 会员是否已经开通分销平台。true：已开通；false：未开通
        /// </summary>
        public bool IsDistribution { get; set; }

        /// <summary>
        /// 是否绑定了手机登录。true：是；false：否
        /// </summary>
        public bool IsMobileBind { get; set; }

        /// <summary>
        /// 是否绑定了Email登录。true：是；false：否
        /// </summary>
        public bool IsEmailBind { get; set; }

        /// <summary>
        /// 是否具有预存款的权限。true：具有预存款权限；false：没有预存款权限
        /// </summary>
        public bool HavePrecharge { get; set; }

        /// <summary>
        /// 是否已经开通预存款服务。true：已开通；false：未开通
        /// </summary>
        public bool IsPrecharge { get; set; }

        /// <summary>
        /// 是否参加诚信保障。true：参加诚信保障；false：没有参加诚信保障
        /// </summary>
        public bool IsCreditProtection { get; set; }

        /// <summary>
        /// 是否已发布公司库。true：已发布；false：未发布
        /// </summary>
        public bool IsPublishedCompany { get; set; }

        /// <summary>
        /// 是否绑定支付宝账户。true：已经绑定了支付宝；false：没有绑定支付宝
        /// </summary>
        public bool IsAlipayBind { get; set; }

        /// <summary>
        /// 会员档案地址
        /// </summary>
        public string PersonalFileAddress { get; set; }

        /// <summary>
        /// 商铺地址
        /// </summary>
        public string WinportAddress { get; set; }

        /// <summary>
        /// 旺铺地址
        /// </summary>
        public string DomainAddress { get; set; }

        /// <summary>
        /// 诚信通指数。只有TP会员才有效
        /// </summary>
        public int TrustScore { get; set; }

        /// <summary>
        /// 诚信档案地址。只有TP会员才有效
        /// </summary>
        public string TrustProductAddress { get; set; }
        /// <summary>
        /// 公司库地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最近登录时间
        /// </summary>
        public DateTime LastLogin { get; set; }

        /// <summary>
        /// 公司信息-公司名称 
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司信息-主营行业
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// 公司信息-主营产品
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// 公司信息-网页地址
        /// </summary>
        public string HomepageUrl { get; set; }

        /// <summary>
        /// 联系信息-姓名
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// 联系信息-性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 联系信息-部门
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// 联系信息-职位
        /// </summary>
        public string OpenJobTitle { get; set; }

        /// <summary>
        /// 联系信息-电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系信息-司电话
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 联系信息-传真
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// 联系信息-手机
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 联系信息-所在地信息
        /// </summary>
        public AddressLocation AddressLocation { get; set; }
    }

    /// <summary>
    /// 所在地信息
    /// </summary>
    public class AddressLocation
    {
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
    }
    /// <summary>
    /// 阿里会员诚信信息
    /// </summary>
    public class AliMemberIntegrityInfo
    {
        /// <summary>
        /// 诚信通会员年数
        /// </summary>
        public int TpYear { get; set; }
        /// <summary>
        /// 诚信通logo
        /// </summary>
        public string TpLogo { get; set; }

        /// <summary>
        /// 阿里认证信息集合
        /// </summary>
        public List<AliAuthInfo> AuthInfos { get; set; }

        /// <summary>
        /// 诚信通类型
        /// </summary>
        public string TpType { get; set; }

        /// <summary>
        /// 保障金
        /// </summary>
        public double CreditBalanceMoney { get; set; }
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string MemberId { get; set; }
    }
    /// <summary>
    /// 阿里认证信息
    /// </summary>
    public class AliAuthInfo
    {
        /// <summary>
        /// 认证通过日期
        /// </summary>
        public DateTime AuthPassDate { get; set; }
        /// <summary>
        /// 认证类型
        /// </summary>
        public string Type { get; set; }
    }

}
