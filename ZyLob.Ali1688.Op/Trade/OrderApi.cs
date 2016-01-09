using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
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
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=wholesale.get&amp;v=1
        /// </para>
        /// </summary>
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
        /// 修改订单价格
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.modifyOrderPrice&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="orderId">需要改价的订单号</param>
        /// <param name="carriage">订单修改之后的运费，单位为分</param>
        /// <param name="entryDiscounts">改价明细,discount值的单位为分，正数为涨价，负数为减价</param>
        /// <returns>修改订单价格结果</returns>
        public ModifyOrderPriceResult ModifyOrderPrice(long orderId, long carriage, ModifyOrderPriceDetail[] entryDiscounts)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.order.modifyOrderPrice/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("orderId", orderId + "");
            otherParas.Add("carriage", carriage + "");
            var entryDiscountsStr = JsonConvert.SerializeObject(entryDiscounts);
            otherParas.Add("entryDiscounts", entryDiscountsStr.ToLower());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ModifyOrderPriceResult>(url, otherParas);
            return results;

        }

        /// <summary>
        /// 新版查询订单列表，不包含用户的隐私数据；适用于查询卖家和买家的订单列表
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.list.get&amp;v=2
        /// </para>
        /// </summary>
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
                otherParas.Add("orderStatusEnum", seachModel.OrderStatusEnum + "");
            }
            if (seachModel.SellerRateStatus != null)
            {
                otherParas.Add("sellerRateStatus", (int)seachModel.SellerRateStatus + "");
            }
            if (seachModel.BuyerRateStatus != null)
            {
                otherParas.Add("buyerRateStatus", (int)seachModel.BuyerRateStatus + "");
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
                otherParas.Add("createEndTime", seachModel.CreateEndTime.ToAliDate() + "");
            }
            if (seachModel.ModifyStartTime != default(DateTime))
            {
                otherParas.Add("modifyStartTime", seachModel.ModifyStartTime.ToAliDate() + "");
            }
            if (seachModel.ModifyEndTime != default(DateTime))
            {
                otherParas.Add("modifyEndTime", seachModel.ModifyEndTime.ToAliDate() + "");
            }

            if (seachModel.OrderIdSet != null && seachModel.OrderIdSet.Length > 0)
            {
                var orders = "[{0}]".FormatStr(string.Join(",", seachModel.OrderIdSet));
                otherParas.Add("orderIdSet", orders + "");
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliOrderSearchResult>(url, otherParas);

            if (results!=null&&results.OrderListResult.TotalCount > 0)
            {
                return new PagedList<OrderModel>(results.OrderListResult.ModelList, seachModel.Page, seachModel.PageSize, results.OrderListResult.TotalCount);
            }
            return new PagedList<OrderModel>(new List<OrderModel>(), seachModel.Page, seachModel.PageSize);
        }
        /// <summary>
        /// 查询单个订单详情，新版的查询详情接口，不含隐私数据
        /// <para>需要授权</para>
        /// <para>接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.detail.get&amp;v=1 </para>
        /// </summary>
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
        /// 本接口查询当前会话会员的交易订单列表 营销手段的折扣比如限时促销 满减这类的优惠，暂时还无法通过接口获取
        /// <para>
        /// 需要授权    
        /// </para>
        /// <para>
        /// 接口地址:http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.orderList.get&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="seachModel">交易搜索条件</param>
        /// <returns>交易列表</returns>
        public IPagedList<TradeDetail> TradeSearch(TradeSeachModel seachModel)
        {
            if (seachModel == null || (seachModel.BuyerMemberId.IsNullOrWhiteSpace() && seachModel.SellerMemberId.IsNullOrWhiteSpace()))
            {
                throw new AliParamException("买卖家memberId必填其一");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.order.orderList.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNo", seachModel.PageNo + "");
            otherParas.Add("pageSize", seachModel.PageSize + "");
            if (seachModel.IsHis)
            {
                otherParas.Add("isHis", seachModel.IsHis + "");
            }
            if (seachModel.BuyerMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("buyerMemberId", seachModel.BuyerMemberId + "");
            }
            if (seachModel.SellerMemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("sellerMemberId", seachModel.SellerMemberId + "");
            }
            if (seachModel.TradeType != null)
            {
                otherParas.Add("tradeType", ((int)seachModel.TradeType) + "");

            }
            if (seachModel.OrderStatus != null)
            {
                otherParas.Add("orderStatus", seachModel.OrderStatus + "");
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

            if (seachModel.OrderId != default(long))
            {
                otherParas.Add("orderId", seachModel.OrderId + "");
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<TradeDetail>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return new PagedList<TradeDetail>(results.Result.ToReturn, seachModel.PageNo, seachModel.PageSize, results.Result.Total);
            }
            return new PagedList<TradeDetail>(new List<TradeDetail>(), seachModel.PageNo, seachModel.PageSize);
        }
        /// <summary>
        /// 本接口查询当前会话会员的交易订单详情
        /// <para>需要授权</para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.orderDetail.get&amp;v=1 
        /// </para>
        /// </summary>
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
        /// <summary>
        /// 此接口支持多笔订单（暂定最多10笔每次）同时提交评价, 只支持卖家向买家的评价，
        /// 目前当某笔订单存在多个商品时,只能为这笔订单的这些商品提交相同的评价内容。
        /// <para>
        /// 需要授权
        /// </para> 
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=trade.order.batch.rate&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="orderEvaluates">订单评价信息</param>
        /// <returns>
        /// 批量评价结果提交评价失败的订单Map(Long,String) ,前者为失败的订单号，后者为失败的错误码：
        /// 1 返回为空时，创建全部成功 
        /// 2 没指定订单号及评价内容时,接口直接返回成功结果 
        /// 3 当订单已经评价过时，接口直接返回成功结果，不做任何处理
        /// 4 当指定的订单不是指定postMemberId用户的订单是，接口直接返回成功结果，不做任何处理 
        /// 5 当指定的订单不处于待评价状态时，接口直接返回成功结果，不做任何处理
        /// </returns>
        public Dictionary<long, string> OrderEvaluate(Dictionary<long, OrderEvaluateModel[]> orderEvaluates)
        {
            if (orderEvaluates == null || orderEvaluates.Count > 10)
            {
                throw new AliParamException("orderEvaluates必填且每次最多对10订单评价");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/trade.order.batch.rate/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            var orderEvaluateStr = JsonConvert.SerializeObject(orderEvaluates);
            otherParas.Add("orders", orderEvaluateStr);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<OrderEvaluteResult>(url, otherParas);
            return results.FailedOrder;
        }
    }
}
