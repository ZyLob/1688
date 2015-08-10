using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 日期扩展
    /// </summary>
  public   static class DateTimeExpression
    {
        /// <summary>
        /// 转阿里时间标准格式字符串
        /// </summary>
        /// <param name="currDateTime">要转换时间</param>
        /// <returns>阿里时间标准格式字符串</returns>
        public static string ToAliDate(this DateTime currDateTime)
        {
            return currDateTime.ToString("yyyyMMddHHmmssfffzzz").Replace(":", "");
        }
    }
}
