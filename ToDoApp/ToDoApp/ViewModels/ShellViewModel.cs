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
using ToDoApp.EventsModel;

namespace ToDoApp.ViewModels
{
    public class ShellViewModel : Conductor<object>, IHandle<ChangeSelectionEvent>, IHandle<SuccessTaskChangedEvent>
    {
        private IEventAggregator _events;
        private MainWindowViewModel _mainWindowViewModel;
        private NewTaskViewModel _newTaskViewModel;

        /// <summary>
        /// Default constructor, open main widnow when start
        /// </summary>
        public ShellViewModel(IEventAggregator events)
        {
            _events = events;
            events.Subscribe(this);
            _mainWindowViewModel = new MainWindowViewModel(_events);
            _newTaskViewModel = new NewTaskViewModel(_events);
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

            EditBtnIsEnable = false;
        }

        /// <summary>
        /// Close current window and retur to main window
        /// </summary>
        public void CloseBtn()
        {
            ActiveItem = _mainWindowViewModel;
            CloseBtnIsVisible = Visibility.Hidden;
            AddBtnIsVisible = Visibility.Visible;

            EditBtnIsEnable = false;

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

        /// <summary>
        /// Change enability of Edit button
        /// </summary>
        public bool EditBtnIsEnable
        {
            get { return _editBtnIsEnable; }
            set
            {
                _editBtnIsEnable = value;
                NotifyOfPropertyChange(() => EditBtnIsEnable);
            }
        }

        private TaskModel _selectedTask = new TaskModel();

        /// <summary>
        /// Event when selected was changed
        /// </summary>
        /// <param name="message">type of event</param>
        public void Handle(ChangeSelectionEvent message)
        {
            EditBtnIsEnable = true;
            _selectedTask = message.SelectedTask;
        }

        public void EditBtn()
        {
            ActiveItem = new EditViewModel(_events, _selectedTask);

            //Show Close button
            CloseBtnIsVisible = Visibility.Visible;
            //Hide Add button
            AddBtnIsVisible = Visibility.Hidden;
        }

        public void Handle(SuccessTaskChangedEvent message)
        {
            CloseBtn();
        }
    }
}
