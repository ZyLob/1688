using System;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 阿里接口异常基类
    /// </summary>
   public abstract class AliException : Exception
    {
       /// <summary>
       /// 阿里异常构造函数
       /// </summary>
       /// <param name="msgFormat">消息模版</param>
       /// <param name="paras">消息模版参数</param>
        public AliException(string msgFormat,params object[] paras):base(msgFormat.FormatStr(paras))
        {
            
        }
    }
   /// <summary>
   /// 阿里访问异常
   /// </summary>
   public sealed class AliAccessException : AliException
   {
       /// <summary>
        ///阿里异常构造函数
       /// </summary>
        /// <param name="url"> 请求地址</param>
       /// <param name="aliResult">阿里返回结果</param>
       /// <param name="message">消息</param>
       public AliAccessException(string url, string aliResult, string message)
           : base("1688接口访问异常! {2} 请求地址：{0} 阿里返回信息：{1}",url, aliResult, message)
        {
            
        }
   }
    /// <summary>
    /// 阿里口令异常
    /// </summary>
   public sealed class AliTokenException : AliException
    {
        /// <summary>
       /// 阿里权限异常构造函数
       /// </summary>
       /// <param name="apiName">接口名称</param>
        public AliTokenException(string apiName)
           : base("1688权限异常，{0}接口需要授权后才能使用，请先设置上下文中的访问口令 ",apiName)
       {

       }
    }
    /// <summary>
    /// 阿里接口输入参数异常
    /// </summary>
    public sealed class AliParamException : AliException
    {
         /// <summary>
       /// 阿里权限异常构造函数
       /// </summary>
        /// <param name="paraDesc">参数描述</param>
        public AliParamException(string paraDesc)
            : base("输入参数异常，{0}，请修正后重新调用 ", paraDesc)
       {

       }
    }
}
