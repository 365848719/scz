using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scz.CqrsMediatR.Models
{
    public class CreateOrderRequestModel:IRequest<string>
    {
        public string UserId { get; set; }
        public string CardNumber { get; set; }
    }
}
