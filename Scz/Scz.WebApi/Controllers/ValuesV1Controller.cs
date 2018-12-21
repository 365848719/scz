using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Scz.WebApi.Controllers
{
    [ApiVersion("1.0",Deprecated = true)]
    [Route("api/{v:apiVersion}/values")]
    [ApiController]
    public class ValuesV1Controller : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Value1 from version1","Value2 from version1"};
        }
    }
}