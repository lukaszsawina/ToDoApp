using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.EventsModel
{
    public class ChangeSelectionEvent
    {
        public ChangeSelectionEvent(TaskModel task)
        {
            SelectedTask = task;
        }
        public TaskModel SelectedTask { get; set; }
    }
}
