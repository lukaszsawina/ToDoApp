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
        public void ChangeDataStatus(string storedProcedure, TaskModel task, string connectionID = "taskDB")
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(connectionID)))
            {
                conn.Execute(storedProcedure, new { TaskId = task.Id, Status = "Done" }, commandType: CommandType.StoredProcedure);
            }
        }

        public void ChangeTaskData(string storedProcedure, TaskModel parameter, string connectionID = "taskDB")
        {
            using (IDbConnection conn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal(connectionID)))
            {
                conn.Execute(storedProcedure, new { TaskId = parameter.Id, TaskName = parameter.TaskName, TaskExpirationDate = parameter.ExpirationDate, TaskStatus = parameter.Status }, commandType: CommandType.StoredProcedure);


            }
        }

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
