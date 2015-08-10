using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 签名辅助
    /// </summary>
    public  class ApiUtils
    {
        /// <summary>
        /// 请求地址签名
        /// <param name="appSecret">签名密钥</param>
        /// <param name="signDivisor">签名因子 具体规则详询 http://open.1688.com/doc/api/cn/sys_signature.htm?ns=cn.alibaba.open </param>
        /// </summary>
        public static string Sign(string appSecret, string signDivisor)
        {
            byte[] signatureKey = Encoding.UTF8.GetBytes(appSecret);//此处用自己的签名密钥
            var hmacsha1 = new HMACSHA1(signatureKey);
            hmacsha1.ComputeHash(Encoding.UTF8.GetBytes(signDivisor));
            byte[] hash = hmacsha1.Hash;
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }
        /// <summary>
        /// 过滤空请求参数
        /// </summary>
        /// <param name="paras">请求参数</param>
        public static void ParameterFilter(Dictionary<string, string> paras)
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
        public static string GetUriParametersString(Dictionary<string, string> parameters)
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
        /// <param name="appSecret">签名密钥</param>
        /// <param name="urlPath">url 中的一部分，我们称之为urlPath，从协议（param2）开始截取，到“?”为止</param>
        /// <param name="paras">请求参数</param>
        public static void AddAliApiUrlSignPara(string appSecret, string urlPath, Dictionary<string, string> paras)
        {
            string signDivisor = urlPath;
            ParameterFilter(paras);
            List<string> paraList = paras.Where(kv => kv.Value.IsNotNullOrEmpty()).Select(kv => kv.Key + kv.Value).ToList();
            paraList.Sort();
            foreach (string kvstr in paraList)
            {
                signDivisor += kvstr;
            }
            string signCode = Sign(appSecret, signDivisor);
            paras.Add("_aop_signature", signCode);
        }
    }
}
