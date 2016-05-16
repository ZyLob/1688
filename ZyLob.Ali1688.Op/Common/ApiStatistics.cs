using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 接口统计
    /// </summary>
  public  static class ApiStatistics
    {
        static ApiStatistics()
        {
            SendCounts = new Dictionary<string, long>();
        }
        /// <summary>
        /// 成功发送请求数
        /// </summary>
        public static Dictionary<string,long> SendCounts { get;private set; }
        /// <summary>
        /// 发送记录
        /// </summary>
        internal static void SendRecord()
        {
            var nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (!SendCounts.ContainsKey(nowDate))
            {
                SendCounts.Add(nowDate,0);
            }
            SendCounts[nowDate]++;
        }
    }
}
