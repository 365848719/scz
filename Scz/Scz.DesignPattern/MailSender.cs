using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class MailSender : ISender
    {
        public void Send()
        {
            Console.WriteLine("Mail 发送者。。。。。。");
        }
    }
}