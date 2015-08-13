﻿using System;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 阿里授权令牌信息
    /// </summary>
    public class AliAuthToken
    {
        /// <summary>
        /// 阿里巴巴集团统一的id
        /// </summary>
        public string AliId { get; set; }
        /// <summary>
        /// 登录帐号
        /// </summary>

        public string Resource_Owner { get; set; }
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public int Expires_In { get; set; }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        public string Refresh_Token { get; set; }
        /// <summary>
        ///  刷新令牌的过期时间
        /// </summary>
        public DateTime Refresh_Token_Timeout { get; set; }
        /// <summary>
        /// 访问令牌
        /// </summary>

        public string Access_Token { get; set; }

    }
}
