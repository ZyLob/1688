using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ZyLob.Ali1688.Op.Common
{
    /// <summary>
    /// 枚举标注特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Enum)]
    public class EnumDescription : Attribute
    {
        public EnumDescription(string remark,string textTag="")
        {
            this.Remark = remark;
            this.TextTag = textTag;
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 文本标识,枚举内唯一标识可用来转换
        /// </summary>
        public string TextTag { get; set; }
    }

    /// <summary>
    /// 枚举帮助类
    /// </summary>
    public class EnumUtils
    {
        //枚举转后的字典存储哈希表
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 枚举转为字典(枚举特性)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        public static Dictionary<int, string> FindAll<TEnum>()
            where TEnum: struct
        {
            Type enumType = typeof(TEnum);
            string cacheKey = "V_Desc"+enumType.Name;
            object cache = parmCache[cacheKey];
            if (cache != null)
                return cache as Dictionary<int, string>;
            if (parmCache.ContainsKey(cacheKey))
            {
                parmCache.Remove(cacheKey);
            }

            var fields = enumType.GetFields();

            var dicEnum = new Dictionary<int, string>();
            EnumDescription[] eds = null;
            foreach (var field in fields)
            {
                eds = field.GetCustomAttributes(typeof(EnumDescription), true) as EnumDescription[];
                if (eds != null && eds.Length > 0)
                {
                    dicEnum.Add((int)field.GetValue(null), eds[0].Remark);
                }
            }
            parmCache.Add(cacheKey, dicEnum);
            return dicEnum;
        }
        /// <summary>
        /// 获取指定枚举值的描述
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <param name="nullValue">没有找到时的返回值</param>
        public static string GetDescription<TEnum>(int value, string nullValue)
            where TEnum : struct
        {
            var list = FindAll<TEnum>();
            string description = string.Empty;
            if (list.TryGetValue(value, out description))
                return description;
            return nullValue;
        }

        /// <summary>
        /// 枚举转为字典(枚举特性)
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <typeparam name="TEnumDesc">标识属性类型</typeparam>
        public static Dictionary<TEnum, TEnumDesc> FindAll<TEnum, TEnumDesc>()
            where TEnumDesc:Attribute where TEnum : struct
        {
            Type enumType = typeof(TEnum);
            string cacheKey = "Type_DescObj" + enumType.Name;
            object cache = parmCache[cacheKey];
            if (cache != null)
                return cache as Dictionary<TEnum, TEnumDesc>;
            if (parmCache.ContainsKey(cacheKey))
            {
                parmCache.Remove(cacheKey);
            }
            var fields = enumType.GetFields();

            var dicEnum = new Dictionary<TEnum, TEnumDesc>();
            TEnumDesc[] eds = null;
            foreach (var field in fields)
            {
                eds = field.GetCustomAttributes(typeof(TEnumDesc), true) as TEnumDesc[];
                if (eds != null && eds.Length > 0)
                {
                    dicEnum.Add((TEnum)field.GetValue(null), eds[0]);
                }
            }
            parmCache.Add(cacheKey, dicEnum);
            return dicEnum;
        }
        /// <summary>
        /// 获取指定枚举值的描述
        /// </summary>
        /// <param name="value">枚举值</param>
        public static TEnumDesc GetDescription<TEnum, TEnumDesc>(TEnum value)
            where TEnum : struct where TEnumDesc:Attribute
        {
            var list = FindAll<TEnum, TEnumDesc>();
            TEnumDesc description = null;
            if (list.TryGetValue(value, out description))
                return description;
            return null;
        }
        /// <summary>
        /// 通过文本标识转换成指定类型的枚举
        /// </summary>
        /// <typeparam name="TEnum">指定类型的枚举</typeparam>
        /// <param name="textTag">EnumDescription中的文本标识</param>
        /// <returns>指定类型的枚举</returns>
        public static TEnum TextTagToEnum<TEnum>(string textTag)
            where TEnum : struct
        {
            var list = FindAll<TEnum, EnumDescription>();
            var currEnum= list.FirstOrDefault(kv => kv.Value.TextTag.ToUpper() == textTag.ToUpper());
            return currEnum.Key;
        }
       
    }
}

