using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scz.CqrsMediatR.Events
{
    public class OrderCreatedEvent:INotification
    {
        public string UserId { get; set; }

        public OrderCreatedEvent(string orderId)
        {
            this.UserId = orderId;
        }

    }
}
