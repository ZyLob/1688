using System;
using System.Text.RegularExpressions;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 字符串操作帮助类
    /// </summary>
    public class StrUtils
    {
        const string RegSafeSql = @"[^\S]{+}delete[^\S]{1}|[^\S]{+}drop[^\S]{1}|[^\S]{+}update[^\S]{1}|[^\S]{+}truncate[^\S]{1}|[^\S]{+}create[^\S]{1}|[^\S]{+}xp_cmdshell[^\S]{1}|[^\S]{+}insert[^\S]{1}|[^\S]{+}--[^\S]{1}";


        /// <summary>
        /// SQL 特殊字符过滤,防SQL注入
        /// </summary>
        /// <param name="contents">过滤文本内容</param>
        /// <returns>过滤结果</returns>
        public static string SqlFilter(string contents)
        {
            if (Regex.IsMatch(contents.ToLower(), RegSafeSql, RegexOptions.IgnoreCase))
            {
                contents = Regex.Replace(contents.ToLower(), RegSafeSql, " ", RegexOptions.IgnoreCase);
            }
            return contents;
        }

        #region 验证

        /// <summary>
        /// 检查字符串是否能转为日期
        /// </summary>
        /// <param name="value">验证的字符串</param>
        /// <returns></returns>
        public static bool IsStringDate(string value)
        {
            DateTime time;

            if (DateTime.TryParse(value, out time))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///检查字符串是否是纯数字构成
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        /// <summary>
        /// 检查字符串是否由字符和数字构成
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsLetterOrNumber(string value)
        {
            return Regex.IsMatch(value, @"^[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 检查字符串是否是数字，包含小数和整数
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            return Regex.IsMatch(value, @"^(0|([1-9]+[0-9]*))(.[0-9]+)?$");
        }

        /// <summary>
        /// 检查字符串是否是邮件
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsEmail(string value)
        {
            return Regex.IsMatch(value, @"^\w+([-+.]\w+)*@(\w+([-.]\w+)*\.)+([a-zA-Z]+)+$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 检查字符串是否为手机号码
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsMobile(string value)
        {
            return Regex.IsMatch(value, @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|2|3|5|6|7|8|9])\d{8}$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 检查字符串是否为电话号码
        /// </summary>
        /// <param name="value">需要验证的字符串</param>
        /// <returns></returns>
        public static bool IsTelephone(string value)
        {
            return Regex.IsMatch(value, @"^(86)?(-)?(0\d{2,3})?(-)?(\d{7,8})(-)?(\d{3,5})?$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 检查日期是否过期
        /// </summary>
        /// <param name="myDate">检查的日期</param>
        /// <returns>过期返回True，</returns>
        public static bool ValidDate(string myDate)
        {
            return CompareDate(myDate, DateTime.Now.ToShortDateString()) < 0;
        }

        #endregion
        /// <summary>
        /// 把字符串转为日期
        /// </summary>
        /// <param name="value">转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime StrToDate(string value, DateTime defaultValue)
        {
            if (!IsStringDate(value))
            {
                return defaultValue;
            }
            return DateTime.Parse(value);
        }

        /// <summary>
        /// 把字符串转为整型
        /// </summary>
        /// <param name="value">转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int StrToInt(string value, int defaultValue)
        {
            int returnValue;

            if (int.TryParse(value, out returnValue))
            {
                return returnValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// 把字符串转为Double类型
        /// </summary>
        /// <param name="value">转换字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static double StrToDouble(string value, double defaultValue)
        {
            double returnValue;

            if (double.TryParse(value, out returnValue))
            {
                return returnValue;
            }

            return defaultValue;
        }

        /// <summary>
        /// 比较两个时间的大小
        /// </summary>
        /// <param name="firstDate">第一个日期</param>
        /// <param name="secondDate">第二个日期</param>
        /// <returns>返回：0-相等 1-大于 -1-小于</returns>
        public static int CompareDate(string firstDate, string secondDate)
        {
            DateTime dtime1;
            DateTime dtime2;

            if (DateTime.TryParse(firstDate, out dtime1))
            {
                throw new Exception(firstDate + "不是有效的DateTime");
            }

            if (DateTime.TryParse(secondDate, out dtime2))
            {
                throw new Exception(secondDate + "不是有效的DateTime");
            }

            TimeSpan ts = dtime1 - dtime2;

            return ts.TotalDays.CompareTo(0);
        }

        /// <summary>
        /// 字符串数组转换整型数组
        /// </summary>
        /// <param name="arrStr">字符串数组</param>
        /// <returns></returns>
        public static int[] StrToIntArray(string[] arrStr)
        {
            if (arrStr != null)
            {
                var arrInt = new int[arrStr.Length];
                for (int i = 0; i < arrStr.Length; i++)
                {
                    arrInt[i] = Convert.ToInt32(arrStr[i]);
                }
                return arrInt;
            }
            return null;
        }

        /// <summary>
        /// 字符串数组转换Double数组
        /// </summary>
        /// <param name="arrStr">字符串数组</param>
        /// <returns></returns>
        public static double[] StrToDoubleArray(string[] arrStr)
        {
            if (arrStr != null)
            {
                var arrDouble = new double[arrStr.Length];
                for (int i = 0; i < arrStr.Length; i++)
                {
                    arrDouble[i] = Convert.ToDouble(arrStr[i]);
                }
                return arrDouble;
            }
            return null;
        }

        #region html特殊字符互转

        /// <summary>
        /// 替换html中的特殊字符
        /// </summary>
        /// <param name="theString">需要进行替换的文本。</param>
        /// <returns>替换完的文本。</returns>
        public static string HtmlEncode(string theString)
        {
            string htmlStr;
            if (!string.IsNullOrEmpty(theString))
            {
                theString = theString.Replace(">", "&gt;");
                theString = theString.Replace("<", "&lt;");
                theString = theString.Replace("  ", " &nbsp;");
                theString = theString.Replace("\"", "&quot;");
                theString = theString.Replace("'", "&#39;");
                theString = theString.Replace("\r\n", "<br/> ");
                htmlStr = theString;
            }
            else
            {
                htmlStr = theString;
            }
            return htmlStr;
        }

        /// <summary>
        /// 恢复html中的特殊字符
        /// </summary>
        /// <param name="theString">需要恢复的文本。</param>
        /// <returns>恢复好的文本。</returns>
        public static string HtmlDecode(string theString)
        {
            string htmlStr;
            if (!string.IsNullOrEmpty(theString))
            {
                theString = theString.Replace("&gt;", ">");
                theString = theString.Replace("&lt;", "<");
                theString = theString.Replace("&nbsp;", "  ");
                theString = theString.Replace("&amp;nbsp;", "  ");
                theString = theString.Replace("&quot;", "\"");
                theString = theString.Replace("&#39;", "'");
                theString = theString.Replace("<br/> ", "\r\n");
                htmlStr = theString;
            }
            else
            {
                htmlStr = theString;
            }
            return htmlStr;
        }

        #endregion

        #region 去除HTML标记

        /// <summary>   
        /// 去除HTML标记   
        /// </summary>   
        /// <param name="htmlstring">包括HTML的源码</param>
        /// <returns>已经去除后的文字</returns>   
        public static string NoHtml(string htmlstring)
        {

            if (string.IsNullOrEmpty(htmlstring))
            {
                return string.Empty;
            }
            //删除脚本
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            //Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&ldquo;", "“", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&rdquo;", "”", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            htmlstring = htmlstring.Replace("<", "&lt;");
            htmlstring = htmlstring.Replace(">", "&gt;");
            return htmlstring;
        }

        /// <summary>
        /// 替换所有html
        /// </summary>
        /// <param name="strContent">html文本</param>
        /// <param name="length">截取长度</param>
        /// <returns>替换后指定长度文本</returns>
        public static string RemoveHtml(string strContent, int length)
        {
            var htmlReg = new Regex(@"<[^>]+>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var htmlSpaceReg = new Regex("\\&nbsp;\\;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var spaceReg = new Regex("\\s{2,}|\\ \\;", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var styleReg = new Regex(@"<style(.*?)</style>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var scriptReg = new Regex(@"<script(.*?)</script>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            strContent = styleReg.Replace(strContent, string.Empty);
            strContent = scriptReg.Replace(strContent, string.Empty);
            strContent = htmlReg.Replace(strContent, string.Empty);
            strContent = htmlSpaceReg.Replace(strContent, " ");
            strContent = spaceReg.Replace(strContent, " ");

            return strContent.Length > length && length > 0 ? strContent.Trim().Substring(0, length) : strContent.Trim();
        }

        #endregion

        #region 分割字符
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">待分割的字符串</param>
        /// <param name="split">分割的字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string str, string split)
        {
            if (string.IsNullOrEmpty(str)) return new string[0];
            var splitArr = new[] { split };
            return str.Split(splitArr, StringSplitOptions.RemoveEmptyEntries);
        }
        /// <summary>
        /// 分割字符串
        /// </summary>
        /// <param name="str">待分割的字符串</param>
        /// <param name="split">分割的字符串</param>
        /// <returns></returns>
        public static string[] SplitString(string str, char split)
        {
            if (string.IsNullOrEmpty(str)) return new string[0];
            var splitArr = new[] { split };
            return str.Split(splitArr, StringSplitOptions.RemoveEmptyEntries);
        }
        #endregion

        
    }
}
