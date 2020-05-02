﻿using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scz.CqrsMediatR.Models
{
    public class GetOrderByIdRequestModel:IRequest<string>
    {
        public string OrderId { get; set; }
    }
}
