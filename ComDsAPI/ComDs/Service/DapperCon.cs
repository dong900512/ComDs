using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper
{
    public class DapperCon
    {
        public string _conString { get; set; }
        public DapperCon(string conString)
        {
            this._conString = conString;
        }
        public IDbConnection GetDbConn()
        {
            return new SqlConnection(this._conString);
        }
    }
}
