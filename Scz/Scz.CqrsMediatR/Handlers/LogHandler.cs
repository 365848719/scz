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
    public class LogHandler : INotificationHandler<NewUser>
    {
        
        public Task Handle(NewUser notification, CancellationToken cancellationToken)
        {
            //Save to log  
            Console.WriteLine(" ****  User save to log  *****");
            return Task.FromResult(true);
        }
    }
}
