using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.CustomClassify
{
    /// <summary>
    /// 自定义分类
    /// </summary>
    public class CustomClassifyApi
    {
        private readonly AliContext _context;

        public CustomClassifyApi(AliContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 获取指定会员（供应商）的自定义商品分类信息
        /// </summary>
        /// <remarks>接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=category.getSelfCatlist&v=1 </remarks>
        /// <param name="aliMemberId">阿里会员编号</param>
        /// <returns>分类信息列表</returns>
        public List<AliCustomClassify> GetCustomClassifys(string aliMemberId)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/category.getSelfCatlist/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("memberId", aliMemberId);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<CustomClassifyResult>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First().SellerCats;
            }
            return new List<AliCustomClassify>();
        }
        /// <summary>
        /// 阿里巴巴中国网站会员开启或关闭自定义分类功能
        /// </summary>
        /// <remarks>接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offerGroup.set&v=1 </remarks>
        /// <param name="accessToken">用户授权令牌</param>
        /// <param name="switchType">会员开启或关闭自定义分类</param>
        /// <returns>是否设置成功 true成功；false失败</returns>
        public bool SetOfferGroup(string accessToken,OfferGroupSwitchType switchType)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offerGroup.set/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("switchType", switchType.ToString().ToLower());
            otherParas.Add("access_token", accessToken);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliResultSetOfferGroup>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First().IsSuccess;
            }
            return false;
        }
        /// <summary>
        /// 获取阿里巴巴中国网站会员是否已经开启自定义分类功能
        /// </summary>
        /// <remarks>接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offerGroup.hasOpened&v=1 </remarks>
        /// <param name="aliMemberId">阿里会员编号</param>
        /// <returns>是否开启自定义分类 true开启；false关闭</returns>
        public bool HasOpened(string aliMemberId)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offerGroup.hasOpened/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("memberId", aliMemberId);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliResultHasOpened>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First().IsOpened;
            }
            return false;
        }
    }
}
