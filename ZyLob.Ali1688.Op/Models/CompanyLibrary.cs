using System.Collections.Generic;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 公司信息
    /// </summary>
    public class AliCompanyInfo
    {
        /// <summary>
        /// 会员ID
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 公司库ID
        /// </summary>
        public long CompanyId { get; set; }
        /// <summary>
        /// 公司库状态。Auditing：等待审核；FailAudited：审核未通过；Published：已发布
        /// </summary>
        public string CompanyStatus { get; set; }
        /// <summary>
        /// 公司基本信息（对于匿名访客和非本人登录会员：只有公司库状态处于发布状态才能返回，下同）-公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司基本信息-公司英文名
        /// </summary>
        public string CompanyNameEn { get; set; }
        /// <summary>
        /// 公司基本信息-企业类型
        /// </summary>
        public string LegalStatus { get; set; }
        /// <summary>
        /// 公司基本信息-经营模式
        /// </summary>
        public string BizModel { get; set; }
        /// <summary>
        /// 公司基本信息-主要经营地点
        /// </summary>
        public string BizPlace { get; set; }
        /// <summary>
        /// 公司基本信息-主营产品
        /// </summary>
        public string ProductionService { get; set; }
        /// <summary>
        /// 公司基本信息-主营行业
        /// </summary>
        public List<string> CompanyCategoryInfo { get; set; }
        /// <summary>
        /// 公司基本信息-公司简介
        /// </summary>
        public string Profile { get; set; }
        /// <summary>
        /// 公司基本信息-公司网址
        /// </summary>
        public string HomepageUrl { get; set; }
        /// <summary>
        /// 公司详细信息（对于匿名访客和非本人登录会员：只有公司库状态处于发布状态才能返回，下同）-注册资本
        /// </summary>
        public string RegCapital { get; set; }
        /// <summary>
        /// 公司详细信息-公司成立年份
        /// </summary>
        public string EstablishedYear { get; set; }
        /// <summary>
        /// 公司详细信息-公司注册地
        /// </summary>
        public string FoundedPlace { get; set; }
        /// <summary>
        /// 公司详细信息-法定代表人/负责人
        /// </summary>
        public string Principal { get; set; }
        /// <summary>
        /// 公司详细信息-开户银行
        /// </summary>
        public string Bank { get; set; }
        /// <summary>
        /// 公司详细信息-帐号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 公司详细信息-厂房面积
        /// </summary>
        public string FactorySize { get; set; }
        /// <summary>
        /// 公司详细信息-员工人数
        /// </summary>
        public string EmployeesCount { get; set; }
        /// <summary>
        /// 公司详细信息-研发部门人数
        /// </summary>
        public string RndStaffNum { get; set; }
        /// <summary>
        /// 公司详细信息-品牌名称
        /// </summary>
        public string BrandName { get; set; }
        /// <summary>
        /// 公司详细信息-月产量
        /// </summary>
        public string ProductionCapacity { get; set; }
        /// <summary>
        /// 公司详细信息-年营业额
        /// </summary>
        public string AnnualRevenue { get; set; }
        /// <summary>
        /// 公司详细信息-年进口额
        /// </summary>
        public string AnnualImportAmount { get; set; }
        /// <summary>
        /// 公司详细信息-年出口额
        /// </summary>
        public string AnnualExportAmount { get; set; }
        /// <summary>
        /// 公司详细信息-管理体系认证
        /// </summary>
        public string Certification { get; set; }
        /// <summary>
        /// 公司详细信息-质量控制
        /// </summary>
        public string QaQc { get; set; }
        /// <summary>
        /// 公司详细信息-主要市场
        /// </summary>
        public string TradeRegionInfo { get; set; }
        /// <summary>
        /// 公司详细信息-主要客户群
        /// </summary>
        public string KeyClients { get; set; }
        /// <summary>
        /// 公司详细信息-是否提供OEM代加工
        /// </summary>
        public string OemOdm { get; set; }

    }
}
