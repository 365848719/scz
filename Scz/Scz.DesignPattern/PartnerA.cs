using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scz.DesignPattern
{
    /// <summary>
    /// 具体同事类
    /// </summary>
    public class PartnerA : AbstractCardPartner
    {
        public override void ChangeMoney(int money, AbstractMediator mediator)
        {
            mediator.Awin(money);
        }
    }
}