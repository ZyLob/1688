using System;
using System.Collections.Generic;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.CustomerRel
{
    /// <summary>
    /// 客户关系接口
    /// </summary>
    public class CustomerRelApi
    {
        private readonly AliContext _context;

        public CustomerRelApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 根据交易信息获取当前卖家的顾客信息
        /// </summary>
        /// <param name="tradeAmountStart">交易总额下限</param>
        /// <param name="tradeAmountEnd">交易总额上线</param>
        /// <param name="lastestTimeStart">交易时间下限</param>
        /// <param name="lastestTimeEnd">交易时间上限</param>
        /// <param name="tradeCountStart">交易笔数下限</param>
        /// <param name="tradeCountEnd">交易笔数上限</param>
        /// <param name="avgPriceStart">平均客单价下限</param>
        /// <param name="avgPriceEnd">平均客单价上限</param>
        /// <param name="itemNumStart">累计货品数量下限</param>
        /// <param name="itemNumEnd">累计货品数量上限</param>
        /// <param name="province">省份，用0-35表示</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="pageNum">页码</param>
        /// <returns>顾客关系列表</returns>
        public IPagedList<CustomerRelation> GetCustomerByTrade(long tradeAmountStart = default(long), long tradeAmountEnd=default(long),
            DateTime lastestTimeStart = default(DateTime), DateTime lastestTimeEnd=default(DateTime),
            int tradeCountStart = default(int), int tradeCountEnd = default(int),
            long avgPriceStart = default(long), long avgPriceEnd=default(long),
            int itemNumStart = default(int), int itemNumEnd = default(int), int province = default(int), int pageSize = 20, int pageNum=1)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/acrm.customer.trade.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNum", pageNum + "");
            otherParas.Add("pageSize", pageSize + "");

            if (tradeAmountStart != default(long))
            {
                otherParas.Add("tradeAmountStart", tradeAmountStart + "");

            }
            if (tradeAmountEnd != default(long))
            {
                otherParas.Add("tradeAmountEnd", tradeAmountEnd + "");

            }

            if (lastestTimeStart != default(DateTime))
            {
                otherParas.Add("lastestTimeStart", lastestTimeStart.ToString("yyyy-MM-dd"));
            }
            if (lastestTimeEnd != default(DateTime))
            {
                otherParas.Add("lastestTimeEnd", lastestTimeEnd.ToString("yyyy-MM-dd"));
            }
            if (tradeCountStart!=default(int))
            {
                otherParas.Add("tradeCountStart", tradeCountStart.ToString());

            }
            if (tradeCountEnd != default(int))
            {
                otherParas.Add("tradeCountEnd", tradeCountEnd.ToString());

            }
            if (avgPriceStart != default(long))
            {
                otherParas.Add("avgPriceStart", avgPriceStart.ToString());

            }
            if (avgPriceEnd != default(long))
            {
                otherParas.Add("avgPriceEnd", avgPriceEnd.ToString());

            }
            if (itemNumStart != default(int))
            {
                otherParas.Add("itemNumStart", itemNumStart.ToString());

            }
            if (tradeCountEnd != default(int))
            {
                otherParas.Add("itemNumEnd", itemNumEnd.ToString());

            }
            if (province != default(int))
            {
                otherParas.Add("province", province.ToString());

            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<CustomerSearchResult<CustomerRelation>>(url, otherParas);

            if (results.TotalCount > 0)
            {
                return new PagedList<CustomerRelation>(results.Models, pageNum, pageSize, results.TotalCount);
            }
            return new PagedList<CustomerRelation>(new List<CustomerRelation>(), pageNum, pageSize);
        }
        /// <summary>
        /// 获取会员所有分组标签
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=acrm.groups.get&amp;v=1
        /// </para>
        /// </summary>
        /// <returns>会员所有分组标签</returns>
        public List<CustomerGroup> GetGroups()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/acrm.groups.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<CustomerSearchResult<CustomerGroup>>(url, otherParas);

            if (results.TotalCount > 0)
            {
                return results.Models;
            }
            return new List<CustomerGroup>();
        }

        /// <summary>
        /// 根据标签获取当前卖家的顾客列表
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=acrm.customer.group.get&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="groupId">分组id</param>
        /// <param name="pageNum">页面大小 默认最大20</param>
        /// <param name="pageSize">页号</param>
        /// <returns>卖家的顾客列表</returns>
        public IPagedList<CustomerRelation> GetCustomerByGroup(long groupId, int pageNum = 1, int pageSize = 20)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/acrm.customer.group.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNum", pageNum.ToString());
            otherParas.Add("pageSize", pageSize.ToString());
            otherParas.Add("groupId", groupId.ToString());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<CustomerSearchResult<CustomerRelation>>(url, otherParas);

            if (results.TotalCount > 0)
            {
                return new PagedList<CustomerRelation>(results.Models, pageNum, pageSize, results.TotalCount);
            }
            return new PagedList<CustomerRelation>(new List<CustomerRelation>(), pageNum, pageSize);
        }
         /// <summary>
        /// 根据等级获取当前卖家的顾客列表
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=acrm.customer.relation.get&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="level">会员等级</param>
        /// <param name="pageNum">页面大小 默认最大20</param>
        /// <param name="pageSize">页号</param>
        /// <returns>卖家的顾客列表</returns>
        public IPagedList<CustomerRelation> GetCustomerByLevel(CustomerLevel   level, int pageNum = 1, int pageSize = 20)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/acrm.customer.relation.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNum", pageNum.ToString());
            otherParas.Add("pageSize", pageSize.ToString());
            otherParas.Add("level", ((int)level).ToString());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<CustomerSearchResult<CustomerRelation>>(url, otherParas);

            if (results.TotalCount > 0)
            {
                return new PagedList<CustomerRelation>(results.Models, pageNum, pageSize, results.TotalCount);
            }
            return new PagedList<CustomerRelation>(new List<CustomerRelation>(), pageNum, pageSize);
        }
    }
}
