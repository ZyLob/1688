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
            AliContext.Static.AccessToken = "98ffa523-9de4-4064-8827-9f9f858ab5bc";
            
        }
    }
}
