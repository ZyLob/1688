using System;
using System.Collections.Generic;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    ///自定义分类返回结果
    /// </summary>
    public class CustomClassifyResult
    {
        /// <summary>
        /// 显示标识
        /// </summary>
        public string ShowFlag { get; set; }
        /// <summary>
        /// 自定义分类集合
        /// </summary>
        public List<AliCustomClassify> SellerCats { get; set; }
    }

    /// <summary>
    /// 阿里产品分类信息
    /// </summary>
    public class AliCustomClassify
    {
        /// <summary>
        /// 分类编号
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        public DateTime GmtModified { get; set; }

        /// <summary>
        /// 分类创建时间
        /// </summary>
        public DateTime GmtCreate { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分类图片
        /// </summary>
        public string IconUrl { get; set; }

        /// <summary>
        /// 下级分类
        /// </summary>
        public List<AliCustomClassify> Children { get; set; }

        /// <summary>
        /// 分类显示顺序
        /// </summary>
        public int Ordering { get; set; }

        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string MemberId { get; set; }

    }
      /// <summary>
    /// 会员开启或关闭自定义分类功能返回结果
    /// </summary>
    public class AliResultSetOfferGroup
    {
        /// <summary>
        /// 是否设置成功
        /// </summary>
        public bool IsSuccess { get; set; }
    }
      /// <summary>
    /// 会员是否已经开启自定义分类功能返回结果
    /// </summary>
    public class AliResultHasOpened
    {
        /// <summary>
        /// 是否已经开启自定义分类功能
        /// </summary>
        public bool IsOpened { get; set; }
    }
    
   
}
