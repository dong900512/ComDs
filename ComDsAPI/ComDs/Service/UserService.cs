using ComDs.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ComDs.Service
{
    public class UserService
    {
        private readonly DapperCon _dapper;
        public UserService(DapperCon dapper)
        {
            this._dapper = dapper;
        }
        public ComUser CheckUser(ComUser user)
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select * from ComUser where ComUser.UserName = '{user.UserName}' and ComUser.UserPwd = '{user.UserPwd}'";
                return db.QueryFirstOrDefault<ComUser>(query);
            }
        }
        public IEnumerable<ComUser> GetList()
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select UserName,userCaption from ComUser";
                return db.Query<ComUser>(query);
            }
        }
    }
}
