using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Authorization;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests.Authorization
{
    [TestClass]
    public class AuthApiTest : TestBase
    {
        [TestMethod]
        public void GetAuthorizeUriTest()
        {
            var authUrl = AliContext.Static.Auth.GetAuthorizeUri("");
            
        }
        [TestMethod]
        public void GetAliTokenTest()
        {
            var authUrl = AliContext.Static.Auth.GetAliToken("25cf3c79-4296-4edb-a879-945cd8097c3a");
            
        }
    }
}
