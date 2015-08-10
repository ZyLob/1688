using System;
using System.Configuration;
using System.Xml;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 应用管理辅助
    /// </summary>
    public static class ApplyUtils
    {
        static ApplyUtils()
        {
            CurrApply = ConfigurationManager.GetSection("AliApplyConfig") as AliApply;
        }
        /// <summary>
        /// 自定义加载阿里应用配置函数
        /// </summary>
        static Func<AliApply> _loadApplyConfig = null;

        /// <summary>
        /// 应用配置信息
        /// </summary>
        static readonly AliApply CurrApply;
        /// <summary>
        /// 获取应用信息
        /// </summary>
        /// <returns>应用信息实例</returns>
        public static AliApply GetApply()
        {
            if (_loadApplyConfig != null)
            {
                return _loadApplyConfig();
            }
            return CurrApply;
        }
        /// <summary>
        /// 自定义加载应用配置信息
        /// 应用场景：一套程序多阿里应用集成时
        /// </summary>
        /// <param name="diyLoadApplyConfig">自定义加载阿里应用配置函数</param>
        public static void SetLoadApplyConfig(Func<AliApply> diyLoadApplyConfig)
        {
            _loadApplyConfig = diyLoadApplyConfig;
        }
    }

    /// <summary>
    /// 加载阿里应用配置
    /// </summary>
    public class AliApplyConfigHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            var applyInfo = new AliApply();
            foreach (XmlNode cNode in section.ChildNodes)
            {
                switch (cNode.Name.ToUpper())
                {
                    case "APPKEY":
                        applyInfo.AppKey = cNode.InnerText;
                        break;
                    case "SECRETKEY":
                        applyInfo.SecretKey = cNode.InnerText;
                        break;
                    case "SITE":
                        applyInfo.Site = cNode.InnerText;
                        break;
                    case "REDIRECTURI":
                        applyInfo.RedirectUri = cNode.InnerText;
                        break;
                }
            }
            return applyInfo;
        }
    }
}
