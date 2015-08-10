using System;
using System.Security.Cryptography;
using System.Text;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExpression
    {
        /// <summary>
        /// 将字符串转换为指定枚举类型
        /// </summary>
        public static TEnum ToEnum<TEnum>(this string str)
            where TEnum : struct
        {
            TEnum e;
            Enum.TryParse<TEnum>(str, out e);
            return e;
        }

        /// <summary>
        /// 判断字符串是否为Null或空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断字符串是否不为Null或空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullOrEmpty(this string str)
        {
            return !IsNullOrEmpty(str);
        }
        /// <summary>
        /// 转为整型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultInt">默认值</param>
        /// <returns></returns>
        public static int ToInt(this string str,int defaultInt)
        {           
            return StrUtils.StrToInt(str, defaultInt);
        }
        /// <summary>
        ///转为字符
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string ToStr(this string str)
        {
            if (str.IsNullOrEmpty())
            {
                return "";
            }
            return str;
        }
        /// <summary>
        /// 转为日期类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultDateTime"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str, DateTime defaultDateTime)
        {
            return StrUtils.StrToDate(str, defaultDateTime);
        }
        /// <summary>
        /// 转为日期类型
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string str)
        {
            return ToDateTime(str, DateTime.Now);
        }
        /// <summary>
        /// 转为双精度数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double ToDouble(this string str)
        {
            return StrUtils.StrToDouble(str, 0.00);
        }

        
        /// <summary>
        /// 转为整型
        /// </summary>
        /// <param name="str"></param>
        /// <remarks>转换失败时，默认为0</remarks>
        /// <returns></returns>
        public static int ToInt(this string str)
        {
            return StrUtils.StrToInt(str, 0);
        }

        /// <summary>
        /// 字符串分割
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split">分割的字符串</param>
        /// <returns></returns>
        public static string[] Split(this string str, string split)
        {
            return StrUtils.SplitString(str, split);
        }

        /// <summary>
        /// 字符串分割
        /// </summary>
        /// <param name="str"></param>
        /// <param name="split">分割的字符</param>
        /// <returns></returns>
        public static string[] Split(this string str, char split)
        {
            return StrUtils.SplitString(str, split);
        }
        /// <summary>
        /// 验证是否存在指定字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="existsStr">验证字符串</param>
        /// <returns>是否存在</returns>
        public static bool Exists(this string str, string existsStr)
        {
            if (str.IsNullOrEmpty() || existsStr.IsNullOrEmpty())
            {
                return false;
            }
            return str.Contains(existsStr);
        }
        
        /// <summary>
        /// 转换为MD5
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static string ToMd5(this string origin)
        {
            if (string.IsNullOrWhiteSpace(origin))
            {
                return string.Empty;
            }

            var md5Algorithm = MD5.Create();
            var utf8Bytes = Encoding.UTF8.GetBytes(origin);
            var md5Hash = md5Algorithm.ComputeHash(utf8Bytes);
            var hexString = new StringBuilder();
            foreach (var hexByte in md5Hash)
            {
                hexString.Append(hexByte.ToString("x2"));
            }
            return hexString.ToString();
        }
        /// <summary>
        /// 字符串格式化
        /// </summary>
        /// <param name="formatStr">字符串格式</param>
        /// <param name="args">站位参数</param>
        /// <returns>格式化字符串</returns>
        public static string FormatStr(this string formatStr, params object[] args)
        {
          return  string.Format(formatStr, args);
        }
    }
}
