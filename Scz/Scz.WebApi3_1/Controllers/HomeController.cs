using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scz.WebApi3_1.Attribute;
using Scz.WebApi3_1.Services;

namespace Scz.WebApi3_1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ICustomService _customService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICustomService customService,ILogger<HomeController> logger) {
            this._customService = customService;
            this._logger = logger;
        }

        // GET: api/Home
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _customService.Call();

            Console.WriteLine(DateTime.Now.ToString());

            _logger.LogInformation("Serilog test info.");
            _logger.LogError("Serilog test error.");

            return new string[] { "value1", "value2" };
        }

        // GET: api/Home/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Home/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
