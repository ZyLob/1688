using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Tests.PhotoAlbum
{
    [TestClass]
    public class AlbumApiTest
    {
        [TestMethod]
        public void GetAlbumsTest()
        {
            var results = AliContext.Static.Album.GetAlbums("f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7", AliAlbumType.Custom);
            int i = 1;
        }

        [TestMethod]
        public void GetTest()
        {
            var result = AliContext.Static.Album.Get("f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7", "160909130");
            int i = 1;
        }
        [TestMethod]
        public void CreateTest()
        {
            var albumEdit = new AliAlbumEdit();
            albumEdit.AlbumAuthority = AliAlbumAuthority.PasswordAlbum;
            albumEdit.AlbumName = "测试相册20150818-1";
            albumEdit.Description = "测试使用";
            albumEdit.Password = "test";
            var result = AliContext.Static.Album.Create("f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7", albumEdit);
            int i = 1;
        }

        [TestMethod]
        public void EditTest()
        {
            var albumEdit = new AliAlbumEdit();
            albumEdit.AlbumId = 161232207;
            albumEdit.AlbumAuthority = AliAlbumAuthority.PasswordAlbum;
            albumEdit.AlbumName = "测试相册20150818-4";
            albumEdit.Description = "测试使用";
            albumEdit.Password = "test1";
            var result = AliContext.Static.Album.Edit("f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7", albumEdit);
            int i = 1;
        }
        [TestMethod]
        public void RemoveTest()
        {

            var result = AliContext.Static.Album.Remove("f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7", 161032751,161044164);
            int i = 1;
        }
        
    }
}
