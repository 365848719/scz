using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Scz.CqrsMediatR.Events;
using Scz.CqrsMediatR.Models;

namespace Scz.CqrsMediatR.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequestModel, string>
    {
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IMediator mediator) {
            this._mediator = mediator;        
        }

        public async Task<string> Handle(CreateOrderRequestModel request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"{request.UserId}，准备发布命令。。。。");

            await _mediator.Publish(new OrderCreatedEvent(request.UserId), cancellationToken);
            return request.UserId;
        }
    }
}
