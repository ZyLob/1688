using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 应用配置信息
    /// </summary>
    public class AliApply
    {
        /// <summary>
        /// 应用配置信息初始化
        /// </summary>
        public AliApply()
        {
            this.Site = "china";
        }
        /// <summary>
        /// 应用配置信息初始化
        /// </summary>
        /// <param name="appKey">应用钥匙</param>
        /// <param name="secretKey">应用密钥</param>
        public AliApply(string appKey, string secretKey)
        {
            AppKey = appKey;
            SecretKey = secretKey;
            this.Site = "china";
        }
        /// <summary>
        /// 应用配置信息初始化
        /// </summary>
        /// <param name="appKey">应用钥匙</param>
        /// <param name="secretKey">应用密钥</param>
        /// <param name="redirectUri">回调地址</param>
        public AliApply(string appKey, string secretKey, string redirectUri)
        {
            RedirectUri = redirectUri;
            AppKey = appKey;
            SecretKey = secretKey;
            this.Site = "china";
        }
        /// <summary>
        /// 应用钥匙
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 应用密钥
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        ///  当前授权的站点，默认china
        /// </summary>
        public string Site { get; set; }
        /// <summary>
        ///  授权成功跳转到应用的地址，授权临时令牌会以queryString的形式跟在该url后返回
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
