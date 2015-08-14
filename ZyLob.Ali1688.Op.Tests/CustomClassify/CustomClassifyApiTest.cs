using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.CustomClassify
{
    [TestClass]
    public class CustomClassifyApiTest
    {
        [TestMethod]
        public void GetCustomClassifysTest()
        {
           var classifys= AliContext.Static.CustomClassify.GetCustomClassifys("b2b-1623492085");
            int i = 1;
        }
        [TestMethod]
        public void SetOfferGroupTest()
        {
            var isSuccess = AliContext.Static.CustomClassify.SetOfferGroup("7df64306-812f-48ca-ab67-a0b2c8699205", OfferGroupSwitchType.On);
            int i = 1;
        }
        [TestMethod]
        public void HasOpenedTest()
        {
            var isSuccess = AliContext.Static.CustomClassify.HasOpened("b2b-1623492085");
            int i = 1;
        }
        
    }
}
