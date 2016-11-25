using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Search
{
    [TestClass]
    public class SearchApiUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            AliContext.Static.Search.TitleStuffing("千品网供  自拍图   条纹双肩包", "1037006");
        }
    }
}
