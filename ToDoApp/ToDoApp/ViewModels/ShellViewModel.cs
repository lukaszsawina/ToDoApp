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
    public class ShellViewModel : Conductor<object>
    {
        AccessData accessData = new AccessData();

        //private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();

        public ShellViewModel()
        {
            //ActiveItem = _mainWindowViewModel;

            List<TaskModel> tasks = accessData.LoadData("DoneTask");  

            if(tasks.Count == 0)
            {
                Tasks.Add(new TaskModel { Id=0, TaskName="Brak danych"});
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
