using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    public class AccessData : IAccessData
    {
        public List<TaskModel> LoadData(string viewName, string connectionID = "taskDB")
        {
            using(IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(connectionID)))
            {
                string sql = $"SELECT * FROM { viewName }";

                return conn.Query<TaskModel>(sql).ToList();
            }
        }

        public bool SaveData(string storedProcedure, TaskModel parameter, string connectionID = "taskDB")
        {
            throw new NotImplementedException();
        }
    }
}
