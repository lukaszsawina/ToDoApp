using Caliburn.Micro;
using DataAccess;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.EventsModel;

namespace ToDoApp.ViewModels
{
    public class MainWindowViewModel: Screen, IHandle<SuccessAddTaskEvent>
    {


        AccessData accessData = new AccessData();
        private IEventAggregator _events;

        public MainWindowViewModel(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);

            RefreshData();
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
        public void ChangeSelect(System.Windows.Controls.SelectionChangedEventArgs e)
        {
            _events.BeginPublishOnUIThread(new ChangeSelectionEvent());
        }

        private void RefreshData()
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

        public void Handle(SuccessAddTaskEvent message)
        {
            RefreshData();
        }

        public async Task DoneTask(TaskModel e)
        {
            await Task.Delay(500);

            DeleteTask(e);
        }

        private void DeleteTask(TaskModel e)
        {
            accessData.ChangeDataStatus("spChangeTaskStatus", e);
            Tasks.Remove(e);
            Tasks.Refresh();
        }
    }
}
