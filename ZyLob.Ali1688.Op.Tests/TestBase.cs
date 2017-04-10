using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZyLob.Ali1688.Op.Context;

namespace ZyLob.Ali1688.Op.Tests
{
    /// <summary>
    /// 单元测试基类
    /// </summary>
  public abstract class TestBase
    {
        public TestBase()
        {
             AliContext.Static.AccessToken = "79b2dc8a-093e-463f-ad0c-06f76a34beb3";
            
        }
    }
}
