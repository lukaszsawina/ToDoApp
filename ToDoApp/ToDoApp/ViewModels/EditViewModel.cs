using Caliburn.Micro;
using DataAccess;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoApp.EventsModel;

namespace ToDoApp.ViewModels
{
    public class EditViewModel : Screen
    {

        private IEventAggregator _events;
        private TaskModel _taskToChange = new TaskModel();

        AccessData DBaccess = new AccessData();

        public EditViewModel(IEventAggregator events, TaskModel task)
        {
            _taskToChange = task;
            _events = events;
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


        private string _result_info;
        public string Result_info
        {
            get { return _result_info; }
            set
            {
                _result_info = value;
                NotifyOfPropertyChange(() => Result_info);
            }
        }

        private bool _saveBtnIsEnable = true;

        public bool SaveBtnIsEnable
        {
            get { return _saveBtnIsEnable; }
            set
            {
                _saveBtnIsEnable = value;
                NotifyOfPropertyChange(() => SaveBtnIsEnable);
            }
        }

        //Info visibility
        private Visibility _resultIsVisible = Visibility.Hidden;

        public Visibility ResultIsVisible
        {
            get { return _resultIsVisible; }
            set
            {
                _resultIsVisible = value;
                NotifyOfPropertyChange(() => ResultIsVisible);
            }
        }

        private async Task ChangeVisibilityInfoAsync()
        {
            SaveBtnIsEnable = false;

            ResultIsVisible = Visibility.Visible;
            await Task.Delay(500);
            ResultIsVisible = Visibility.Hidden;

            SaveBtnIsEnable = true;
        }


        /// <summary>
        /// Event when add button is pressed
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task ChangeTaskAsync(object e)
        {
            if (!string.IsNullOrEmpty(EditTaskName))
            {
                _taskToChange.TaskName = EditTaskName;
                _taskToChange.ExpirationDate = ExpirationDate.ToString("dd.MM");

                try
                {
                    DBaccess.ChangeTaskData("spChangeTask", _taskToChange);

                    Result_info = "Saved";
                    await ChangeVisibilityInfoAsync();
                    _events.BeginPublishOnUIThread(new SuccessTaskChangedEvent());

                }
                catch (Exception)
                {
                    Result_info = "ERROR";
                    await ChangeVisibilityInfoAsync();
                }
            }
            else
            {
                Result_info = "Error! Type Task Name";
                await ChangeVisibilityInfoAsync();
            }


        }

    }
}
