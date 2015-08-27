﻿using System;
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
         public void GetTradeDetailTest()
         {
             var results = AliContext.Static.Order.GetTradeDetail(1170259893000799);
         }
        
    }
    
}
