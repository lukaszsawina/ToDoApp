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
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(connectionID)))
            {
                string sql = $"SELECT * FROM dbo.Task";

                return conn.Query<TaskModel>(sql).ToList();
            }
        }


        public bool SaveData(string storedProcedure, TaskModel parameter, string connectionID = "taskDB")
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(connectionID)))
            {

                conn.Execute(storedProcedure, new { taskName = parameter.TaskName, setDate = parameter.SetDate, expirationDate = parameter.ExpirationDate }, commandType: CommandType.StoredProcedure);

                return true;
            }
        }

    }
}
