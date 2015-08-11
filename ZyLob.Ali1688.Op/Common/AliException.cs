using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 阿里接口异常
    /// </summary>
   public class AliException : Exception
    {
       public AliException(string url, string aliResult,string message)
           : base("1688接口访问异常! {2} 请求地址：{0} 阿里返回信息：{1}".FormatStr(url, aliResult, message))
        {
            
        }
    }
}
