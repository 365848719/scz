using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scz.CqrsMediatR.Models;

namespace Scz.CqrsMediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpPost]
        public Task Register(NewUser user)
        {
            _mediator.Publish(user);

            return Task.CompletedTask;
        }

    }
}