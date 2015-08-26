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

        //public IPagedList<OrderModel> OrderSearch()
        //{
            
        //} 

    }
}
