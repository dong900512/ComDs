using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComDs.Config
{
    public class StoreSignedUser
    {
        public static List<SignedUser> list = new List<SignedUser>();//已登录用户
        public static IEnumerable<SignedUser> GetSingedUser()
        {
            return list;
        }
        /// <summary>
        /// 新增已登录用户
        /// </summary>
        /// <param name="user"></param>
        public static void AddSignedUser(SignedUser user)
        {
            list.Add(user);
        }
    }
}
