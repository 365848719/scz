using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    public class PartnerB : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.Bwin(money);
        }
    }
}