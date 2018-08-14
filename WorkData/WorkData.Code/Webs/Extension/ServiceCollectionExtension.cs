using System;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WorkData.Code.JwtSecurityTokens;
using WorkData.Extensions.ServiceCollections;

namespace WorkData.Code.Webs.Extension
{
    public static class ServiceCollectionExtension
    {
        public static AuthenticationBuilder AddWorkDataJwt(this IServiceCollection services)
        {
            var workDataBaseJwt = services.ResolveServiceValue<WorkDataBaseJwt>();
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            var authenticationBuilder = services.AddAuthentication();

            services.AddAuthentication(options =>
            {
                //认证middleware配置
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

            authenticationBuilder.AddJwtBearer(o =>
            {
                //主要是jwt  token参数设置
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    //Token颁发机构
                    ValidIssuer = workDataBaseJwt.Issuer,
                    //颁发给谁
                    ValidAudience = workDataBaseJwt.Audience,
                    //这里的key要进行加密，需要引用Microsoft.IdentityModel.Tokens
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(workDataBaseJwt.SecretKey)),
                    //ValidateIssuerSigningKey=true,
                    ////是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    ValidateLifetime = true,
                    ////允许的服务器时间偏移量
                    ClockSkew = TimeSpan.Zero
                };
            });
            return authenticationBuilder;
        }
    }
}