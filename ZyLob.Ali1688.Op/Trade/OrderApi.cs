using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Trade
{
    /// <summary>
    /// 订单操作接口
    /// </summary>
    public class OrderApi
    {
        private readonly AliContext _context;

        public OrderApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 获取阿里巴巴中国网站指定会员的混批和发票设置信息
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=wholesale.get&v=1
        /// </remarks>
        /// <returns>会员的混批和发票设置信息</returns>
        public WholesaleSetting GetWholesaleSetting()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/wholesale.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<WholesaleSetting>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }
        /// <summary>
        /// 新版查询订单列表，不包含用户的隐私数据；适用于查询卖家和买家的订单列表
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.order.list.get&v=2
        /// </remarks>
        /// <param name="seachModel">订单搜索条件</param>
        /// <returns>订单搜索结果</returns>
        public IPagedList<OrderModel> OrderSearch(OrderSeachModel seachModel)
        {
            if (seachModel == null || (seachModel.BuyerMemberId.IsNullOrWhiteSpace() && seachModel.SellerMemberId.IsNullOrWhiteSpace()))
            {
                throw new AliParamException("买卖家memberId必填其一");
            }
            string url = "http://gw.open.1688.com/openapi/param2/2/cn.alibaba.open/trade.order.list.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("page", seachModel.Page + "");
            otherParas.Add("pageSize", seachModel.PageSize + "");
            if (seachModel.His)
            {
                otherParas.Add("his", seachModel.His + "");
            }
            if (seachModel.BuyerMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("buyerMemberId", seachModel.BuyerMemberId + "");
            }
            if (seachModel.SellerMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("sellerMemberId", seachModel.SellerMemberId + "");
            }
            if (seachModel.TradeTypeEnum != null)
            {
                otherParas.Add("tradeTypeEnum", ((int)seachModel.TradeTypeEnum) + "");

            }
            if (seachModel.OrderStatusEnum != null)
            {
                otherParas.Add("orderStatus", seachModel.OrderStatusEnum + "");
            }
            if (seachModel.SellerRateStatus != null)
            {
                otherParas.Add("sellerRateStatus", seachModel.SellerRateStatus + "");
            }
            if (seachModel.BuyerRateStatus != null)
            {
                otherParas.Add("buyerRateStatus", seachModel.BuyerRateStatus + "");
            }
            if (seachModel.RefundStatus != null)
            {
                otherParas.Add("refundStatus", seachModel.RefundStatus + "");
            }

            if (seachModel.ProductName.IsNotNullOrEmpty())
            {
                otherParas.Add("productName", seachModel.ProductName + "");
            }
            if (seachModel.CreateStartTime != default(DateTime))
            {
                otherParas.Add("createStartTime", seachModel.CreateStartTime.ToAliDate() + "");
            }
            if (seachModel.CreateEndTime != default(DateTime))
            {
                otherParas.Add("createEndTime", seachModel.CreateEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "");
            }
            if (seachModel.ModifyStartTime != default(DateTime))
            {
                otherParas.Add("modifyStartTime", seachModel.ModifyStartTime.ToString("yyyy-MM-dd HH:mm:ss") + "");
            }
            if (seachModel.ModifyEndTime != default(DateTime))
            {
                otherParas.Add("modifyEndTime", seachModel.ModifyEndTime.ToString("yyyy-MM-dd HH:mm:ss") + "");
            }

            if (seachModel.OrderIdSet != null && seachModel.OrderIdSet.Length > 0)
            {
                var orders = "[{0}]".FormatStr(string.Join(",", seachModel.OrderIdSet));
                otherParas.Add("orderIdSet", orders + "");
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliOrderSearchResult>(url, otherParas);

            if (results.OrderListResult.TotalCount > 0)
            {
                return new PagedList<OrderModel>(results.OrderListResult.ModelList, seachModel.Page, seachModel.PageSize, results.OrderListResult.TotalCount);
            }
            return new PagedList<OrderModel>(new List<OrderModel>(), seachModel.Page, seachModel.PageSize);
        }
        /// <summary>
        /// 查询单个订单详情，新版的查询详情接口，不含隐私数据
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.order.detail.get&v=1
        /// </remarks>
        /// <param name="orderId">订单号</param>
        /// <param name="needOrderEntries">是否需要订单明细,默认true</param>
        /// <param name="needInvoiceInfo">是否需要发票信息,默认true</param>
        /// <param name="needOrderMemoList">是否需要订单备注,默认true</param>
        /// <param name="needLogisticsOrderList">是否需要物流单信息,默认true</param>
        /// <returns>订单详情</returns>
        public OrderModel GetOrderDetail(long orderId, bool needOrderEntries = true, bool needInvoiceInfo = true, bool needOrderMemoList = true, bool needLogisticsOrderList = true)
        {
            if (orderId == default(long))
            {
                throw new AliParamException("orderId不能为空");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.order.detail.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("id", orderId + "");
            otherParas.Add("needOrderEntries", needOrderEntries + "");
            otherParas.Add("needInvoiceInfo", needInvoiceInfo + "");
            otherParas.Add("needOrderMemoList", needOrderMemoList + "");
            otherParas.Add("needLogisticsOrderList", needLogisticsOrderList + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<OrderDetailResult>(url, otherParas);
            return results.OrderModel;
        }
        /// <summary>
        /// 本接口查询当前会话会员的交易订单详情
        /// </summary>
        /// <remarks>
        /// 需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=trade.order.orderDetail.get&v=1
        /// </remarks>
        /// <param name="orderId">订单号</param>
        /// <returns>（原）订单详情</returns>
        public TradeDetail GetTradeDetail(long orderId)
        {
            if (orderId == default(long))
            {
                throw new AliParamException("orderId不能为空");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.order.orderDetail.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("orderId", orderId + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<TradeDetail>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }
    }
}
