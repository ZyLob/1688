using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.PhotoAlbum
{
    [TestClass]
    public class PhotoApiTest
    {
        [TestMethod]
        public void GetPhotosTest()
        {
            var results = AliContext.Static.Photo.GetPhotos(12);
            int i = 1;
        }
    }
}
