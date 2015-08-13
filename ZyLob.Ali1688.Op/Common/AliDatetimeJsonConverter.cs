using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZyLob.Ali1688.Op.Common
{
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
