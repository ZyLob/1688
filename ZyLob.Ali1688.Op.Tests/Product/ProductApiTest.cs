using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.Product
{
    [TestClass]
    public class ProductApiTest:TestBase
    {
        [TestMethod]
        public void ProductSeachTest()
        {
            var result = AliContext.Static.Product.ProductSeach(new ProductSeachModel()
            {
                Q="",
                MemberId = "b2b-1623492085",
                PageSize = 50,
                Status = OfferStatus.Published
            });
        }

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
        [TestMethod]
        public void OfferIncrementModifyTest()
        {
            var result = AliContext.Static.Product.OfferIncrementModify(new OfferIncrementAttr()
            {
                OfferId = 520527770328,
                Subject = "测试标题修改",
                OfferDetail="详情增量修改测试"
            });
        }

    }
}
