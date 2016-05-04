using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Classify
{
    [TestClass]
    public class CategoryApiTest : TestBase
    {
        [TestMethod]
        public void GetPostCatListTest()
        {
            var result = AliContext.Static.Category.GetPostCatList(1036558, 1036562);

        }
        [TestMethod]
        public void GetCatListByParentIdTest()
        {
            var result = AliContext.Static.Category.GetCatListByParentId(56);

        }
        [TestMethod]
        public void SearchTest()
        {
            var result = AliContext.Static.Category.Search("车");

        }
        [TestMethod]
        public void GetOfferPostFeaturesTest()
        {
            var result = AliContext.Static.Category.GetOfferPostFeatures(1033199);

        }
        [TestMethod]
        public void GetCatePathTest()
        {
            var result = AliContext.Static.Category.GetCatePath(1033199);

        }
        [TestMethod]
        public void GetCategoryAttrLevelTest()
        {
            var result = AliContext.Static.Category.GetCategoryAttrLevel(1031910, "100000691:46874>7108:21958");

        }
           [TestMethod]
        public void GetSpubyattributeTest()
        {
            var result = AliContext.Static.Category.GetSpubyattribute(1042627, "2176:BARDEN");

        }
        
    }
}
