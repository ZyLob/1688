using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZyLob.Ali1688.Op.Models;
using ZyLob.Ali1688.Op.Product;

namespace ZyLob.Ali1688.Op.MvcDemo.Controllers
{
    /// <summary>
    /// 产品Demo控制器
    /// </summary>
    public class ProductController : Controller
    {
      
        /// <summary>
        /// 产品搜索
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductList()
        {
            //产品搜索
            var products = ProductApi.ProductSeach(new ProductSeachModel
            {
                MemberId = "szhf0"
            });
            var pageSize = products.PageSize;
            return View();
        }
        /// <summary>
        /// 获取单个产品
        /// </summary>
        /// <returns></returns>
        public ActionResult ProductOne()
        {
            var product = ProductApi.GetProductByOfferId("899955287");
            return View();
        }

    }
}
