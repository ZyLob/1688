﻿using System.Collections.Generic;
using System.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.PhotoAlbum
{
    /// <summary>
    /// 阿里相册操作接口
    /// </summary>
    public class AlbumApi
    {
        private readonly AliContext _context;

        public AlbumApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 获取相册列表
        /// </summary>
        /// <param name="albumType">相册类型CUSTOM-自定义相册；MY-我的相册；</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>相册信息列表</returns>
        public IPagedList<AliAlbum> GetAlbums(AliAlbumType albumType, int pageIndex = 1, int pageSize = 20)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取阿里相册列表");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.album.list/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumType", albumType.ToString().ToUpper());
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("pageNo", pageIndex + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliAlbum>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return new PagedList<AliAlbum>(results.Result.ToReturn, pageIndex, pageSize, results.Result.Total);
            }
            return new PagedList<AliAlbum>(new List<AliAlbum>(), pageIndex, pageSize);
        }

        /// <summary>
        /// 根据相册id获取相册信息
        /// </summary>
        /// <param name="albumId">相册id</param>
        /// <returns>相册信息</returns>
        public AliAlbum Get(long albumId)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("获取相册信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.album.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumId", albumId + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliAlbum>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }

        /// <summary>
        /// 实现创建相册功能
        /// </summary>
        /// <param name="aliAlbumEdit">阿里相册编辑实体</param>
        /// <returns>是否创建成功。取值如下：true-成功；false-失败</returns>
        public AliAlbumEditResult Create(AliAlbumEdit aliAlbumEdit)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("创建相册");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.album.create/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("name", aliAlbumEdit.AlbumName);
            otherParas.Add("description", aliAlbumEdit.Description);
            otherParas.Add("authority", ((int)aliAlbumEdit.AlbumAuthority) + "");
            otherParas.Add("password", aliAlbumEdit.Password);

            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliAlbumEditResult>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }

        ///  <summary>
        /// 修改相册信息功能
        ///  </summary>
        /// <param name="aliAlbumEdit">阿里相册编辑实体</param>
        ///  <returns>是否创建成功。取值如下：true-成功；false-失败</returns>
        public bool Edit(AliAlbumEdit aliAlbumEdit)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("修改相册信息");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.album.modify/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumId", aliAlbumEdit.AlbumId + "");
            otherParas.Add("name", aliAlbumEdit.AlbumName);
            otherParas.Add("description", aliAlbumEdit.Description);
            otherParas.Add("authority", ((int)aliAlbumEdit.AlbumAuthority) + "");
            otherParas.Add("password", aliAlbumEdit.Password);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<dynamic>>>(url, otherParas);
            return results.Result.Success;
        }

        /// <summary>
        /// 批量删除相册，每次最多支持删除500个相册
        /// </summary>
        /// <param name="albumIds">相册集合</param>
        /// <returns>被删除相册总数</returns>
        public List<AliAlbumRemoveResult> Remove(params long[] albumIds)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("批量删除相册");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/ibank.album.delete/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("albumIds", string.Join(";", albumIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliAlbumRemoveResult>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn;
            }
            return new List<AliAlbumRemoveResult>();
        }
    }
}
