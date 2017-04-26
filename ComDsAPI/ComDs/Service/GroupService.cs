using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ComDs.Models;

namespace ComDs.Service
{
    public class GroupService
    {
        private readonly DapperCon _dapper;
        public GroupService(DapperCon dapper)
        {
            this._dapper = dapper;
        }
        public IEnumerable<ComGroup> GetList()
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select * from ComGroup";
                return db.Query<ComGroup>(query);
            }
        }
    }
}
