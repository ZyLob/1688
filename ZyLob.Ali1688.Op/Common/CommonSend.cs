using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Common
{

    public static class CommonSend
    {
        /// <summary>
        /// 发送接口请求
        /// </summary>
        /// <param name="url">接口模块名称</param>
        /// <param name="parameters">参数集合</param>
        /// <returns>请求结果信息</returns>
        public static T Send<T>(string url, Dictionary<string, string> parameters)
        {
           
            var wuHelp = new WebUtils();
            var memberPrivateData = "";
            try
            {
                 memberPrivateData = wuHelp.DoPost(url, parameters);
                var result = JObject.Parse(memberPrivateData);
                return result.ToObject<T>();
            }
            catch (System.Exception ex)
            {
                throw new AliException(url,memberPrivateData,ex.Message);
            }
        }
        
    }
}
