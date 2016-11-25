using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Member
{
    [TestClass]
    public class MemberApiTest
    {
        [TestMethod]
        public void LoginIdToMemberIdTest()
        {
            var results = AliContext.Static.Member.LoginIdToMemberId("颖足鞋业", "缘顺食品", "聚美瑞工艺品");
        }

        [TestMethod]
        public void MemberIdToLoginIdTest()
        {
            var results = AliContext.Static.Member.MemberIdToLoginId("b2b-1116603396", "b2b-1707661449", "b2b-2258587003");
        }
        [TestMethod]
        public void GetMemberInfoTest()
        {
            var results = AliContext.Static.Member.GetMemberInfo("b2b-1712654535", "memberId,winportAddress,mobilePhone,sex,email,addressLocation");
        }
           [TestMethod]
        public void GetMemberIntegrityInfoTest()
        {
            var results = AliContext.Static.Member.GetMemberIntegrityInfo("b2b-1116603396", "b2b-1707661449", "b2b-2258587003");
        }
           [TestMethod]
           public void GetAreaCodeTest()
           {
               var results = AliContext.Static.Member.GetAreaCode();
           }
    }
}
