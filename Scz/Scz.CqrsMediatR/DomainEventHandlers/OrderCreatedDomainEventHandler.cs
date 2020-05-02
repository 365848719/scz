using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.Extensions.Logging;
using Scz.CqrsMediatR.Events;

namespace Scz.CqrsMediatR.DomainEventHandlers
{
    public class OrderCreatedDomainEventHandler : INotificationHandler<OrderCreatedEvent>
    {
        private readonly ILogger _logger;

        public OrderCreatedDomainEventHandler(ILogger<OrderCreatedDomainEventHandler> logger)
        {
            this._logger = logger;
        }

        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Order has found by userid id: {notification.UserId} from publisher");
            return Task.CompletedTask;
        }
    }
}
