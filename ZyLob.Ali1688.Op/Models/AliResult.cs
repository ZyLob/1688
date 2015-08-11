using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 阿里基础
    /// </summary>
    public class AliResult<T>
    {
        public T Result { get; set; }
    }
    /// <summary>
    /// 列表结果集
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AliResultList<T>
    {
        /// <summary>
        /// 请求是否成功返回
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>

        public int Total { get; set; }
        /// <summary>
        /// 请求异常时消息，当Success=false时有效
        /// </summary>

        public string Msg { get; set; }
        /// <summary>
        /// 结果对象，异常时为空
        /// </summary>
        public T ToReturn { get; set; }
    }
}
