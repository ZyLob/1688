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
using ZyLob.Ali1688.Op.PhotoAlbum;
using ZyLob.Ali1688.Op.Product;
using ZyLob.Ali1688.Op.Url;

namespace ZyLob.Ali1688.Op.Context
{
    /// <summary>
    /// 阿里接口上下文
    /// </summary>
    public class AliContext
    {
        #region 构造函数
        /// <summary>
        /// 实例化阿里接口上下文
        /// </summary>
        public AliContext()
        {
            Init();
        }
        /// <summary>
        /// 实例化阿里接口上下文
        /// </summary>
        /// <param name="accessToken">阿里访问口令</param>
        public AliContext(string accessToken)
        {
            AccessToken = accessToken;
            Init();
        }
        /// <summary>
        /// 实例化阿里接口上下文
        /// </summary>
        /// <param name="aliApply">阿里应用配置</param>
        public AliContext(AliApply aliApply)
        {
            Config = aliApply;
            Init();
        }
        /// <summary>
        /// 实例化阿里接口上下文
        /// </summary>
        /// <param name="accessToken">阿里访问口令</param>
        /// <param name="aliApply">阿里应用配置</param>
        public AliContext(string accessToken, AliApply aliApply)
        {
            Config = aliApply;
            AccessToken = accessToken;
            Init();
        } 
        #endregion
        /// <summary>
        /// 初始化上下文
        /// </summary>
        private void Init()
        {
            if (Config == null)
            {
                Config = ConfigurationManager.GetSection("AliApplyConfig") as AliApply;
            }
            Util = new ApiUtils(this);
            Auth = new AuthApi(this);
            Company = new CompanyApi(this);
            Product = new ProductApi(this);
            CustomClassify = new CustomClassifyApi(this);
            Album = new AlbumApi(this);
            Photo = new PhotoApi(this);
            Url=new UrlApi(this);
        }
        /// <summary>
        /// 获取参数集合
        /// </summary>
        public Dictionary<string, string> GetParas()
        {
            var paras=new Dictionary<string, string>();
            if (AccessToken.IsNotNullOrEmpty())
            {
                paras.Add("access_token", AccessToken);
            }
            return paras;
        }
        /// <summary>
        /// 阿里访问口令
        /// </summary>
        public string  AccessToken { get; set; }
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
        /// <summary>
        /// 相册接口
        /// </summary>
        public AlbumApi Album { get; set; }
        /// <summary>
        /// 图片接口
        /// </summary>
        public PhotoApi Photo { get; set; }
        /// <summary>
        /// 地址接口
        /// </summary>
        public UrlApi Url { get; set; }

    }
}
