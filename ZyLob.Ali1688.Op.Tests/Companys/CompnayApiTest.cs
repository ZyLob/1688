using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Companys;

namespace ZyLob.Ali1688.Op.Tests.Companys
{
    [TestClass]
    public class CompnayApiTest
    {
        [TestMethod]
        public void GetAliCompanyInfoTest()
        {
          var compnay=  CompnayApi.GetAliCompanyInfo( "b2b-2080249682");
            var i = 1;
        }
    }
}
