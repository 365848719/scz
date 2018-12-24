using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using RestSharp;
using Scz.Common;

namespace Scz.WebApi.Controllers
{
    [Route("api/myValues")]
    [ApiController]
    public class MyValuesController : ControllerBase
    {
        public StarInfo StarInfoConfig { get; set; }
        public ServiceAddress ServiceAddress { get; set; }
        public string BaseUrl { get; set; } = "http://localhost:57941/";

        public MyValuesController(IOptions<StarInfo> setting,IOptions<ServiceAddress> addressSetting)
        {
            StarInfoConfig = setting.Value;
            ServiceAddress = addressSetting.Value;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2","value3" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var s = StarInfoConfig;

            var client = new RestSharpClient(BaseUrl);
            var restRequest = new RestRequest("api/values/{id}", Method.GET);
            restRequest.AddUrlSegment("id", id);

            var result = client.Execute(restRequest).Content;

            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
