using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WorkData.Code.UnitOfWorks;
using WorkData.Web.Extensions.Infrastructure;

namespace WorkData.Web.ApiController
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ValuesController : WorkDataBaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        [UnitOfWork]
        public IEnumerable<string> Get()
        {
            var ss = WorkDataSession;
            var user = GetClaimValue(ClaimTypes.Name);
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        ///     从申明中获取值
        /// </summary>
        /// <param name="claimType">申明类型（姓名，年龄，国籍，爱好等）</param>
        /// <returns></returns>
        private string GetClaimValue(string claimType)
        {
            var ss = HttpContext.User as ClaimsPrincipal;
            var claim = HttpContext.User?.Claims.FirstOrDefault(c => c.Type == claimType);

            return string.IsNullOrEmpty(claim?.Value) ? "" : claim.Value;
        }
    }
}