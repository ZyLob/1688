using System;
using System.Drawing;
using System.IO;
using System.Net.Mime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.PhotoAlbum
{
    [TestClass]
    public class PhotoApiTest : TestBase
    {
        [TestMethod]
        public void GetPhotosTest()
        {
            var results = AliContext.Static.Photo.GetPhotos(160867213);

        }
        [TestMethod]
        public void GetTest()
        {
            var results = AliContext.Static.Photo.Get(2395679476);

        }
        [TestMethod]
        public void UploadPhotoTest()
        {
            var img = Image.FromFile("f:\\1.jpg");
            var stream = new MemoryStream();
            img.Save(stream, img.RawFormat);
            AliContext.Static.Timeout = 30;
            var results = AliContext.Static.Photo.UploadPhoto(1624713353, "测试图片上传功能-1", stream.ToArray());

        }
        [TestMethod]
        public void UpdatePhotoTest()
        {
            var results = AliContext.Static.Photo.UpdatePhoto(2395679476, "测试图片上传功能-3", "wo");

        }
        [TestMethod]
        public void RemovePhotosTest()
        {
            var results = AliContext.Static.Photo.RemovePhotos(2392837488, 2396688621);

        }
        [TestMethod]
        public void GetPhotoSpaceInfoTest()
        {
            var results = AliContext.Static.Photo.GetPhotoSpaceInfo();

        }


    }
}
