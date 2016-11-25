using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.Product
{
    [TestClass]
    public class ProductApiTest : TestBase
    {
        [TestMethod]
        public void ProductSeachTest()
        {
            var result = AliContext.Static.Product.ProductSeach(new ProductSeachModel()
            {
                Q = "",
                // OfferId = 521260330042,
                MemberId = "b2b-1623492085",
                PageSize = 50,
                OrderBy = "gmtexpire:desc",
                Status = OfferStatus.Published,
                ReturnFields = "offerId,subject,isSkuOffer,skuArray"
            });
        }

        [TestMethod]
        public void GetPublishOffersTest()
        {
            var result = AliContext.Static.Product.GetPublishOffers();
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

        [TestMethod]
        public void OfferRepostTest()
        {
            var result = AliContext.Static.Product.OfferRepost(522058408179);
        }
        
        [TestMethod]
        public void   OfferNewTest()
        {
            var model = new OfferNew();
            model.amountOnSale = 100;
            model.bizType = 1;
            model.categoryID = 1048305;
            model.freightTemplateId = 61;
            model.freightType = "F";
            model.mixWholeSale = true;
            model.supportOnlineTrade = true;
            model.subject = "测试产品，勿买";
            model.priceRanges = "1000:20`2000:19";
            model.sendGoodsAddressId = 7655580;
            model.priceAuthOffer = false;
            model.pictureAuthOffer = false;
            model.offerWeight = 0.5;
            var result = AliContext.Static.Product.OfferNew(model);
        }
        [TestMethod]
        public void OfferExpireTest()
        {
            var result = AliContext.Static.Product.OfferExpire(527115880487, 525423472366, 522836198359);
        }
        [TestMethod]
        public void IndustryShowwindowQueryTest()
        {
             var result = AliContext.Static.Product.IndustryShowwindowQuery();
        }
        [TestMethod]
        public void IndustryShowwindowDoRecommendOfferTest()
        {

            var result = AliContext.Static.Product.IndustryShowwindowDoRecommendOffer(38566790281);
        }
        [TestMethod]
        public void DoQueryRecommOfferListTest()
        {

            var result = AliContext.Static.Product.DoQueryRecommOfferList();
        }
        [TestMethod]
        public void IndustryShowwindowCancelRecommendOfferTest()
        {

            var result = AliContext.Static.Product.IndustryShowwindowCancelRecommendOffer(524638517261);
        }
        [TestMethod]
        public void OfferCanModifyTest()
        {

            var result = AliContext.Static.Product.OfferCanModify(539138716672, 537209493155);
        }

    }

    public class Tes
    {
        public DateTime Type { get; set; }
    }
}
