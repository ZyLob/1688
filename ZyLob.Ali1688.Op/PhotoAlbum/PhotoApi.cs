using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.PhotoAlbum
{
    /// <summary>
    /// 阿里图片操作接口
    /// </summary>
    public class PhotoApi
    {
        private readonly AliContext _context;

        public PhotoApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 获取相册图片列表
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.image.list&v=1
        /// </remarks>
        /// <param name="albumId">相册编号</param>
        /// <param name="pageIndex">页码</param>        
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>图片信息列表</returns>
        public IPagedList<AliPhoto> GetPhotos(long albumId, int pageIndex = 1, int pageSize = 20)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取相册图片列表");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.image.list/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumId", albumId + "");
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("pageNo", pageIndex + "");


            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliPhoto>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return new PagedList<AliPhoto>(results.Result.ToReturn, pageIndex, pageSize, results.Result.Total);
            }
            return new PagedList<AliPhoto>(new List<AliPhoto>(), pageIndex, pageSize);
        }

        ///  <summary>
        /// 获取指定图片信息
        ///  </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.image.modify&v=1
        /// </remarks>
        /// <param name="imgId">图片编号</param>
        ///  <returns>图片信息</returns>
        public AliPhoto Get(long imgId)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取指定图片信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.image.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("imageId", imgId + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliPhoto>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;

        }

        /// <summary>
        /// 上传阿里图片
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.image.upload&v=1
        /// </remarks>
        /// <param name="albumId">相册编号</param>
        /// <param name="photoName">图片名称</param>
        /// <param name="photoBytes">图片的二进制数据</param>
        /// <param name="description">图片描述，默认为空</param>
        /// <param name="isWatermark">是否添加默认水印</param>
        /// <returns>是否上传成功</returns>
        public AliPhoto UploadPhoto(long albumId, string photoName, byte[] photoBytes, string description = "", bool isWatermark = false)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取指定图片信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.image.upload/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumId", albumId + "");
            otherParas.Add("name", photoName);
            otherParas.Add("description", description);
            otherParas.Add("imageBytes", Convert.ToBase64String(photoBytes));
            otherParas.Add("drawTxt", isWatermark.ToString());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliPhoto>>>(url, otherParas,false);
            if (results.Result.Total > 0)
            {
                var currPhoto = results.Result.ToReturn.First();
                currPhoto.Description = description;
                currPhoto.AlbumId = albumId;
                currPhoto.Url64X64 = currPhoto.UrlMini.Replace("summ", "64x64");
                currPhoto.Url220X220 = currPhoto.UrlMini.Replace("summ", "220x220");
                currPhoto.Url310X310 = currPhoto.UrlMini.Replace("summ", "310x310");
                return currPhoto;
            }
            return null;
        }

        /// <summary>
        /// 修改图片信息
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.image.modify&v=1
        /// </remarks>
        /// <param name="photoId">图片编号</param>
        /// <param name="photoName">图片名称</param>
        /// <param name="description">图片描述</param>
        /// <returns>是否修改成功</returns>
        public bool UpdatePhoto(long photoId, string photoName, string description)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取指定图片信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.image.modify/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("imageId", photoId + "");
            otherParas.Add("name", photoName);
            otherParas.Add("description", description);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<dynamic>>>(url, otherParas);
            return results.Result.Success;
        }

        /// <summary>
        /// 删除图片, 每次最多支持删除500张图片。
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.image.deleteByIds&v=1
        /// </remarks>
        /// <param name="photoIds">图片编号集合</param>
        /// <returns>被删除图片数量</returns>
        public List<AliPhotoRemoveResult> RemovePhotos(params long[] photoIds)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取指定图片信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.image.deleteByIds/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("imageIds", string.Join(";", photoIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliPhotoRemoveResult>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn;
            }
            return new List<AliPhotoRemoveResult>();
        }
        /// <summary>
        /// 获取当前用户可用空间和总空间信息
        /// </summary>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=ibank.profile.get&v=1
        /// <returns>当前用户可用空间和总空间信息</returns>
        public PhotoSpace GetPhotoSpaceInfo()
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取指定图片信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.profile.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<PhotoSpace>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }
    }
}
