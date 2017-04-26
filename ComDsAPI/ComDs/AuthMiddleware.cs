using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ComDs
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            httpContext.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type,Accept,Z-Key,Authorization");
            httpContext.Response.Headers.Add("Content-Type", "application/json");
            httpContext.Response.Headers.Add("Access-Control-Allow-Methods", "GET,POST,PUT,DELETE,OPTIONS");
            if (httpContext.Request.Method.ToUpper() == "OPTIONS")
            {
                httpContext.Response.StatusCode = 200;
                return httpContext.Response.WriteAsync("success");
            }
            //检测是否包含'Authorization'请求头，如果不包含返回context进行下一个中间件，用于访问不需要认证的API
            if (!httpContext.Request.Headers.ContainsKey("Authorization"))
                return _next(httpContext);
            else
            {
                var tokenHeader = httpContext.Request.Headers["Authorization"];
                try
                {
                    tokenHeader = tokenHeader.ToString().Substring("Bearer ".Length).Trim();
                    var result = Config.StoreSignedUser.list.Where(m => m.userToken == tokenHeader).FirstOrDefault();
                    if (result == null)
                        return httpContext.Response.WriteAsync("401");
                    else
                    {
                        result.expire = DateTime.Now.AddHours(12);
                        httpContext.Response.Headers.Add("token", result.userToken);
                        List<Claim> userClaims = new List<Claim>
                        {
                            new Claim("normalUser","normal")
                        };
                        ClaimsIdentity identity = new ClaimsIdentity(userClaims);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        httpContext.User = principal;
                        return _next(httpContext);
                    }
                }
                catch (Exception)
                {
                    return httpContext.Response.WriteAsync("token值长度不够");
                }
            }
        }
    }
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}

