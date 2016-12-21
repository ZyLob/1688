using System.Collections.Generic;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Trade
{
    /// <summary>
    /// 物流接口
    /// </summary>
    public class LogisticsApi
    {
        private readonly AliContext _context;
        public LogisticsApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 本接口查询物流公司列表
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.logisticsCompany.logisticsCompanyList.get&v=1
        /// </remarks>
        /// <returns>物流公司列表</returns>
        public List<LogisticsCompanyModel> GetLogisticsCompanys()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.logisticsCompany.logisticsCompanyList.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<LogisticsCompanyModel>>>(url, otherParas);
            return results.Result.ToReturn;
        }
        /// <summary>
        /// 本接口实现获取指定会员在阿里巴巴中文站上的发货地址列表信息(只能查自己的信息)
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.freight.sendGoodsAddressList.get&v=1
        /// </remarks>
        /// <param name="commonUseOnly">是否只取常用发货地址，默认为False</param>
        /// <param name="returnFields">自定义返回字段,默认全部返回</param>
        /// <returns></returns>
        public List<SendGoodsAddress> GetSendGoodsAddresses(bool commonUseOnly = false,
            string returnFields =
                "deliveryAddressId,updateTime,isCommonUse,contactName,location,address,postcode,telephone,mobilephone")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.freight.sendGoodsAddressList.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("commonUseOnly", commonUseOnly.ToString());
            otherParas.Add("returnFields", returnFields);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<SendGoodsAddress>>>(url, otherParas);
            return results.Result.ToReturn;
        }
        /// <summary>
        /// 用户运费模板列表描述查询
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=e56.delivery.template.list&v=1
        /// </remarks>
        /// <returns>运费模板列表</returns>
        public List<LogisticsTemplate> GetLogisticsTemplates()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/e56.delivery.template.list/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<List<LogisticsTemplate>>>(url, otherParas);
            return results.Result;
        }
    }
}
