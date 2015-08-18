using System;

namespace ZyLob.Ali1688.Op.Models
{
    /// <summary>
    /// 1688相册
    /// </summary>
    public class AliAlbum
    {
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string AccountId { get; set; }
        /// <summary>
        /// 相册ID
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 相册类型.CUSTOM-自定义相册 MY-我的相册 OFF-下架相册
        /// </summary>
        public AliAlbumType Type { get; set; }
        /// <summary>
        ///相册名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 相册描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 相册创建时间,格式为“yyyy-MM-dd”
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        ///相册中图片数量
        /// </summary>
        public int ImageCount { get; set; }
        /// <summary>
        /// 相册封面图片URL
        /// </summary>
        public string CoverPicUrl { get; set; }
        /// <summary>
        /// 相册封面图片ID
        /// </summary>
        public long CoverPicId { get; set; }
    }
    /// <summary>
    ///阿里相册编辑实体
    /// </summary>
    public class AliAlbumEdit
    {
        /// <summary>
        ///	相册ID
        /// </summary>
        public long AlbumId { get; set; }
        /// <summary>
        /// 相册名称。最长30个中文字符
        /// </summary>
        public string AlbumName { get; set; }
        /// <summary>
        /// 相册描述。最长2000个中文字符
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 相册访问权限。只有开通旺铺的会员可以设置相册访问权限为“1-公开”和“2-密码访问”，未开通旺铺的会员相册访问权限限制为“0-不公开”。
        /// </summary>
        public AliAlbumAuthority AlbumAuthority { get; set; }
        /// <summary>
        /// 相册访问密码。4-16位非中文字符。当AlbumAuthority 为PasswordAlbum-密码访问时必填。
        /// </summary>
        public string Password { get; set; }

    }
    /// <summary>
    /// 相册编辑后返回结果
    /// </summary>
    public class AliAlbumEditResult
    {
        /// <summary>
        /// 相册创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 相册编号
        /// </summary>
        public long AlbumId { get; set; }
    }
    /// <summary>
    /// 相册删除后返回结果
    /// </summary>
    public class AliAlbumRemoveResult
    {
        /// <summary>
        /// 相册是否删除成
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// 相册编号
        /// </summary>
        public long AlbumId { get; set; }
    }
    /// <summary>
    /// Ali图片信息
    /// </summary>
    public class AliPhoto
    {
        /// <summary>
        /// 阿里会员ID
        /// </summary>
        public string AccountId { get; set; }


        /// <summary>
        /// 图片ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图片描述	
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片URL(原图)，图片的相对路径（即除去http://server:port部分，如:img/ibank/15/02/60/15026073.jpg）	img/ibank/15/02/60/15026073.jpg
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 图片URL(缩略图)，图片的相对路径（即除去http://server:port部分，如:img/ibank/15/02/60/15026073.jpg）	img/ibank/15/02/60/15026073.jpg
        /// </summary>
        public string UrlMini { get; set; }

        /// <summary>
        ///图片URL(310x310)，图片的相对路径（即除去http://server:port部分，如:img/ibank/15/02/60/15026073.jpg）	img/ibank/15/02/60/15026073.jpg
        /// </summary>
        public string Url310X310 { get; set; }
        /// <summary>
        ///图片URL(220x220)，图片的相对路径（即除去http://server:port部分，如:img/ibank/15/02/60/15026073.jpg）	img/ibank/15/02/60/15026073.jpg
        /// </summary>
        public string Url220X220 { get; set; }
        /// <summary>
        ///图片URL(64x64)，图片的相对路径（即除去http://server:port部分，如:img/ibank/15/02/60/15026073.jpg）	img/ibank/15/02/60/15026073.jpg
        /// </summary>
        public string Url64X64 { get; set; }
        /// <summary>
        ///图片上传时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        //图片大小，单位为字节	
        /// </summary>
        public int Size { get; set; }
        /// <summary>
        ///图片所属相册
        /// </summary>
        public int AlbumId { get; set; }
    }


    /// <summary>
    /// 图片空间信息
    /// </summary>
    public class PhotoSpace
    {
        /// <summary>
        /// 阿里会员编号
        /// </summary>
        public string AliMemberId { get; set; }
        /// <summary>
        /// 已使用空间，单位为字节	
        /// </summary>
        public int UsedSpace { get; set; }
        /// <summary>
        /// 总空间，单位为字节
        /// </summary>
        public int TotalSpace { get; set; }
        /// <summary>
        ///空间是否已满，true：已满 false：未满	
        /// </summary>
        public bool IsFull { get; set; }
        /// <summary>
        /// 已使用空间占总空间百分比，精确到小数点后两位。如占用30.31%，返回值为30.31
        /// </summary>
        public double SpaceUsage { get; set; }
    }


}
