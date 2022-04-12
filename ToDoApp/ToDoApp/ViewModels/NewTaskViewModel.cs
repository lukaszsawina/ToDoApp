using Caliburn.Micro;
using DataAccess;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp.ViewModels
{
    public class NewTaskViewModel : Screen
    {
        private string _newTaskName;
        private DateTime _expirationDate;


        AccessData DBaccess = new AccessData();

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

        private string _resutl_info;

        public string Resutl_info
        {
            get { return _resutl_info; }
            set 
            { 
                _resutl_info = value;
                NotifyOfPropertyChange(() => Resutl_info);
            }
        }


        public async Task AddNewTask(object e)
        {
            TaskModel newTask = new TaskModel();
            newTask.TaskName = NewTaskName;
            newTask.ExpirationDate = ExpirationDate.ToString("dd.MM");
            newTask.SetDate = DateTime.Now.ToString("dd.MM");
            newTask.Status = "Undone";

            try
            {
                DBaccess.SaveData("spAddNewTask", newTask);

                ResultIsVisible = Visibility.Visible;
                await Task.Delay(1500);
                ResultIsVisible = Visibility.Hidden;

            }
            catch (Exception)
            {
                Resutl_info = "ERROR";
            }


        }
    }
}
