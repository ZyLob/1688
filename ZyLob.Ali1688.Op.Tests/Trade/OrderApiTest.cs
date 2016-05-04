using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.Trade
{
    [TestClass]
    public class OrderApiTest : TestBase
    {
        [TestMethod]
        public void OrderSearchTest()
        {
            bool isLoadNext = true;
            int page = 3;
            do
            {
                try
                {
                    var results = AliContext.Static.Order.OrderSearch(new OrderSeachModel
                    {
                        ModifyStartTime = DateTime.MinValue,
                        OrderStatusEnum = OrderStatus.SUCCESS,
                        SellerRateStatus=EvaluateStatus.已评论,
                        PageSize = 50,
                        SellerMemberId = "b2b-2262433538",
                        Page = page
                        
                    });
                    isLoadNext = results.HasNextPage;
                    page++;
                }
                catch (Exception ex)
                {

                }

            } while (isLoadNext);
            
        }
        [TestMethod]
        public void GetOrderDetailTest()
        {
            var results = AliContext.Static.Order.GetOrderDetail(1276650775832295);
        }
        [TestMethod]
        public void GetWholesaleSettingTest()
        {
            var results = AliContext.Static.Order.GetWholesaleSetting();
        }
        [TestMethod]
        public void TradeSearchTest()
        {
            var results = AliContext.Static.Order.TradeSearch(new TradeSeachModel()
            {
                OrderStatus = TradeStatus.success,
                SellerMemberId = "b2b-1623492085"
            });
        }
        [TestMethod]
        public void GetTradeDetailTest()
        {
            var results = AliContext.Static.Order.GetTradeDetail(1170259893000799);
        }
        [TestMethod]
        public void OrderEvaluateTest()
        {
            var paras = new Dictionary<long, OrderEvaluateModel[]>();
            paras.Add(1431896000890216, new OrderEvaluateModel[]{ new OrderEvaluateModel()
               {
                   Content = "亲，您的好评是对我们最大的支持和鼓励，我们将努力做得更好！记得收藏我们的店铺哦，同时期待您再次光临本店！",
                   StarLevel = 5
               }});
            //paras.Add(1280186152417889, new OrderEvaluateModel[]{  new OrderEvaluateModel()
            //   {
            //       Content = "亲，您的好评是对我们最大的支持和鼓励，我们将努力做得更好！记得收藏我们的店铺哦，同时期待您再次光临本店！",
            //       StarLevel = 5
            //   }});
            var results = AliContext.Static.Order.OrderEvaluate(paras);
        }
        [TestMethod]
        public void ModifyOrderPriceTest()
        {
            var results = AliContext.Static.Order.ModifyOrderPrice(998161929759811, 200, new ModifyOrderPriceDetail[]{new ModifyOrderPriceDetail()
             {
                 Id =998161929759811,
                 Discount = 20
             }});
        }


    }

}
