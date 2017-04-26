using ComDs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComDs.Config
{
    /// <summary>
    /// 已经登录的用户
    /// </summary>
    public class SignedUser
    {
        //jwt签名凭证
        public string userToken { get; set; }
        //用户唯一id名
        public ComUser  user { get; set; }
        public DateTime expire { get; set; }
        //用户声明属性
        public SignedUser(string userToken,ComUser user,DateTime expire)
        {
            this.userToken = userToken;
            this.user = user;
            this.expire = expire;
        }
    }
}
