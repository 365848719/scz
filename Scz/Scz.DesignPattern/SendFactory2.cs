using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class SenderFactory2
    {
        public ISender ProduceMail()
        {
            return new MailSender();
        }

        public ISender ProduceSms()
        {
            return new SmsSender();
        }

    }
}