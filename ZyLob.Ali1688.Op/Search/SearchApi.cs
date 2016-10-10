using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Common;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Search
{
    /// <summary>
    /// 阿里搜索栏目api
    /// </summary>
   public  class SearchApi
    {
        private readonly AliContext _context;

        public SearchApi(AliContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 标题堆砌，用来检测offer标题中是否存在堆砌多个关键词的情况，包括产品词堆砌，型号词堆砌，品牌堆砌等
        /// </summary>
        /// <param name="title">Offer标题,对应为offer的标题，字段名为title</param>
        /// <param name="catId">Offer 发布类目id,对应为offer的发布类目id，字段名为catid</param>
        /// <returns>对于检测到作弊的，会在 type中标示具体的作弊类型(CP|XH|PP|XSC)，否则为none，CP对应产品词堆砌，XH对应型号词堆砌，PP对于品牌词堆砌，XSC对应产品修饰词修饰。相对应的，会有具体字段提示引起堆砌的词具体信息。</returns>
        public string TitleStuffing(string title,string catId)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/search.title.stuffing/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("title", title);
            otherParas.Add("catid", catId);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;           
        }
        /// <summary>
        /// 标题属性不一致
        /// 用来判断，用户标题和属性中填写的信息是否一致，是否存在冲突的关键属性
        /// </summary>
        /// <param name="title">Offer标题,对应为offer的标题，字段名为title</param>
        /// <param name="brief">Offer属性,对应为offer的属性，字段名为brief。brief的字段格式要求为： key：value 多个间空格分开</param>
        /// <param name="catId">Offer 发布类目id,对应为offer的发布类目id，字段名为catid</param>
        /// <returns>对于存在不一致的，会在TYPE输出对应的作弊程度，没有作弊的会标示为NONE.其他字段比如ANTIVAL，KEY标示具体的属性KEY下存在冲突的VAL。</returns>
        public string TitlePropertiesInconsistent(string title, string catId,string brief)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/search.title.properties.inconsistent/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("title", title);
            otherParas.Add("catid", catId);
            otherParas.Add("brief", brief);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;
        }
        /// <summary>
        /// 属性滥用
        /// 判断用户填写的属性是否存在滥用，比如属性值多个重复使用，属性值过长，以及属性值无意义等。
        /// </summary> 
        /// <param name="title">Offer标题,对应为offer的标题，字段名为title</param>
        /// <param name="brief">Offer属性,对应为offer的属性，字段名为brief。brief的字段格式要求为： key：value 多个间空格分开</param>
        /// <returns>对于存在属性滥用的，会在OFFERLEVEL输出对应的作弊程度，没有作弊的会标示为NONE.其他字段会标示具体的引起属性滥用的原因以及具体的属性KEY和VALUE</returns>
        public string PropertiesAbuse(string title, string brief)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/search.properties.abuse/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("title", title);
            otherParas.Add("brief", brief);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;
        }
        /// <summary>
        /// 类目作弊
        /// 用户在发布offer时候，需要选择对应的发布类目，类目作弊就是用来检测选择的类目跟发布的offer信息是否匹配
        /// </summary>
        /// <param name="title">Offer标题,对应为offer的标题，字段名为title</param>
        /// <param name="catId">Offer 发布类目id,对应为offer的发布类目id，字段名为catid</param>
        /// <param name="userId">卖家id（1688的memberId）,对应为该offer的旺铺userid</param>
        ///  <returns>对于检测到类目作弊的，在type字段中，会标示为anti，否则为none。同时系统会推荐一到多个类目id，分别在catid，catname，以及score中标示，解析相关字段就可以得到。</returns>
        public string CategoryCheating(string title, string catId,string userId)
        {
            string url = "http://gw.open.1688.com/openapi/param2/1/cn.alibaba.open/search.category.cheating/{0}".FormatStr(_context.Config.AppKey);
            var otherParas = _context.GetParas();
            otherParas.Add("title", title);
            otherParas.Add("catid", catId);
            otherParas.Add("userid", userId);
            _context.Util.AddAliApiUrlSignPara(url, otherParas);
            var results = _context.Util.Send<string>(url, otherParas);
            return results;
        }
    }
}
