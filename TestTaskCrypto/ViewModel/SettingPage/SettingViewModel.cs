using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TestTaskCrypto.Helpers.Command;
using TestTaskCrypto.View.SettingPage;

namespace TestTaskCrypto.ViewModel.SettingPage
{
    internal class SettingViewModel : ViewModel<SettingViewModel>
    {
        private ICommand _openGenarelSettingCommand;


        public SettingViewModel()
        {
            _openGenarelSettingCommand = new DelegateCommand(() => { Page = new SettingGeneralView(); });
        }

        public ICommand OpenGeneralSettingCommand => _openGenarelSettingCommand;

        private Page _pages;
        public Page Page
        {
            get { return _pages; }
            set { _pages = value; OnPropertyChanged(nameof(Page)); }
        }
    }
}
