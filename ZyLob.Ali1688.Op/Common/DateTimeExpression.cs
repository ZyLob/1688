using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 日期扩展
    /// </summary>
    public static class DateTimeExpression
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
    /// <summary>
    /// 阿里api日期特殊处理
    /// </summary>
    public class AliDatetimeJsonConverter : IsoDateTimeConverter
    {
        #region Overrides of JsonConverter


        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var aliDateStr = reader.Value.ToString();
            if (aliDateStr.IsNullOrEmpty())
            {
                return DateTime.MinValue;
            }
            return DateTime.ParseExact(aliDateStr.Substring(0, 14), "yyyyMMddHHmmss", null);
        }

        #endregion
    }
}
