using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Newtonsoft.Json;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 签名辅助
    /// </summary>
    public  class ApiUtils
    {
        private readonly AliContext _context;

        public ApiUtils(AliContext context)
        {
            _context = context;
           }

       
        /// <summary>
        /// 请求地址签名
        /// <param name="signDivisor">签名因子 具体规则详询 http://open.1688.com/doc/api/cn/sys_signature.htm?ns=cn.alibaba.open </param>
        /// </summary>
        public  string Sign(string signDivisor)
        {
            byte[] signatureKey = Encoding.UTF8.GetBytes(_context.Config.SecretKey);//此处用自己的签名密钥
            var hmacsha1 = new HMACSHA1(signatureKey);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(signDivisor));
            byte[] hash = hmacsha1.Hash;
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }
        /// <summary>
        /// 过滤空请求参数
        /// </summary>
        /// <param name="paras">请求参数</param>
        public  void ParameterFilter(Dictionary<string, string> paras)
        {
            var emptyKeys = paras.Where(kv => kv.Value.IsNullOrWhiteSpace()).Select(kv => kv.Key).ToList();
            foreach (var emptyKey in emptyKeys)
            {
                paras.Remove(emptyKey);
            }
        }
        /// <summary>
        /// 拼接参数窜
        /// </summary>
        /// <param name="parameters">参数集合</param>
        /// <returns>参数窜</returns>
        public  string GetUriParametersString(Dictionary<string, string> parameters)
        {
            var paraString = new StringBuilder();
            foreach (var para in parameters)
            {
                paraString.AppendFormat("&{0}={1}", para.Key, para.Value);

            }
            return paraString.ToString().Substring(1);
        }
        /// <summary>
        /// 添加阿里接口地址签名参数
        /// </summary>
        /// <param name="url">url 中的一部分，我们称之为urlPath，从协议（param2）开始截取，到“?”为止</param>
        /// <param name="paras">请求参数</param>
        public  void AddAliApiUrlSignPara( string url, Dictionary<string, string> paras)
        {
            string signDivisor = "";
            if (url.IsNotNullOrEmpty())
            {
                var startIndex = url.IndexOf("param2", System.StringComparison.Ordinal);
                signDivisor = url.Substring(startIndex);
            }
            ParameterFilter(paras);
            List<string> paraList = paras.Where(kv => kv.Value.IsNotNullOrEmpty()).Select(kv => kv.Key + kv.Value).ToList();
            paraList.Sort();
            foreach (string kvstr in paraList)
            {
                signDivisor += kvstr;
            }
            string signCode = Sign(signDivisor);
            paras.Add("_aop_signature", signCode);
        }

        /// <summary>
        /// 发送接口请求
        /// </summary>
        /// <param name="url">接口模块名称</param>
        /// <param name="parameters">参数集合</param>
        /// <param name="isTolerance">是否支持容错</param>
        /// <returns>请求结果信息</returns>
        public T Send<T>(string url, Dictionary<string, string> parameters,bool isTolerance=true)
        {

            var wuHelp = new WebUtils();
            //默认超时时间为15秒
            wuHelp.Timeout = _context.Timeout*1000;
            var memberPrivateData = "";
            int wrongCount = 0;
            do
            {
                try
                {
                    memberPrivateData = wuHelp.DoPost(url, parameters);
                    if (typeof(T).FullName=="System.String")
                    {
                        return (T)Convert.ChangeType(memberPrivateData, typeof(T));
                    }
                    ApiStatistics.SendRecord(_context.Config);
                    var result = JsonConvert.DeserializeObject<T>(memberPrivateData, new AliDatetimeJsonConverter());
                    if (result == null)
                    {
                        throw new AliAccessException(url, memberPrivateData, "解析阿里返回内容未匹配引发的异常");
                    }
                    return result;
                }
                catch (System.Exception ex)
                {
                    ApiStatistics.WrongRecord(_context.Config);
                    wrongCount++;
                    if (wrongCount >= AliContext.TolerateWrongCount || !isTolerance)
                        throw new AliAccessException(url, memberPrivateData, ex.Message);
                }
            } while (wrongCount < AliContext.TolerateWrongCount);

            throw new AliAccessException(url, memberPrivateData, "调用接口未知错误！");
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
