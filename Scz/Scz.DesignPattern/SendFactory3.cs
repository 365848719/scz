using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class SenderFactory3
    {
        public static ISender ProduceMail()
        {
            return new MailSender();
        }

        public static ISender ProduceSms()
        {
            return new SmsSender();
        }
    }
}