using System.Web.Mvc;
using ZyLob.Ali1688.Op.Authorization;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.MvcDemo.Controllers
{
    /// <summary>
    /// 授权demo控制器
    /// </summary>
    public class AuthController : Controller
    {
        //
        // GET: /Auth/

        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 阿里登录回调地址
        /// </summary>
        public JsonResult Login(string code)
        {
            //获取登录口令
            var token = AliContext.Static.Auth.GetAliToken(code);
           /*******
            * 
            * 登录操作并记录相关口令信息
            * 
            * *****/
            return Json("登录成功",JsonRequestBehavior.AllowGet);
        }

    }
}
