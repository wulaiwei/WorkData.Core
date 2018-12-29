// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：OAuthController.cs
// 创建标识：吴来伟 2018-06-21 14:00
// 创建描述：
//
// 修改标识：吴来伟2018-06-21 16:11
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WorkData.BaseWeb.Infrastructure;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Dependency;
using WorkData.Web.Models.OAuths;

#endregion

namespace WorkData.Web.ApiController
{
    [Route("/api/oauth")]
    public class OAuthController : WorkDataBaseApiController
    {
        public WorkDataBaseJwt WorkDataBaseJwt { get; set; } =
            IocManager.Instance.ResolveServiceValue<WorkDataBaseJwt>();

        /// <summary>
        ///     AccessToken
        /// </summary>
        /// <param name="requestOAuthViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("access_token")]
        public IActionResult AccessToken([FromBody] RequestOAuthViewModel requestOAuthViewModel)
        {
            var claim = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, "1"),
                new Claim(ClaimTypes.Name, requestOAuthViewModel.UserName),
                new Claim(ClaimTypes.Role, "admin")
            };

            //对称秘钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(WorkDataBaseJwt.SecretKey));
            //签名证书(秘钥，加密算法)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                WorkDataBaseJwt.Issuer,
                WorkDataBaseJwt.Audience,
                claim, DateTime.Now,
                DateTime.Now.AddMinutes(WorkDataBaseJwt.Expires),
                creds);

            return AsSuccessJson(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}