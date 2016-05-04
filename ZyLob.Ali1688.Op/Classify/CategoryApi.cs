using System.Collections.Generic;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Classify
{
   public class CategoryApi
    {
        private readonly AliContext _context;

        public CategoryApi(AliContext context)
        {
            _context = context;
        }
       /// <summary>
        /// 根据类目ID获取发布类目信息
       /// </summary>
        /// <param name="catIds">类目ID集合</param>
        /// <returns>发布类目信息集合</returns>
       public List<Category> GetPostCatList(params long[] catIds)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/category.getPostCatList/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("catIDs", string.Join(",",catIds));
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<Category>>>(url, otherParas);
           
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<Category>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 根据父类目ID获取其子类目信息
       /// </summary>
       /// <param name="categoryId">父类目ID</param>
       /// <param name="getAllChildren">获取该父类目的所有子类目 取值“T” （取全部子类目信息）或 “F”（只取一级子类目信息），默认“F”。	</param>
       /// <returns>子类目信息集合</returns>
       public List<Category> GetCatListByParentId(long categoryId, string getAllChildren = "F")
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/category.getCatListByParentId/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("parentCategoryID", categoryId+"");
           otherParas.Add("getAllChildren", getAllChildren);
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<Category>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<Category>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 通过大市场叶子类目id，获取该类目的发布类目路径
       /// </summary>
       /// <param name="categoryId">类目id</param>
       /// <returns>类目信息集合（从根目录往下）</returns>
       public List<Category> GetCatePath(long categoryId)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/category.getCatePath/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("categoryID", categoryId + "");
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<Category>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<Category>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 通过输入中文站大市场发布的叶子类目，返回其对应的产品属性信息（建议使用API“根据类目ID获取类目发布属性信息offerPostFeatures.get ”，获得所有发布相关属性信息）
       /// </summary>
       /// <param name="categoryId">类目id</param>
       /// <returns>属性集合</returns>
       public List<ProductAttributesInfo> GetProductAttributes(long categoryId)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/productAttributes.get/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("categoryID", categoryId + "");
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<ProductAttributesInfo>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<ProductAttributesInfo>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 根据叶子类目ID获取类目发布属性信息
       /// </summary>
       /// <param name="categoryId">类目Id</param>
       /// <returns>类目属性集合</returns>
       public List<CategoryFeature> GetOfferPostFeatures(long categoryId)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/offerPostFeatures.get/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("categoryID", categoryId + "");
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<CategoryFeature>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<CategoryFeature>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 通过输入用户填写的某个类目关键产品属性，返回该类目产品属性的SPU信息
       /// </summary>
       /// <param name="categoryId">叶子类目ID</param>
       /// <param name="keyAttributes">产品关键属性和值，以“>”为分隔符，输入格式如示例 ：属性:属性值>属性:属性值</param>
       /// <returns>类目产品属性的SPU信息</returns>
       public List<SpubyattributeResult> GetSpubyattribute(long categoryId, string keyAttributes)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/spubyattribute.get/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("categoryID", categoryId + "");
           otherParas.Add("keyAttributes", keyAttributes);
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<SpubyattributeResult>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<SpubyattributeResult>();
           }
           return results.Result.ToReturn;
       }
       /// <summary>
       /// 根据类目属性名和值获取子属性名和值域
       /// </summary>
       /// <param name="categoryId">叶子类目ID</param>
       /// <param name="pathValues">属性名和属性值以冒号隔开，子属性以大于号隔开。如offer发布连衣裙类目中，要获取 货源类别: 现货 > 是否库存: 是 下面的属性名和属性值，传入 100000691:46874>7108:21958	</param>
       /// <returns>类目属性集合</returns>
       public List<CategoryFeature> GetCategoryAttrLevel(long categoryId, string pathValues)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/category.level.attr.get/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("catId", categoryId + "");
           otherParas.Add("pathValues", pathValues);
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<CategoryFeatureResult>(url, otherParas);
           if (results.categoryFeatures == null)
           {
               results.categoryFeatures = new List<CategoryFeature>();
           }
           return results.categoryFeatures;
       }
       /// <summary>
       /// 输入关键词,搜索相关的类目ID
       /// </summary>
       /// <param name="keyWord">关键词</param>
       /// <returns>类目ID集合</returns>
       public List<long> Search(string keyWord)
       {
           string url = "http://gw.open.1688.com:80/openapi/param2/1/cn.alibaba.open/category.search/{0}".FormatStr(_context.Config.AppKey);
           var otherParas = _context.GetParas();
           otherParas.Add("keyWord", keyWord);
           _context.Util.AddAliApiUrlSignPara(url, otherParas);
           var results = _context.Util.Send<AliResult<AliResultList<long>>>(url, otherParas);
           if (results.Result.ToReturn == null)
           {
               results.Result.ToReturn = new List<long>();
           }
           return results.Result.ToReturn;
       }
    }

  
}
