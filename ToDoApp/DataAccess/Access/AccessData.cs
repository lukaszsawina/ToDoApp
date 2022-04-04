using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    public class AccessData
    {
        public List<TaskModel> TestConnection()
        {
            using (IDbConnection cnn = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("TaskDB")))
            {
                var output = cnn.Query<TaskModel>("SELECT * FROM dbo.Task").ToList();

                return output;
            }
        }
    }
}
