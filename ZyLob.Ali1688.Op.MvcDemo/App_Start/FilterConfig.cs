using System.Web;
using System.Web.Mvc;

namespace ZyLob.Ali1688.Op.MvcDemo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}