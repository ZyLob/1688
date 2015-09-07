using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.CustomerRel
{
    [TestClass]
    public class CustomerRelApiTest:TestBase
    {
        [TestMethod]
        public void GetCustomerByTradeTest()
        {
            AliContext.Static.CustomerRelations.GetCustomerByTrade();
        }
        [TestMethod]
        public void GetCustomerByGroupTest()
        {
            AliContext.Static.CustomerRelations.GetCustomerByGroup(350004269);
        }
        [TestMethod]
        public void GetCustomerByLevelTest()
        {
            AliContext.Static.CustomerRelations.GetCustomerByLevel(CustomerLevel.所有的);
        }
        [TestMethod]
        public void GetGroupsTest()
        {
            AliContext.Static.CustomerRelations.GetGroups();
        }
    }
}
