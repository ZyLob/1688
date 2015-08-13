using System.Collections.Generic;
using System.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Companys
{
    /// <summary>
    /// 阿里公司库操作Api
    /// </summary>
    public class CompanyApi
    {
        private readonly AliContext _context;

        public CompanyApi(AliContext context)
        {
            _context = context;
        }

        ///  <summary>
        /// 获取阿里巴巴中国网站会员的公司库信息 不需要授权
        ///  </summary>
        /// <remarks>
        /// 接口文档地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=company.get&v=1
        /// </remarks>
        /// <param name="accessToken">可选 阿里授权访问口令 没有访问口令时不返回私密数据</param>
        /// <param name="memberId">必填 会员ID</param>
        /// <param name="returnFields">可选 自定义返回字段。在companInfo结构中选择需要返回的字段名称，半角逗号分隔</param>
        /// <returns>阿里巴巴中国网站会员的公司信息</returns>
        public  AliCompanyInfo GetAliCompanyInfo(string memberId, string accessToken=null, string returnFields = null)
        {

            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/company.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = new Dictionary<string, string>();
            otherParas.Add("memberId", memberId);
            if (returnFields != null)
            {
                otherParas.Add("returnFields", returnFields);
            }
            if (!accessToken.IsNullOrWhiteSpace())
            {
                otherParas.Add("access_token", accessToken);
            }
            _context.Util.AddAliApiUrlSignPara( url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<List<AliCompanyInfo>>>>(url, otherParas);
            if (results.Result.Success && results.Result.ToReturn.Count > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }
    }
}
