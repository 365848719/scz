using System;
using System.Collections.Generic;
using System.Text;

namespace Scz.Aop
{
    class CoreBusiness
    {
        [Log(ActionName = "Work_1")]
        public void Work_1()
        {
            Console.WriteLine("执行Work_1核心业务");
        }
    }
}
