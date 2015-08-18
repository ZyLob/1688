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
            var results = AliContext.Static.Album.GetAlbums( AliAlbumType.Custom);
            int i = 1;
        }

        [TestMethod]
        public void GetTest()
        {
            var result = AliContext.Static.Album.Get( "160909130");
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
            var result = AliContext.Static.Album.Create( albumEdit);
            int i = 1;
        }

        [TestMethod]
        public void EditTest()
        {
            var albumEdit = new AliAlbumEdit();
            albumEdit.AlbumId = 161232622;
            albumEdit.AlbumAuthority = AliAlbumAuthority.PasswordAlbum;
            albumEdit.AlbumName = "测试相册20150818-4";
            albumEdit.Description = "测试使用";
            albumEdit.Password = "test1";
            var result = AliContext.Static.Album.Edit( albumEdit);
            int i = 1;
        }
        [TestMethod]
        public void RemoveTest()
        {

            var result = AliContext.Static.Album.Remove( 161032751,161044164);
            int i = 1;
        }
        
    }
}
