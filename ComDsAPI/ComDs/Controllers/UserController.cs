using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ComDs.Service;
using ComDs.Models;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ComDs.Config;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComDs.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;
        public UserController(UserService useService)
        {
            this._userService = useService;
        }
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
            var list = _userService.GetList();
            return Json(list);
        }
        [HttpPost]
        public JsonResult Post([FromBody]ComUser user)
        {
            var result = this._userService.CheckUser(user);
            if (result == null)
            {
                return Json(new ResultState() { State = 500, Msg = "账号或者密码错误" });
            }
            else
            {
                var date = DateTime.UtcNow;
                Claim[] claims = new Claim[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, "test"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, date.ToString(), ClaimValueTypes.Integer64),
                };
                JwtSecurityToken jwt = new JwtSecurityToken(
                issuer: "LiuFang",
                audience: user.UserName,
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: new Microsoft.IdentityModel.Tokens
                .SigningCredentials
                (new SymmetricSecurityKey(Encoding.ASCII.GetBytes("LiuFangLiuFangLiuFangLiuFangLiuFang")), SecurityAlgorithms.HmacSha256)
                );
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                var response = new
                {
                    access_token = encodedJwt,
                    expires_in = DateTime.Now.AddHours(12),
                    token_type = "Bearer",
                };
                StoreSignedUser.AddSignedUser(new SignedUser(encodedJwt, result,date.AddHours(12)));
                return Json(response);
            }
        }
    }
}
