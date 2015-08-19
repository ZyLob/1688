using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.CustomClassify
{
    [TestClass]
    public class CustomClassifyApiTest : TestBase
    {
        [TestMethod]
        public void GetCustomClassifysTest()
        {
            var classifys = AliContext.Static.CustomClassify.GetCustomClassifys("b2b-1623492085");

        }
        [TestMethod]
        public void SetOfferGroupTest()
        {
            var isSuccess = AliContext.Static.CustomClassify.SetOfferGroup(OfferGroupSwitchType.On);

        }
        [TestMethod]
        public void HasOpenedTest()
        {
            var isSuccess = AliContext.Static.CustomClassify.HasOpened("b2b-1623492085");

        }
        [TestMethod]
        public void GetOffersClassifyTest()
        {
            var result = AliContext.Static.CustomClassify.GetOffersClassify(521260330042, 521257441833);

        }
        [TestMethod]
        public void AddProductClassifyTest()
        {
            var result = AliContext.Static.CustomClassify.AddProductClassify(47006017,521260330042, 521257441833);

        }
        [TestMethod]
        public void RemoveProductClassifyTest()
        {
            var result = AliContext.Static.CustomClassify.RemoveProductClassify(47006017,521260330042, 521257441833);

        }

    }
}
