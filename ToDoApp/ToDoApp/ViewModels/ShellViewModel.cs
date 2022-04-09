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


        private MainWindowViewModel _mainWindowViewModel = new MainWindowViewModel();

        public ShellViewModel()
        {
            ActiveItem = _mainWindowViewModel;
        }
    }
}
