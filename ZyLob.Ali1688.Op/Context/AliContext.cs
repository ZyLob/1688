using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Authorization;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Companys;
using ZyLob.Ali1688.Op.CustomClassify;
using ZyLob.Ali1688.Op.Models;
using ZyLob.Ali1688.Op.Product;

namespace ZyLob.Ali1688.Op.Context
{
    /// <summary>
    /// 阿里接口上下文
    /// </summary>
    public class AliContext
    {
        public AliContext(AliApply aliApply = null)
        {
            if (aliApply == null)
            {
                Config = ConfigurationManager.GetSection("AliApplyConfig") as AliApply;
            }
            else
            {
                Config = aliApply;                
            }
            Util = new ApiUtils(this);
            Auth=new AuthApi(this);
            Company = new CompanyApi(this);
            Product=new ProductApi(this);
            CustomClassify= new CustomClassifyApi(this);
        }
        /// <summary>
        /// 静态实例
        /// </summary>
        public static AliContext Static = new AliContext();

        public ApiUtils Util { get; set; }
        /// <summary>
        /// 阿里应用配置
        /// </summary>
        public AliApply Config { get; set; }
        /// <summary>
        /// 授权接口
        /// </summary>
        public AuthApi Auth { get; set; }
        /// <summary>
        /// 公司接口
        /// </summary>
        public CompanyApi Company { get; set; }
        /// <summary>
        /// 产品接口
        /// </summary>
        public ProductApi Product { get; set; }
        /// <summary>
        /// 自定义分类接口
        /// </summary>
        public CustomClassifyApi CustomClassify { get; set; }

    }
}
