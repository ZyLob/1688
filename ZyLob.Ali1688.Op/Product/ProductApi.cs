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
            otherParas.Add("status", seachModel.GetStatusStr);
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
            if (seachModel.OfferId != default(long))
            {
                otherParas.Add("offerId", seachModel.OfferId + "");
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
            if (incrementAttr.FreightTemplateId.IsNotNullOrEmpty())
            {
                json.Add("freightTemplateId", incrementAttr.FreightTemplateId);
            }
            if (incrementAttr.FreightType.IsNotNullOrEmpty())
            {
                json.Add("freightType", incrementAttr.FreightType);
            }
            if (incrementAttr.IsMixWholeSale.IsNotNullOrEmpty())
            {
                json.Add("isMixWholeSale", incrementAttr.IsMixWholeSale);
            }
            if (incrementAttr.IsPictureAuthOffer.IsNotNullOrEmpty())
            {
                json.Add("isPictureAuthOffer", incrementAttr.IsPictureAuthOffer);
            }
            if (incrementAttr.IsPriceAuthOffer.IsNotNullOrEmpty())
            {
                json.Add("isPriceAuthOffer", incrementAttr.IsPriceAuthOffer);
            }
            if (incrementAttr.OfferWeight.IsNotNullOrEmpty())
            {
                json.Add("offerWeight", incrementAttr.OfferWeight);
            }
            if (incrementAttr.UserCategorys.IsNotNullOrEmpty())
            {
                json.Add("userCategorys", incrementAttr.UserCategorys);
            }
            if (incrementAttr.SendGoodsAddressId.IsNotNullOrEmpty())
            {
                json.Add("sendGoodsAddressId", incrementAttr.SendGoodsAddressId);
            }
            string modifyStr = JsonConvert.SerializeObject(json);
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.modify.increment/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offer", modifyStr);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<string>>>(url, otherParas);
            return results.Message!=null ?string.Join("|", results.Message): "";
        }
        /// <summary>
        /// 增量修改产品库存
        /// <para>
        /// 需要授权
        /// </para>
        /// <para>
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&amp;n=offer.modify.stock&amp;v=1
        /// </para>
        /// </summary>
        /// <param name="offerId">产品编号</param>
        /// <param name="offerAmountChange">总库存改变量</param>
        /// <param name="skuAmountChange">
        /// Sku报价产品，指定规格的库存变量，注是所有规格改变量之和要等于offerAmountChange 
        /// 如果产品没有sku，可以不用填。数据格式{"specId":"number"},key是sku信息中的specId，后者为库存变更量
        /// </param>
        /// <returns></returns>
        public ModifyStockResult OfferModifyStock(long offerId, int offerAmountChange, Dictionary<string, int> skuAmountChange = null)
        {
            if (offerId == default(long))
            {
                throw new AliParamException("产品编号为必填参数");
            }
            if (offerAmountChange == default(long))
            {
                throw new AliParamException("总库存改变量为必填参数");
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/offer.modify.stock/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerId", offerId.ToString());
            otherParas.Add("offerAmountChange", offerAmountChange.ToString());
            if (skuAmountChange != null)
            {
                string modifyStr = JsonConvert.SerializeObject(skuAmountChange);
                otherParas.Add("skuAmountChange", modifyStr);
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ModifyStockResult>(url, otherParas);
            return results;
        }
        /// <summary>
        /// 本接口通过数据接口的形式，实现阿里巴巴中文站登录会员发布offer的功能。每个客户每天最多新发布1000个产品。
        /// </summary>
        public long? OfferNew(OfferNew model)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/offer.new/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            if (model != null)
            {
                string offerStr = JsonConvert.SerializeObject(model);
                otherParas.Add("offer", offerStr);
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<long?>>>(url, otherParas);
            if (results.Message != null && results.Message.Length > 0)
            {
                throw new AliResultException(string.Join(",", results.Message));
            }
            if (results.Result == null || !results.Result.Success)
                return null;
            return results.Result.ToReturn.First();
        }
        /// <summary>
        /// 通过本接口实现阿里巴巴中文站已登录卖家会员批量的设置指定offerID产品信息为过期商品的功能；转为过期的业务规则现有网站的业务逻辑保持一致；
        /// </summary>
        public List<OfferExpireResult> OfferExpire(params long[] offerIds)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/offer.expire/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            if (offerIds.Count() > 0)
            {

                otherParas.Add("offerIds", string.Join(";", offerIds));
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferExpireResult>>>(url, otherParas);
            if (results.Message != null && results.Message.Length > 0)
            {
                throw new AliResultException(string.Join(",", results.Message));
            }
            if (results.Result == null)
                return new List<OfferExpireResult>();
            return results.Result.ToReturn;
        }
        /// <summary>
        /// 通过本接口实现阿里巴巴中文站已登录会员获取指定产品是否可以修改的信息
        /// </summary>
        public List<OfferCanModifyResult> OfferCanModify(params long[] offerIds)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/offer.canModify.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            if (offerIds.Count() > 0)
            {   

                otherParas.Add("offerIds", string.Join(";", offerIds));
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<OfferCanModifyResult>>>(url, otherParas);
            if (results.Message != null && results.Message.Length > 0)
            {
                throw new AliResultException(string.Join(",", results.Message));
            }
            if (results.Result == null)
                return new List<OfferCanModifyResult>();
            return results.Result.ToReturn;
        }
        /// <summary>
        /// 根据状态查询商品
        /// </summary>
        public string GetOfferByStatus(int page = 1, int pageSize = 20,params string[] statusList)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/com.alibaba.product/alibaba.product.getByStatus/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("pageNo", page + "");
            otherParas.Add("pageSize", pageSize + "");
            if (statusList.Any())
            {
                otherParas.Add("statusList",JsonConvert.SerializeObject(statusList));
            }
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            
            return results;
        }
        /// <summary>
        /// 通过本接口实现阿里巴巴中文站已登录卖家会员永久删除指定offerID产品信息的功能；offer永久删除的业务规则现有网站业务逻辑保持一致
        /// </summary>
        public string Delste(params  long[] offerIds)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/offer.delete/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerIds",string.Join(",", offerIds));
           
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);

            return results;
        }
        #region 橱窗
        /// <summary>
        /// 获取卖家的相关橱窗信息
        /// </summary>
        /// <returns></returns>
        public ShowWindowModel IndustryShowwindowQuery()
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/industry.showwindow.query/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ShowWindowResult>(url, otherParas);
            return results.showWindowModel;
        }
        /// <summary>
        /// 推荐一个产品为橱窗产品(目前诚信通用户可用)
        /// </summary>
        /// <param name="offerId">产品编号</param>
        /// <returns></returns>
        public RecommendOfferResult IndustryShowwindowDoRecommendOffer(long offerId)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/industry.showwindow.doRecommendOffer/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
            otherParas.Add("offerId", offerId.ToString());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ShowWindowDoRecommendOfferResult>(url, otherParas);
            if (results.error_code != null )
            {
                throw new AliResultException(results.error_message);
            }

            return results.resultMap;
        }
        /// <summary>
        /// 取消一个橱窗推荐产品(目前诚信通用户可用)
        /// </summary>
        /// <param name="offerId">产品编号</param>
        /// <returns></returns>
        public RecommendOfferResult IndustryShowwindowCancelRecommendOffer(long offerId)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/industry.showwindow.cancelRecommendOffer/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("offerId", offerId.ToString());
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ShowWindowDoRecommendOfferResult>(url, otherParas);
            if (results.error_code != null)
            {
                throw new AliResultException( results.error_message);
            }

            return results.resultMap;
        }
         /// <summary>
        /// 获取某个卖家已经推荐的橱窗产品列表
        /// </summary>
        /// <returns></returns>
        public List<OfferDetailInfo> DoQueryRecommOfferList()
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/industry.showwindow.doQueryRecommOfferList/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ShowWindowDoQueryRecommOfferListResult>(url, otherParas);
            if (!string.IsNullOrEmpty(results.error_code))
            {
                throw new AliResultException( results.error_message);
            }
             if (results.showWindowOfferList == null)
             {
                 results.showWindowOfferList=new List<OfferDetailInfo>();
             }
            return results.showWindowOfferList;
        }

        #endregion
        #region 微供


        /// <summary>
        /// (微供)根据供应商的名称获取该供应商的offerId列表。这是一个分页接口，需要提供起始位置和获取的数量。一次最多获取100条。 该API需要申请成为微供解决方案提供者才能使用。 
        /// </summary>
        /// <param name="marketSupplierLoginId">供应商账户名</param>
        /// <param name="offset">起始页</param>
        /// <param name="limit">每页数量(最大100)</param>
        /// <returns></returns>
        public GetOfferListResult GetOfferList(string marketSupplierLoginId, int offset, int limit)
        {
            string url = "http://gw.open.1688.com:80/openapi/param2/1/com.alibaba.commissionSale.microsupply/alibaba.china.microsupply.open.getOfferList/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            if (marketSupplierLoginId.IsNotNullOrEmpty())
            {

                otherParas.Add("marketSupplierLoginId", marketSupplierLoginId);
            }

            otherParas.Add("offset", offset + "");
            otherParas.Add("limit", limit + "");
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<GetOfferListResult>(url, otherParas);
           
            return results;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId">商品ID</param>
        /// <param name="webSite">站点信息，指定调用的API是属于国际站（alibaba）还是1688网站（1688）</param>
        /// <returns></returns>
        public ProductInfoGetResult GetWeiGonOfferInfo(long productId, string webSite = "1688")
        {

            string url = "http://gw.open.1688.com:80/openapi/param2/1/com.alibaba.commissionSale/alibaba.product.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            if (productId != default(long))
            {
                otherParas.Add("productID", productId + "");
            }
            otherParas.Add("webSite", webSite);

            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<ProductInfoGetResult>(url, otherParas);
            return results;


        }



        #endregion
    }
}