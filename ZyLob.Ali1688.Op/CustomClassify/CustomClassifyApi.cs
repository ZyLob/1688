using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        /// <param name="switchType">会员开启或关闭自定义分类</param>
        /// <returns>是否设置成功 true成功；false失败</returns>
        public bool SetOfferGroup(OfferGroupSwitchType switchType)
        {
            if (_context.AccessToken.IsNullOrEmpty())
            {
                throw new AliTokenException("开启或关闭自定义分类");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offerGroup.set/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("switchType", switchType.ToString().ToLower());
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
        /// <summary>
        /// 批量添加多个产品到一个自定义分类下
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=userCategory.offers.add&v=1
        /// </remarks>
        /// <param name="classifyId">自定义分类编号</param>
        /// <param name="offerIds">移除产品编号</param>
        /// <returns>是否添加成功</returns>
        public bool AddProductClassify(long classifyId, params long[] offerIds)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/userCategory.offers.add/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("groupId", classifyId+"");
            otherParas.Add("offerIds", string.Join(";", offerIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<JObject>>>(url, otherParas);
            return results.Result.Success;
        }
        /// <summary>
        /// 批量移除多个产品的一个自定义分类
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=userCategory.offers.remove&v=1
        /// </remarks>
        /// <param name="classifyId">自定义分类编号</param>
        /// <param name="offerIds">移除产品编号</param>
        /// <returns>是否移除成功</returns>
        public bool RemoveProductClassify(long classifyId, params long[] offerIds)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/userCategory.offers.remove/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerIds", string.Join(";", offerIds));
            otherParas.Add("groupId", classifyId + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<JObject>>>(url, otherParas);
            return results.Result.Success;
        }

        /// <summary>
        /// 批量获取指定产品所属的自定义分类ID
        /// </summary>
        /// <remarks>
        /// 授权类型：需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=userCategory.get.offerIds&v=1
        /// </remarks>
        /// <param name="offerIds">查询的产品id</param>
        /// <returns>产品及对应的分类编号集合 key 产品编号 value 分类编号集合</returns>
        public Dictionary<long, List<long>> GetOffersClassify(params long[] offerIds)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/userCategory.get.offerIds/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerIds", string.Join(";", offerIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<JObject>>>(url, otherParas);
            JObject offRelClassify = null;
            if (results.Result.ToReturn.Count > 0)
            {
                offRelClassify = results.Result.ToReturn.First();
            }
            var returnResult = new Dictionary<long, List<long>>();
            foreach (var offerId in offerIds)
            {
                List<long> classifys = null;
                if (offRelClassify != null && offRelClassify["offerID" + offerId] != null)
                {
                    classifys = offRelClassify["offerID" + offerId].ToObject<List<long>>();
                }
                else
                {
                    classifys = new List<long>();
                }
                returnResult.Add(offerId, classifys);
            }
            return returnResult;

        }
    }
}
