using Caliburn.Micro;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ViewModels
{
    public class EditViewModel : Screen
    {
        public EditViewModel(TaskModel task)
        {
            EditTaskName = task.TaskName;
            ExpirationDate = DateTime.Parse(task.ExpirationDate);
        }


        private string _editTaskName;

        public string EditTaskName
        {
            get { return _editTaskName; }
            set 
            {
                _editTaskName = value; 
                NotifyOfPropertyChange(() => EditTaskName);
            }
        }

        private DateTime _expirationDate;

        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set 
            { 
                _expirationDate = value; 
                NotifyOfPropertyChange(() => ExpirationDate);
            }
        }



    }
}
