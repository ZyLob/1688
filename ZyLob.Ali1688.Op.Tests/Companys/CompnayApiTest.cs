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
            var compnay = AliContext.Static.Company.GetAliCompanyInfo("b2b-1976248184");
            var i = 1;
        }
    }
}
