using System.Collections.Generic;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Authorization
{
    /// <summary>
    /// 1688授权Api
    /// </summary>
    public class AuthApi
    {
        private readonly AliContext _context;

        public AuthApi(AliContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取授权地址
        /// </summary>
        /// <param name="redirectUri">可选,回调地址 默认使用配置地址</param>
        /// <param name="state">自定义参数，回跳到redirectUri时，会原样返回</param>
        /// <returns>授权地址</returns>
        public string GetAuthorizeUri(string redirectUri="", string state = "")
        {
            if (redirectUri.IsNullOrWhiteSpace())
            {
                redirectUri = _context.Config.RedirectUri;
            }
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("client_id", _context.Config.AppKey);
            otherParas.Add("site", _context.Config.Site);
            otherParas.Add("redirect_uri", redirectUri);
            otherParas.Add("state", state);
            _context.Util.AddAliApiUrlSignPara("", otherParas);
            string paraStr = _context.Util.GetUriParametersString(otherParas);
            return "http://gw.open.1688.com/auth/authorize.htm?{0}".FormatStr(paraStr);
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="code">必填 授权完成后返回的一次性令牌，code有效期（2分钟）或者已经使用code获取了一次令牌，code都将失效，需要返回重新获取code返回令牌 </param>
        /// <param name="needRefreshToken">是否需要返回refresh_token，如果返回了refresh_token，原来获取的refresh_token也不会失效，除非超过半年有效期。默认为True</param>
        /// <param name="grantType">授权类型，默认为authorization_code</param>
        /// <returns>令牌信息(Json) 说明：resource_owner为登录id，memberId为会员接口id，aliId为阿里巴巴集团统一的id，uid在查询订单等场景时需要使用，具体见相关api入参；refresh_token_timeout表示refreshToken的过期时间</returns>
        public  AliAuthToken GetAliToken(string code, bool needRefreshToken = true, string grantType = "authorization_code")
        {
            string url = "https://gw.open.1688.com/openapi/http/1/system.oauth2/getToken/{0}".FormatStr(_context.Config.AppKey);
            var paras = new Dictionary<string, string>
            {
                {"code", code},
                {"need_refresh_token", needRefreshToken.ToString().ToLower()},
                {"grant_type", grantType},
                {"client_id", _context.Config.AppKey},
                {"client_secret", _context.Config.SecretKey},
                {"redirect_uri", _context.Config.RedirectUri}
            };
            return _context.Util.Send<AliAuthToken>(url, paras);
        }

        /// <summary>
        /// 更新存取令牌
        /// </summary>
        /// <param name="refreshToken">更新令牌 如果refreshToken有效并且accessToken已经过期（超过10小时），那么可以使用refresh_token换取access_token，不用重新进行授权，然后访问用户隐私数据。
        ///如果refreshToken已经超过了半年的有效期，用户修改密码，用户订购到期或者用户通过取消授权工具取消了对app的授权，那么都需要用户重新授权获取refreshToken</param>
        /// <returns>新存取令牌</returns>
        public  AliAuthToken UpdateAccessToken(string refreshToken)
        {
            string url = "https://gw.open.1688.com/openapi/http/1/system.oauth2/getToken/{0}".FormatStr(_context.Config.AppKey);
            var paras = new Dictionary<string, string>
            {
                {"client_id", _context.Config.AppKey},
                {"client_secret", _context.Config.SecretKey},
                {"refresh_token", refreshToken},
                {"grant_type","refresh_token"}
            };

            return _context.Util.Send<AliAuthToken>(url, paras);
        }

        /// <summary>
        /// 重新获取令牌
        /// </summary>
        /// <param name="accessToken">原存取令牌</param>
        /// <param name="refreshToken">更新令牌，如果refreshToken的有效期和当前时间的差值小于30天，那么调用此接口后当前使用的refreshToken失效，返回一个新的refreshToken</param>
        /// <returns>令牌信息(Json) 说明：resource_owner为登录id，memberId为会员接口id，aliId为阿里巴巴集团统一的id，uid在查询订单等场景时需要使用，具体见相关api入参；refresh_token_timeout表示refreshToken的过期时间</returns>
        public  AliAuthToken UpdateRefreshToken(string accessToken, string refreshToken)
        {
            string url = "https://gw.open.1688.com/openapi/param2/1/system.oauth2/postponeToken/{0}".FormatStr(_context.Config.AppKey);
            var paras = new Dictionary<string, string>
            {
                {"client_id", _context.Config.AppKey},
                {"client_secret", _context.Config.SecretKey},
                {"refresh_token", refreshToken},
                {"access_token",accessToken}
            };
            return _context.Util.Send<AliAuthToken>(url, paras);
        }


    }
}
