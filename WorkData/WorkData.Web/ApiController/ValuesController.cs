using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WorkData.Code.Webs.Infrastructure;

namespace WorkData.Web.ApiController
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ValuesController : WorkDataBaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}