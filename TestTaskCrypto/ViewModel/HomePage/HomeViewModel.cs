using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestTaskCrypto.Helpers;
using TestTaskCrypto.Helpers.Command;
using TestTaskCrypto.Model.HomePage; 
using TestTaskCrypto.View.DataPage;
using TestTaskCrypto.View.HomePage;
using TestTaskCrypto.View.SettingPage;

namespace TestTaskCrypto.ViewModel.HomePage
{
    internal class HomeViewModel : ViewModel<HomeViewModel>
    {
        private HomeModel _model;

        private ICommand _openSettingCommand;  
        private ICommand _openWebSiteAppCommand;

        public HomeViewModel()
        { 
            _model = new HomeModel();
            _page = new Page();

            _openSettingCommand = new DelegateCommand(OpenSetting);  
            _openWebSiteAppCommand = new DelegateCommand(OpenWebSiteApp);


            Page = new CoinsDataView();
             
             Navigation.Subscribe(nameof(OpenCoinsDataNavigationButton), OpenCoinsDataNavigationButton);
        }


        private Page _page;
        public Page Page
        {
            get { return _page; }
            set { _page = value; OnPropertyChanged(nameof(Page)); }
        }

        public ICommand OpenSettingCommand => _openSettingCommand;
        private void OpenSetting()
        {
            new SettingView().Show();
        }

        public ICommand ExitAppCommand { get => new DelegateParameterCommand(WindowClose, CanRegister); }
        private void WindowClose(object parameter)
        {
            Window? window = parameter as Window;
            window?.Close();
        }  
        private bool CanRegister(object parameter) => true; 
 
        private void OpenCoinsDataNavigationButton(object parameter)
        {
            Page = new CoinsDataView(); 
        }

        public ICommand OpenWebSiteAppCommand => _openWebSiteAppCommand;
        private void OpenWebSiteApp()
        {
            _model.RediretcToWebSite();
        }

    }
}
