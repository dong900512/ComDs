using ComDs.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ComDs.Service
{
    public class SortService
    {
        private readonly DapperCon _dapper;
        public SortService(DapperCon dapper)
        {
            this._dapper = dapper;
        }
        public IEnumerable<ComSort> GetListByGroupID(int id)
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select * from ComSort where ComSort.GroupID = '{id}'";
                return db.Query<ComSort>(query);
            }
        }

        public IEnumerable<ComSort> GetListByUserID(string id)
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select * from ComSort where ComSort.UserID = '{id}'";
                return db.Query<ComSort>(query);
            }
        }
        public ComSort FindItemByID(int id)
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                string query = $@"select * from ComSort where ComSort.SortID = '{id}'";
                return db.QueryFirstOrDefault<ComSort>(query);
            }
        }
        public int ProduceRandom(ComSort sort)
        {
            using (IDbConnection db = _dapper.GetDbConn())
            {
                var groupItems = this.GetListByGroupID(sort.GroupID);
                List<int> nums = new List<int>();
                for (int i = 1; i < groupItems.Count() + 1; i++)
                {
                    nums.Add(i);
                }
                string randomedItemsQuery = $@"select * from ComSort where ComSort.GroupID = '{sort.GroupID}' and ComSort.RandomID != '0'";
                var randomedItems = db.Query<ComSort>(randomedItemsQuery).Select(m => m.RandomID);
                var notRandomItems = nums.Where(m => !randomedItems.Contains(m));
                int count = notRandomItems.Count();
                Random rand = new Random();
                int num = rand.Next(0, count);
                int randomNum = notRandomItems.AsList()[num];
                string query = $@"update ComSort set Comsort.RandomID = '{randomNum}' where SortID= '{sort.SortID}'";
                db.Execute(query);
                return randomNum;
            }
        }
    }
}
