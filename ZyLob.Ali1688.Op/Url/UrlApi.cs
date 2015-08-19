using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Url
{
    /// <summary>
    /// 阿里地址接口
    /// </summary>
    public class UrlApi
    {
       private readonly AliContext _context;

       public UrlApi(AliContext context)
        {
            _context = context;
        }
       /// <summary>
       /// 获取对应会员的“我已买到的货品”业务功能系统封装的URL地址
       /// </summary>
       /// <remarks>
       /// 授权类型：不需要授权
       /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.getBuyerOrderListUri&v=1
       /// </remarks>
       /// <returns>我已买到的货品URL地址</returns>
       public string GetBuyerOrderListUri()
       {
           string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.getBuyerOrderListUri/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<string>(url, otherParas);
           return results;
       }
        /// <summary>
        /// 获取对应会员的“我已卖出的货品”业务功能系统封装的URL地址
        /// </summary>
        /// <remarks>
        /// 授权类型：不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.getSellerOrderListUri&v=1
        /// </remarks>
        /// <returns>我已卖出的货品URL地址</returns>
        public string GetSellerOrderListUri()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.getSellerOrderListUri/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;
        }
        /// <summary>
        /// 获取指定offer的修改地址
        /// </summary>
        /// <remarks>
        /// 授权类型：不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offer.getEditUri&v=1
        /// </remarks>
        /// <param name="offerId">产品编号</param>
        /// <returns>offer的修改地址</returns>
        public string GetOfferEditUri(long offerId)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.getEditUri/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("param", "{\"offerId\":" + offerId + "}");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;
        }
    }
}
