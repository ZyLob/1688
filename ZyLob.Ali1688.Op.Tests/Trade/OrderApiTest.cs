using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.Trade
{
    [TestClass]
    public class OrderApiTest:TestBase
    {
        [TestMethod]
        public void OrderSearchTest()
        {
           var results= AliContext.Static.Order.OrderSearch(new OrderSeachModel
            {
                SellerMemberId = "b2b-1623492085"
            });
        }
          [TestMethod]
        public void GetOrderDetailTest()
         {
             var results = AliContext.Static.Order.GetOrderDetail(1170259893000799);
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
               paras.Add(1170259893000799,new OrderEvaluateModel[]{ new OrderEvaluateModel()
               {
                   Content = "好",
                   StarLevel = 5
               }});
               paras.Add(1145809440038108,new OrderEvaluateModel[]{  new OrderEvaluateModel()
               {
                   Content = "好",
                   StarLevel = 5
               }});
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
