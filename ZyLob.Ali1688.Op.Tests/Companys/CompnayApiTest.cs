using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Companys;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Companys
{
    [TestClass]
    public class CompnayApiTest : TestBase
    {
        [TestMethod]
        public void GetAliCompanyInfoTest()
        {
            AliContext.Static.AccessToken = "f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7";
            var compnay = AliContext.Static.Company.GetAliCompanyInfo("b2b-1623492085");
            var i = 1;
        }
    }
}
