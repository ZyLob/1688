using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Product
{
    [TestClass]
    public class ProductApiTest:TestBase
    {
        [TestMethod]
        public void GetPublishOffersTest()
        {
           var result= AliContext.Static.Product.GetPublishOffers();
        }
        [TestMethod]
        public void GetAllOffersTest()
        {
            var result = AliContext.Static.Product.GetAllOffers();
        }
    }
}
