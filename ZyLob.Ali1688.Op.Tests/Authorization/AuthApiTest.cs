using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ZyLob.Ali1688.Op.Authorization;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Authorization
{
    public class RechargeRecordModel
    {
        /// <summary>
        /// 订单号 
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 订单标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 本次充值数量
        /// </summary>
        public int SmsQuantity { get; set; }
        /// <summary>
        /// 套餐名称
        /// </summary>
        public string SetMealName { get; set; }
        /// <summary>
        /// 支付宝交易号
        /// </summary>
        public string TradeNo { get; set; }
        /// <summary>
        /// 实收金额
        /// </summary>
        public long ReceiptAmount { get; set; }

        /// <summary>
        /// 支付时间
        /// </summary>
        public DateTime? GmtPayment { get; set; }
        /// <summary>
        /// 会员编号 （阿里会员使用AliId）
        /// </summary>
        public string UserId { get; set; }
    }
    [TestClass]
    public class AuthApiTest : TestBase
    {
        [TestMethod]
        public void GetAuthorizeUriTest()
        {
          var result=  JsonConvert.DeserializeObject<RechargeRecordModel>(
                "{\"OrderNo\":\"201701131720556735879\",\"Title\":\"会员营销, 2条短信套餐充值，价格0.01元\",\"SmsQuantity\":2,\"SetMealName\":\"测试套餐\",\"TradeNo\":\"2017011321001004420238661510\",\"ReceiptAmount\":10,\"GmtPayment\":\"\\/Date(1484299339097)\\/\",\"UserId\":\"b2b - 2814601228a3941\"}]");
            //var authUrl = AliContext.Static.Auth.GetAuthorizeUri(\"http://qn.ngrok.cc/auth?appkey=1022032", "web");

        }
        [TestMethod]
        public void GetAliTokenTest()
        {
            var authUrl = AliContext.Static.Auth.GetAliToken("25cf3c79-4296-4edb-a879-945cd8097c3a");
            
        }
    }
}
