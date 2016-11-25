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
             AliContext.Static.AccessToken = "7928cb7c-d7ba-428b-a216-60fa90678118";
            
        }
    }
}
