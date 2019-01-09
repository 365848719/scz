using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class SmsFactory : IMethodFactory
    {
        public ISender Produce()
        {
            return new SmsSender();
        }
    }
}