using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Scz.WebApi.Controllers
{
    //使用APIVersionNeutral指定不需要版本控制的API
    //在编写API的时候，对于一些非常简单的API， 我们可能不需要指定API版本号, 例如健康检查API。
    //我们可以使用APIVersionNeutral特性，将它从API版本控制中排除掉。
    [ApiVersionNeutral]
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        public string Get()
        {
            return "good";
        }
    }
}