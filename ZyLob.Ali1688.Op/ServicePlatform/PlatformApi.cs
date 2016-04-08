using System;
using System.Collections.Generic;
using System.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.ServicePlatform
{
    /// <summary>
    /// 服务平台
    /// </summary>
  public  class PlatformApi
    {
        private readonly AliContext _context;

        public PlatformApi(AliContext context)
        {
            _context = context;
        }
      
        /// <summary>
        /// 应用最近一个月的订购的订单信息列表。 
        /// </summary>
        /// <remarks>
        /// 不需要授权
        ///  接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=app.expire.get&v=1 
        /// </remarks>
        /// <param name="beginDateTime">下单时间</param>
        /// <param name="aliMemberId">阿里会员编号</param>
        /// <param name="orderState">订单服务状态组</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>订单列表</returns>
        public IPagedList<AliApplyOrder> GetApplyOrdersByBeginDate( DateTime beginDateTime, string aliMemberId = "", AliApplyOrderState[] orderState = null, int pageIndex = 1,
            int pageSize = 20)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/app.order.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("gmtCreate", beginDateTime.ToAliDate());
            if (aliMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("memberId", aliMemberId);
            }
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("startIndex", pageIndex + "");
            if (orderState != null)
            {
                var oStates = orderState.Select(o => o.ToString()).ToArray();
                string statesStr = "";
                foreach (var oState in oStates)
                {
                    statesStr += ",\"{0}\"".FormatStr(oState);
                }
                otherParas.Add("bizStatusList", "[{0}]".FormatStr(statesStr.Substring(1)));
            }
            _context.Util.AddAliApiUrlSignPara( url, otherParas);
            var results = _context.Util.Send<ApplyOrderList>(url, otherParas);
            if (results.ReturnValue != null && results.ReturnValue.Count > 0)
            {
                int total = results.ReturnValue.Count;//先特殊处理目前api没有返回
                return new PagedList<AliApplyOrder>(results.ReturnValue, pageIndex, pageSize, total);
            }
            return new PagedList<AliApplyOrder>(new List<AliApplyOrder>(), pageIndex, pageSize);
        }

        /// <summary>
        /// 应用最近一个月的到期的订单信息列表。 只会状态是服务中或者待发布的才有到期时间
        /// </summary>
        /// <remarks>
        /// 不需要授权
        ///  接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=app.order.get&v=1
        /// </remarks>
        /// <param name="endDateTime">订单到期时间</param>
        /// <param name="aliMemberId">阿里会员编号</param>
        /// <param name="orderState">订单服务状态组</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <returns>订单列表</returns>
        public IPagedList<AliApplyOrder> GetApplyOrdersByEndDate( DateTime endDateTime, string aliMemberId = "", AliApplyOrderState[] orderState = null, int pageIndex = 1,
            int pageSize = 20)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/app.expire.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("gmtServiceEnd", endDateTime.ToAliDate());
            if (aliMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("memberId", aliMemberId);
            }
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("startIndex", pageIndex + "");
            if (orderState != null)
            {
                var oStates = orderState.Select(o => o.ToString()).ToArray();
                string statesStr = "";
                foreach (var oState in oStates)
                {
                    statesStr += ",\"{0}\"".FormatStr(oState);
                }
                otherParas.Add("bizStatusList", "[{0}]".FormatStr(statesStr.Substring(1)));
            }
            var results = _context.Util.Send<AliResult<AliResultList<AliApplyOrder>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return new PagedList<AliApplyOrder>(results.Result.ToReturn, pageIndex, pageSize, results.Result.Total);
            }
            return new PagedList<AliApplyOrder>(new List<AliApplyOrder>(), pageIndex, pageSize);
        }
        /// <summary>
        /// 获取阿里系统时间，从而跟本地时间进行校准
        /// </summary>
        /// <returns>阿里系统时间</returns>
        public DateTime GetSystemTime() {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/system.time.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas =_context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var result = _context.Util.Send<DateTime>(url, otherParas);
            return result;
        }

        
    }
}
