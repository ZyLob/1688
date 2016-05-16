using System;
using System.Collections.Generic;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 接口统计
    /// </summary>
  public  static class ApiStatistics
    {
        static ApiStatistics()
        {
            SendCounts = new Dictionary<string, StatisticsInfo>();
        }
        /// <summary>
        /// 成功发送请求数
        /// </summary>
        public static Dictionary<string, StatisticsInfo> SendCounts { get; private set; }
        /// <summary>
        /// 成功发送记录
        /// <param name="app">应用信息</param>
        /// </summary>
        internal static void SendRecord(AliApply app)
        {
            var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            var key = app.AppKey + nowDate;
            if (!SendCounts.ContainsKey(key))
            {
                SendCounts.Add(key, new StatisticsInfo() { AppKey = app.AppKey, Date = nowDate });
            }
            SendCounts[key].SendCount++;
        }
        /// <summary>
        /// 错误发送记录
        /// <param name="app">应用信息</param>
        /// </summary>
        internal static void WrongRecord(AliApply app)
        {
            var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            var key = app.AppKey + nowDate;
            if (!SendCounts.ContainsKey(key))
            {
                SendCounts.Add(key, new StatisticsInfo() { AppKey = app.AppKey, Date = nowDate });
            }
            SendCounts[key].WrongCount++;
        }
    }
    /// <summary>
    /// 统计信息
    /// </summary>
    public class StatisticsInfo
    {
        /// <summary>
        /// 统计日期
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// 应用钥匙
        /// </summary>
        public string AppKey { get; set; }
        /// <summary>
        /// 成功发送次数
        /// </summary>
        public long SendCount { get; set; }
        /// <summary>
        /// 错误次数
        /// </summary>
        public long WrongCount { get; set; }

    }
}
