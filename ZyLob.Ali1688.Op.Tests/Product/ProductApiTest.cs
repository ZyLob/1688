using System;
using System.Collections.Generic;
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
                OfferId = 521260330042,
                MemberId = "b2b-1623492085",
                PageSize = 50,
                Status = OfferStatus.Published,
                ReturnFields = "skuArray"
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
                OfferDetail = "详情增量修改测试"
            });
        }

        [TestMethod]
        public void OfferModifyStockTest()
        {
          // var result = AliContext.Static.Product.OfferModifyStock(521927009549, 200, new Dictionary<string, int>() { { "c2f485e135fb40c1e87c0a9393803ed4", 10 } });
            var result = AliContext.Static.Product.OfferModifyStock(521927009549, 200);

        }
        

    }
}
