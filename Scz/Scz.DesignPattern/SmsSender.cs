using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class SmsSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("SMS 发送者。。。。。。");
        }
    }
}