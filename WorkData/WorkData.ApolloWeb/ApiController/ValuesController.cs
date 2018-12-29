using Microsoft.AspNetCore.Mvc;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Dependency;
using Newtonsoft.Json;
using System;
using WorkData.EntityFramework;

namespace WorkData.ApolloWeb.ApiController
{
    [ApiController]
    [Route("api/Values")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get(string key)
        {
            var data = IocManager.Instance.ResolveEntityServiceValue<WorkDataDbContextOptions>(key);
            return Json(data);
        }
    }
}