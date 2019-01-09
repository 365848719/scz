using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class SenderFactory
    {
        public ISender Product(string type)
        {
            if(type == "sms")
            {
                return new SmsSender();
            }
            else if(type == "mail")
            {
                return new MailSender();
            }

            return null;
        }
    }
}