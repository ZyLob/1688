using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.ServicePlatform
{
    [TestClass]
    public class PlatformApiTest:TestBase
    {
        [TestMethod]
        public void GetSystemTimeTest()
        {
            var result= AliContext.Static.Platform.GetSystemTime();
        }
        [TestMethod]
        public void GetApplyOrdersByBeginDateTest()
        {
            var result = AliContext.Static.Platform.GetApplyOrdersByBeginDate(DateTime.Now, "");
        }
    }
}
