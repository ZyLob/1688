using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Url
{
    [TestClass]
    public class UrlApiTest : TestBase
    {
        [TestMethod]
        public void GetBuyerOrderListUriTest()
        {
            var result = AliContext.Static.Url.GetBuyerOrderListUri();
        }
        [TestMethod]
        public void GetSellerOrderListUriTest()
        {
            var result = AliContext.Static.Url.GetSellerOrderListUri();
        }
        [TestMethod]
        public void GetOfferEditUriTest()
        {
            var result = AliContext.Static.Url.GetOfferEditUri(520525307433);
        }
    }
}
