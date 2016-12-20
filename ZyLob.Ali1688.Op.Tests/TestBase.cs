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
             AliContext.Static.AccessToken = "45b883ef-30a2-4117-b61f-262c9139ee25";
            
        }
    }
}
