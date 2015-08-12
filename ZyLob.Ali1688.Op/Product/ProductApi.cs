using System;
using System.Collections.Generic;
using System.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Product
{
    public class ProductApi
    {
        /// <summary>
        /// 产品搜索
        /// </summary>
        ///<remarks>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offer.search&v=1 
        /// </remarks>
        /// <param name="seachModel">产品搜索参数模型</param>
        /// <returns>产品分页信息</returns>
        public IPagedList<OfferDetailInfo> ProductSeach(ProductSeachModel seachModel)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.search/{0}".FormatStr(ApplyUtils.GetApply().AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("pageNo", seachModel.PageNo + "");
            otherParas.Add("pageSize", seachModel.PageSize + "");
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
            ApiUtils.AddAliApiUrlSignPara(ApplyUtils.GetApply().SecretKey, url, otherParas);
            var results = CommonSend.Send<AliResult<AliResultList<List<OfferDetailInfo>>>>(url, otherParas);

            if (results.Result.Success)
            {
                return new PagedList<OfferDetailInfo>(results.Result.ToReturn, seachModel.PageNo, seachModel.PageSize, results.Result.Total);
            }
            return new PagedList<OfferDetailInfo>(new List<OfferDetailInfo>(), seachModel.PageNo, seachModel.PageSize);

        }

        /// <summary>
        /// 获取单个产品信息 
        /// </summary>
        /// <remarks>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offer.get&v=1
        /// </remarks>
        /// <param name="offerId">产品编号</param>
        /// <param name="returnFields">自定义返回字段。多个字段以半角逗号分隔;默认返回（商品编号,私密属性列举,商品标题,商品详情,商品图片列表,商品属性信息,计量单位,可售数量,已销售量,价格区间 ）</param>
        /// <returns>产品信息 </returns>
        public OfferDetailInfo GetProductByOfferId(string offerId,
            string returnFields =
                "offerId,privateProperties,subject,details,imageList,productFeatureList,unit,amountOnSale,saledCount,priceRanges")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.get/{0}".FormatStr(ApplyUtils.GetApply().AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("offerId", offerId);
            otherParas.Add("returnFields", returnFields);
            ApiUtils.AddAliApiUrlSignPara(ApplyUtils.GetApply().SecretKey, url, otherParas);
            var results = CommonSend.Send<AliResult<AliResultList<List<OfferDetailInfo>>>>(url, otherParas);

            if (results.Result.Success && results.Result.Total>0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }

        /// <summary>
        /// 产品重发
        /// </summary>
        /// <remarks>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=offer.repost&v=1
        /// </remarks>
        /// <param name="accessToken">授权口令</param>
        /// <param name="offerIds">产品编号</param>
        /// <returns>产品重发结果</returns>
        public List<ProductRepostResult> OfferRepost(string accessToken, params string[] offerIds)
        {
            if (offerIds.Length == 0)
            {
                return new List<ProductRepostResult>();
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.repost/{0}".FormatStr(ApplyUtils.GetApply().AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("access_token", accessToken);
            otherParas.Add("offerIds", string.Join(";", offerIds));
            ApiUtils.AddAliApiUrlSignPara(ApplyUtils.GetApply().SecretKey, url, otherParas);
            var results = CommonSend.Send<AliResult<AliResultList<List<ProductRepostResult>>>>(url, otherParas);

            if (results.Result.Success && results.Result.Total > 0)
            {
                return results.Result.ToReturn;
            }
            return new List<ProductRepostResult>();
        }


    }
}
