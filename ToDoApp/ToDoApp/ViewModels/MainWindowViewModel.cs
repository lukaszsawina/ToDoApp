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
    public class MainWindowViewModel: Screen
    {
        AccessData accessData = new AccessData();

        public MainWindowViewModel()
        {
            var tasks = accessData.LoadData("FullTask");

            if (tasks.Count == 0)
            {
                Tasks.Add(new TaskModel { Id = 0, TaskName = "Brak danych" });
            }

            foreach (var t in tasks)
            {
                Tasks.Add(t);
            }

            tasks.Clear();
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
