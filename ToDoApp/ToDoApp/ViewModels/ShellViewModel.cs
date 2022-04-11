using Caliburn.Micro;
using DataAccess;
using DataAccess.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ToDoApp.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {

        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();
        private NewTaskViewModel _newTaskViewModel = new NewTaskViewModel();

        /// <summary>
        /// Default constructor, open main widnow when start
        /// </summary>
        public ShellViewModel()
        {
            ActiveItem = _mainWindowViewModel;
        }

        /// <summary>
        /// Open new task form
        /// </summary>
        public void AddBtn()
        {
            ActiveItem = _newTaskViewModel;

            //Show Close button
            CloseBtnIsVisible = Visibility.Visible;
            //Hide Add button
            AddBtnIsVisible = Visibility.Hidden;
        }

        /// <summary>
        /// Close current window and retur to main window
        /// </summary>
        public void CloseBtn()
        {
            ActiveItem = _mainWindowViewModel;
            CloseBtnIsVisible = Visibility.Hidden;
            AddBtnIsVisible = Visibility.Visible;
        }

        //ButtonVisibility
        private Visibility _closeBtnIsVisible = Visibility.Hidden;
        private Visibility _addBtnIsVisible = Visibility.Visible;
        //ButtonEnability
        private bool _editBtnIsEnable = false;

        public Visibility CloseBtnIsVisible
        {
            get { return _closeBtnIsVisible; }
            set 
            { 
                _closeBtnIsVisible = value;
                NotifyOfPropertyChange(() => CloseBtnIsVisible);
            }
        }

        public Visibility AddBtnIsVisible
        {
            get { return _addBtnIsVisible; }
            set
            {
                _addBtnIsVisible = value;
                NotifyOfPropertyChange(() => AddBtnIsVisible);
            }
        }

        public bool EditBtnIsEnable
        {
            get { return _editBtnIsEnable; }
            set
            {
                _editBtnIsEnable = value;
                NotifyOfPropertyChange(() => EditBtnIsEnable);
            }
        }

    }
}
