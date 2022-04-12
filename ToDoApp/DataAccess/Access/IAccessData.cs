using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Access
{
    public interface IAccessData
    {
        List<TaskModel> LoadData(string viewName, string connectionID = "taskDB");
        bool SaveData(string storedProcedure, TaskModel parameter, string connectionID = "taskDB");

        void ChangeDataStatus(string storedProcedure, TaskModel task, string connectionID = "taskDB");
    }
}
