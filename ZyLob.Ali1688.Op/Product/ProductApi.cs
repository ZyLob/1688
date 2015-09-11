﻿using System;
using System.Collections.Generic;
using System.Linq;
﻿using Newtonsoft.Json;
﻿using ZyLob.Ali1688.Op.Common;
﻿using ZyLob.Ali1688.Op.Context;
﻿using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Product
{
    /// <summary>
    /// 阿里产品操作接口
    /// </summary>
    public class ProductApi
    {
        private readonly AliContext _context;

        public ProductApi(AliContext context)
        {
            _context = context;
        }

        ///  <summary>
        ///  产品搜索
        /// <para>
        /// 不需要授权
        /// </para>
        /// <para>
        ///  接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.search&amp;v=1 
        /// </para>
        ///  </summary>
        /// <param name="seachModel">产品搜索参数模型</param>
        ///  <returns>产品分页信息</returns>
        public IPagedList<OfferDetailInfo> ProductSeach(ProductSeachModel seachModel)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.search/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNo", seachModel.PageNo.ToString());
            otherParas.Add("pageSize", seachModel.PageSize.ToString());
            otherParas.Add("status", seachModel.Status.ToString().ToLower());
            if (seachModel.Q.IsNotNullOrEmpty())
            {
                otherParas.Add("q", seachModel.Q);
            }
            if (seachModel.Address.IsNotNullOrEmpty())
            {
                otherParas.Add("address", seachModel.Address);
            }
            if (seachModel.Category != default(long))
            {
                otherParas.Add("category", seachModel.Category + "");
            }
            if (seachModel.City.IsNotNullOrEmpty())
            {
                otherParas.Add("city", seachModel.City);
            }
            if (seachModel.CreditMoney.IsNotNullOrEmpty())
            {
                otherParas.Add("creditMoney", seachModel.CreditMoney);
            }
            if (seachModel.GmtModifiedBegin != default(DateTime))
            {
                otherParas.Add("gmtModifiedBegin", seachModel.GmtModifiedBegin.ToAliDate());
            }
            if (seachModel.GmtModifiedEnd != default(DateTime))
            {
                otherParas.Add("gmtModifiedEnd", seachModel.GmtModifiedEnd.ToAliDate());
            }
            if (seachModel.GroupIds.IsNotNullOrEmpty())
            {
                otherParas.Add("groupIds", seachModel.GroupIds);
            }
            if (seachModel.MemberId.IsNotNullOrEmpty())
            {
                otherParas.Add("memberId", seachModel.MemberId);
            } if (seachModel.OrderBy.IsNotNullOrEmpty())
            {
                otherParas.Add("orderBy", seachModel.OrderBy);
            }
            if (seachModel.Price.IsNotNullOrEmpty())
            {
                otherParas.Add("price", seachModel.Price);
            }
            if (seachModel.Province.IsNotNullOrEmpty())
            {
                otherParas.Add("province", seachModel.Province);
            }
            if (seachModel.QualityLevel.IsNotNullOrEmpty())
            {
                otherParas.Add("qualityLevel", seachModel.QualityLevel);
            }
            if (seachModel.QuantityBegin.IsNotNullOrEmpty())
            {
                otherParas.Add("quantityBegin", seachModel.QuantityBegin);
            }
            if (seachModel.ReturnFields.IsNotNullOrEmpty())
            {
                otherParas.Add("returnFields", seachModel.ReturnFields);
            }
            if (seachModel.SoldQuantity.IsNotNullOrEmpty())
            {
                otherParas.Add("soldQuantity", seachModel.SoldQuantity);
            }
            if (seachModel.TpYear.IsNotNullOrEmpty())
            {
                otherParas.Add("tpYear", seachModel.TpYear);
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferDetailInfo>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return new PagedList<OfferDetailInfo>(results.Result.ToReturn, seachModel.PageNo, seachModel.PageSize, results.Result.Total);
            }
            return new PagedList<OfferDetailInfo>(new List<OfferDetailInfo>(), seachModel.PageNo, seachModel.PageSize);

        }

        /// <summary>
        /// 获取会员已发布的产品信息列表
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.getPublishOfferList&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="type">商品所属类型</param>
        /// <param name="categoryId">商品发布类目ID</param>
        /// <param name="groupIds">卖家自定义的商品分类ID,只支持单个类目id</param>
        /// <param name="page">页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。</param>
        /// <param name="pageSize">返回offer列表结果集分页条数。取值范围:大于零的整数;最大值：50;</param>
        /// <param name="timeStamp">1、如果传了时间戳参数，则按增量返回，即返回按指定获取条件且对应商品信息的最近更新时间(GMTModified)晚于该时间戳的商品列表信息。2、如果没有传时间戳参数，则取所有的满足条件的商品信息；</param>
        /// <param name="orderBy">只支持gmt_modify</param>
        /// <param name="returnFields">自定义返回字段，字段为offerDetailInfo子集</param>
        /// <returns>产品分页信息</returns>
        public IPagedList<OfferDetailInfo> GetPublishOffers(OfferType type = OfferType.SALE, long categoryId = default(long),
            long groupIds = default(long), int page = 1, int pageSize = 20, DateTime timeStamp = default(DateTime), string orderBy = "",
            string returnFields = "offerId,privateProperties,subject,details,imageList,productFeatureList,unit,amountOnSale,saledCount,priceRanges")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.getPublishOfferList/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("page", page + "");
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("type", type.ToString());
            if (categoryId != default(long))
            {
                otherParas.Add("categoryId", categoryId + "");

            }
            if (groupIds != default(long))
            {
                otherParas.Add("groupIds", groupIds + "");

            }
            if (orderBy != "")
            {
                otherParas.Add("orderBy", orderBy);
            }
            if (timeStamp != default(DateTime))
            {
                otherParas.Add("timeStamp", timeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (returnFields.IsNotNullOrEmpty())
            {
                otherParas.Add("returnFields", returnFields);

            }

            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferDetailInfo>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return new PagedList<OfferDetailInfo>(results.Result.ToReturn, page, pageSize, results.Result.Total);
            }
            return new PagedList<OfferDetailInfo>(new List<OfferDetailInfo>(), page, pageSize);
        }

        /// <summary>
        /// 获取会员所有的产品
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.getAllOfferList&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="type">商品所属类型,目前只支持SALE</param>
        /// <param name="categoryId">商品发布类目ID</param>
        /// <param name="groupIds">卖家自定义的商品分类ID，多个之间用“,”分隔</param>
        /// <param name="page">页码。取值范围:大于零的整数;默认值为1，即返回第一页数据。</param>
        /// <param name="pageSize">返回offer列表结果集分页条数。取值范围:大于零的整数;最大值：50。</param>
        /// <param name="timeStamp">格式:yyyy-MM-dd HH:mm:ss；1、如果传了时间戳参数，则按增量返回，即返回按指定获取条件且对应商品信息的最近更新时间(GMTModified)晚于该时间戳的商品列表信息。2、如果没有传时间戳参数，则取所有的满足条件的商品信息；</param>
        /// <param name="orderBy">当前支持:gmtexpire:asc|desc,gmt_modified:asc|desc</param>
        /// <param name="site">站点</param>
        /// <param name="returnFields">自定义返回字段，字段为offerDetailInfo子集。多个字段以半角','分隔。若此字段为空，则返回offer数组信息为空;其中如下参数无法通过该API获得：amountOnSale、details、detailsUrl、saledCount、skuArray、termOfferProcess、tradingType</param>
        /// <returns>产品分页信息</returns>
        public IPagedList<OfferDetailInfo> GetAllOffers(OfferType type = OfferType.SALE, long categoryId = default(long),
            long[] groupIds = null, int page = 1, int pageSize = 20, DateTime timeStamp = default(DateTime), string orderBy = "", string site = "china",
            string returnFields = "offerId,privateProperties,subject,details,imageList,productFeatureList,unit,amountOnSale,saledCount,priceRanges")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.getAllOfferList/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("page", page + "");
            otherParas.Add("pageSize", pageSize + "");
            otherParas.Add("type", type.ToString());
            if (categoryId != default(long))
            {
                otherParas.Add("categoryId", categoryId + "");

            }
            if (groupIds != null)
            {
                otherParas.Add("groupIds", groupIds + "");

            }
            if (orderBy != "")
            {
                otherParas.Add("orderBy", orderBy);
            }
            if (timeStamp != default(DateTime))
            {
                otherParas.Add("timeStamp", timeStamp.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (returnFields.IsNotNullOrEmpty())
            {
                otherParas.Add("returnFields", returnFields);

            }
            if (site.IsNotNullOrEmpty())
            {
                otherParas.Add("site", site);

            }

            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferDetailInfo>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return new PagedList<OfferDetailInfo>(results.Result.ToReturn, page, pageSize, results.Result.Total);
            }
            return new PagedList<OfferDetailInfo>(new List<OfferDetailInfo>(), page, pageSize);
        }
        /// <summary>
        /// 获取单个产品信息 
        /// </summary>
        /// <para>
        /// 不需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.get&amp;v=1
        /// </para>
        /// <param name="offerId">产品编号</param>
        /// <param name="returnFields">自定义返回字段。多个字段以半角逗号分隔;默认返回（商品编号,私密属性列举,商品标题,商品详情,商品图片列表,商品属性信息,计量单位,可售数量,已销售量,价格区间 ）</param>
        /// <returns>产品信息 </returns>
        public OfferDetailInfo GetProductByOfferId(long offerId,
            string returnFields =
                "offerId,privateProperties,subject,details,imageList,productFeatureList,unit,amountOnSale,saledCount,priceRanges")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerId", offerId.ToString());
            otherParas.Add("returnFields", returnFields);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferDetailInfo>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }

        /// <summary>
        /// 通过本接口实现阿里巴巴中文站已登录卖家会员批量重发指定offerID产品信息上网的功能；
        /// <para>重发规则与网站一致：1、每条供应产品24小时以内，只能重发一次；2、每个客户每天重发产品上限为400条；3、offids 每次最多20个。</para> 
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.repost&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="offerIds">产品编号</param>
        /// <returns>产品重发结果</returns>
        public List<ProductRepostResult> OfferRepost(params long[] offerIds)
        {
            if (offerIds.Length == 0)
            {
                return new List<ProductRepostResult>();
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.repost/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerIds", string.Join(";", offerIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<ProductRepostResult>>>(url, otherParas);

            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn;
            }
            return new List<ProductRepostResult>();
        }
        /// <summary>
        /// 产品增量修改
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.modify.increment&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="incrementAttr">增量修改属性</param>
        /// <returns>修改结果，返回空代表修改成功</returns>
        public string OfferIncrementModify(OfferIncrementAttr incrementAttr)
        {
            if (incrementAttr == null || incrementAttr.OfferId == default(long))
            {
                throw new AliParamException("产品编号为必填参数");
            }
            var json = new Dictionary<string, dynamic>();
            json.Add("offerId", incrementAttr.OfferId.ToString());
            if (incrementAttr.Subject.IsNotNullOrEmpty())
            {
                json.Add("subject", incrementAttr.Subject);                
            }
            if (incrementAttr.OfferDetail.IsNotNullOrEmpty())
            {
                json.Add("offerDetail", incrementAttr.OfferDetail);
            }
            if (incrementAttr.SkuList != null)
            {
               json.Add("skuList", incrementAttr.SkuList);
            }
            string modifyStr = JsonConvert.SerializeObject(json);
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.modify.increment/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offer", modifyStr);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<string>>>(url, otherParas);
            return results.Result.Message??"";
        }

    }
}