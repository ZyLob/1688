using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Common;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 客户关系
    /// </summary>
    public class CustomerRelation
    {
       /// <summary>
       /// 关系来源
       /// </summary>
       public RelationSource RelationSource { get; set; }
      
       public int Status { get; set; }
       public long[] GroupingIds { get; set; }
       
       public long BuyerId { get; set; }
       public string BuyerMemberId { get; set; }
       public long SellerId { get; set; }
       public string SellerMemberId { get; set; }

       public int Grade { get; set; }
    }
    /// <summary>
    /// 顾客标签
    /// </summary>
    public class CustomerGroup
    {
        public long GroupingId { get; set; }
        public int Status { get; set; }
        public int NumOfMember { get; set; }
        public string  SellerMemberId { get; set; }
        public string GroupingName { get; set; }
        public int FromSite { get; set; }
       
    }

    public class CustomerSearchResult<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<T> Models { get; set; }

        public string Message { get; set; }

        public int TotalCount { get; set; }

        public int ResultCode { get; set; }

        public bool Success { get; set; }
      
    }
    
}
