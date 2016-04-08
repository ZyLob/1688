using System;
using System.Collections.Generic;

namespace ZyLob.Ali1688.Op.Models
{
   /// <summary>
    /// 应用购买订单信息
   /// </summary>
    public class AliApplyOrder
    {
        /// <summary>
        /// 订单详细状态
        /// </summary>
        public AliApplyDetailOrderState BizStatusExt { get; set; }
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string MemberId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime GmtCreate { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime GmtServiceEnd { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public AliApplyOrderState BizStatus { get; set; }
        /// <summary>
        /// 到帐金额
        /// </summary>
        public double PaymentAmount { get; set; }
        /// <summary>
        /// 执行金额
        /// </summary>
        public double ExecutePrice { get; set; }
    }

    public class ApplyOrderList
    {
        public string ReturnClassName { get; set; }
        public bool Successed { get; set; }
        public List<AliApplyOrder> ReturnValue { get; set; }
    }
}
