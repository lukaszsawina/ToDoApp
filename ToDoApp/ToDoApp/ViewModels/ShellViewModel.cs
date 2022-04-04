using Caliburn.Micro;
using DataAccess;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ViewModels
{
    public class ShellViewModel : Screen
    {
        AccessData dbAccess = new AccessData();
        public ShellViewModel()
        {
            foreach(var t in dbAccess.TestConnection())
            {
                Tasks.Add(t);
            }
        }

        private BindableCollection<DataAccess.TaskModel> _tasks = new BindableCollection<DataAccess.TaskModel>();

        public BindableCollection<DataAccess.TaskModel> Tasks
        {
            get { return _tasks; }
            set 
            {
                _tasks = value;
                NotifyOfPropertyChange(() => Tasks);
            }
        }


    }
}
