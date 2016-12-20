using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;
using ZyLob.Ali1688.Op.Models;

namespace ZyLob.Ali1688.Op.Member
{
    /// <summary>
    /// 会员接口
    /// </summary>
    public class MemberApi
    {
        private readonly AliContext _context;

        public MemberApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 通过列表loginIds查询对应的memberId，该API一次批量最大数不要超过110个。
        /// </summary>
        /// <remarks>
        /// 不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=convertLoginIdsByMemberIds&v=1
        /// </remarks>
        /// <param name="loginIds">阿里登录id集合</param>
        /// <returns>阿里登录编号(Key)对应会员编号(Value)</returns>
        public Dictionary<string, string> LoginIdToMemberId(params string[] loginIds)
        {
            if (loginIds.Length == 0)
            {
                return new Dictionary<string, string>();
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/convertMemberIdsByLoginIds/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            var loginIdStr = "['{0}']".FormatStr(string.Join("','", loginIds));
            otherParas.Add("loginIds", loginIdStr);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var kvs = _context.Util.Send<JObject>(url, otherParas);
            return kvs.Properties().ToDictionary(k => k.Name, v => v.Value.ToObject<string>());
           
        }

        /// <summary>
        /// 批量转换memberId到loginId (最大数量不超过110个，数量太大时抛出异常)
        /// </summary>
        /// <remarks>
        /// 不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=convertMemberIdsByLoginIds&v=1
        /// </remarks>
        /// <param name="memberIds">阿里会员编号集合</param>
        /// <returns>阿里会员编号(key)对应登录编号(Value)</returns>
        public Dictionary<string, string> MemberIdToLoginId(params string[] memberIds)
        {
            if (memberIds.Length == 0)
            {
                return new Dictionary<string, string>();
            }
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/convertLoginIdsByMemberIds/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            var loginIdStr = "['{0}']".FormatStr(string.Join("','", memberIds));
            otherParas.Add("memberIds", loginIdStr);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<JObject>(url, otherParas);
            var kvs = results["loginIdMap"].Value<JObject>();
            return kvs.Properties().ToDictionary(k => k.Name, v => v.Value.ToObject<string>());

        }

        /// <summary>
        /// 获取单个阿里巴阿中国网站会员信息。非会员本人只返回非隐私数据
        /// </summary>
        /// <remarks>
        /// 不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=member.get&v=1
        /// </remarks>
        /// <param name="memberId">阿里会员编号</param>
        /// <param name="returnFields">返回字段</param>
        /// <returns>阿里会员信息</returns>
        public AliMemberInfo GetMemberInfo(string memberId,
            string returnFields =
                "memberId,status,isTP,haveSite,isPersonalTP,isEnterpriseTP,isMarketTP,isETCTP,haveDistribution,isDistribution,isMobileBind,isEmailBind,havePrecharge,isPrecharge,isCreditProtection,isPublishedCompany,isAlipayBind,personalFileAddress,winportAddress,domainAddress,trustScore,trustProductAddress,companyAddress,createTime,lastLogin,companyName,industry,product,homepageUrl,sellerName,sex,department,openJobTitle,email,telephone,fax,mobilePhone,addressLocation")
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/member.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("memberId", memberId);
            otherParas.Add("returnFields", returnFields);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliMemberInfo>>>(url, otherParas);

            if (results.Result!=null&&results.Result.ToReturn.Count > 0)
            {
                return results.Result.ToReturn.First();
            }
            return null;
        }

        /// <summary>
        /// 获取会员诚信信息
        /// </summary>
        /// <remarks>
        /// 不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=creditInfo.get&v=1
        /// </remarks>
        /// <param name="memberIds">阿里会员编号</param>
        /// <returns>阿里诚信信息</returns>
        public List<AliMemberIntegrityInfo> GetMemberIntegrityInfo(params  string[] memberIds)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/creditInfo.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("memberIds", string.Join(";", memberIds));
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<AliMemberIntegrityInfo>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                return results.Result.ToReturn;
            }
            return new List<AliMemberIntegrityInfo>();
        }

        /// <summary>
        /// 获取省份编码信息
        /// </summary>
        /// <remarks>
        /// 不需要授权
        /// 接口地址：http://open.1688.com/doc/api/cn/api.htm?ns=cn.alibaba.open&n=areaCode.get&v=1
        /// </remarks>
        /// <returns>省份编码信息</returns>
        public Dictionary<string,long> GetAreaCode()
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/areaCode.get/{0}".FormatStr(_context.Config.AppKey);
            var otherParas =_context.GetParas();
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<AliResult<AliResultList<JObject>>>(url, otherParas);
            if (results.Result.Total > 0)
            {
                var result = results.Result.ToReturn.First();
               return result.Properties().ToDictionary(k=>k.Name,v=>v.Value.ToObject<long>());
              
            }
            return new Dictionary<string, long>();
        }
    }
}
