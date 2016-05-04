using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Trade
{
    [TestClass]
    public class LogisticsApiTest:TestBase
    {
        [TestMethod]
        public void GetLogisticsCompanysTest()
        {
            
            var results=AliContext.Static.Logistics.GetLogisticsCompanys();
        }
          [TestMethod]
        public void GetSendGoodsAddressesTest()
        {

            var results = AliContext.Static.Logistics.GetSendGoodsAddresses();
        }
           [TestMethod]
          public void GetLogisticsTemplatesTest()
        {

            var results = AliContext.Static.Logistics.GetLogisticsTemplates();
        }
        
    }
}
