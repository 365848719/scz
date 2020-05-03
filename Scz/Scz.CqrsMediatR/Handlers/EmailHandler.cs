using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using Microsoft.Extensions.Logging;
using Scz.CqrsMediatR.Models;

namespace Scz.CqrsMediatR.Handlers
{
    public class EmailHandler : INotificationHandler<NewUser>
    {    
        public Task Handle(NewUser notification, CancellationToken cancellationToken)
        {
            //Send email  
            Console.WriteLine(" ****  Email sent to user  *****");
            return Task.FromResult(true);
        }
    }
}
