using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Authorization;

namespace ZyLob.Ali1688.Op.Tests.Authorization
{
    [TestClass]
    public class AuthApiTest
    {
        [TestMethod]
        public void GetAuthorizeUriTest()
        {
           var authUrl= AuthApi.GetAuthorizeUri("");
            int i = 1;
        }
        [TestMethod]
        public void GetAliTokenTest()
        {
            var authUrl = AuthApi.GetAliToken("25cf3c79-4296-4edb-a879-945cd8097c3a");
            int i = 1;
        }
    }
}
