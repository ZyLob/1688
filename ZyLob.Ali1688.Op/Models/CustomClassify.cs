using System;
using System.Collections.Generic;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 阿里产品分类信息
    /// </summary>
    public class AliProductClassify
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
        public List<AliProductClassify> Children { get; set; }

        /// <summary>
        /// 分类显示顺序
        /// </summary>
        public int Ordering { get; set; }

        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string MemberId { get; set; }

    }
}
