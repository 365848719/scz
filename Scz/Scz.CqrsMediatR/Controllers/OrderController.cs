using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MediatR;
using Scz.CqrsMediatR.Models;

namespace Scz.CqrsMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateOrderRequestModel requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]GetOrderByIdRequestModel requestModel)
        {
            var response = await _mediator.Send(requestModel);
            return Ok(response);
        }

    }
}