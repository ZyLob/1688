using System;

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
        public AliApplyDetailOrderState DetailOrderState { get; set; }
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string AliMemberId { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ValidityDate { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public AliApplyOrderState OrderState { get; set; }
        /// <summary>
        /// 到帐金额
        /// </summary>
        public double PaymentAmount { get; set; }
        /// <summary>
        /// 执行金额
        /// </summary>
        public double ExecutePrice { get; set; }
    }
}
