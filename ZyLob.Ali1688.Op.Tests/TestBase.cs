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
            AliContext.Static.AccessToken = "f8b2c4b8-e5be-49e2-8eec-eeb8655a6fb7";
            
        }
    }
}
