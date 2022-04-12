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
    public class NewTaskViewModel : Screen
    {

        private string _newTaskName;
        private DateTime _expirationDate;
        private IEventAggregator _events;

        //DatabaseAccess
        AccessData DBaccess = new AccessData();

        public NewTaskViewModel(IEventAggregator events)
        {
            _events = events;
        }

        public DateTime ExpirationDate
        {
            get { return _expirationDate; }
            set 
            { 
                _expirationDate = value; 
                NotifyOfPropertyChange(() => _expirationDate);  
            }
        }

        public string NewTaskName
        {
            get { return _newTaskName; }
            set 
            { 
                _newTaskName = value; 
                NotifyOfPropertyChange(() => NewTaskName);
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

        private bool _addBtnIsEnable = true;

        public bool AddBtnIsEnable
        {
            get { return _addBtnIsEnable; }
            set 
            { 
                _addBtnIsEnable = value;
                NotifyOfPropertyChange(() => AddBtnIsEnable);
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
            AddBtnIsEnable = false;

            ResultIsVisible = Visibility.Visible;
            await Task.Delay(1500);
            ResultIsVisible = Visibility.Hidden;

            AddBtnIsEnable = true;
        }

        private void ClearInputs()
        {
            NewTaskName = "";
        }

        /// <summary>
        /// Event when add button is pressed
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public async Task AddNewTaskAsync(object e)
        {
            if(!string.IsNullOrEmpty(NewTaskName))
            {
                TaskModel newTask = new TaskModel();
                newTask.TaskName = NewTaskName;
                newTask.ExpirationDate = ExpirationDate.ToString("dd.MM");
                newTask.SetDate = DateTime.Now.ToString("dd.MM");
                newTask.Status = "Undone";

                try
                {
                    DBaccess.SaveData("spAddNewTask", newTask);
                    _events.BeginPublishOnUIThread(new SuccessAddTaskEvent());

                    Result_info = "Task add successfull";
                    ClearInputs();
                    await ChangeVisibilityInfoAsync();
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
