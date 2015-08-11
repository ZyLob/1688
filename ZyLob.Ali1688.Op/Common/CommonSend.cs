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
        public static AliResult<T> Send<T>(string url, Dictionary<string, string> parameters)
        {
            var aliResult = new AliResult<T>();
            var wuHelp = new WebUtils();

            try
            {
                var memberPrivateData = wuHelp.DoPost(url, parameters);
                aliResult.IsSuccess = true;
                var result = JObject.Parse(memberPrivateData);
                if (result["result"] == null)
                {
                    return aliResult;
                }
                var complanys = result["result"]["toReturn"].ToObject<JArray>();
                aliResult.ToReturn = complanys.ToObject<T>();
                return aliResult;
            }
            catch (System.Exception ex)
            {
                aliResult.IsSuccess = false;
                aliResult.Msg = ex.Message;
            }
            return new AliResult<T>();
        }
    }
}
