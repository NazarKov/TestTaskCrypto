using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestTaskCrypto.DataBase.Entity;
using TestTaskCrypto.Helpers;
using TestTaskCrypto.Helpers.Command;
using TestTaskCrypto.Model.DataPage;

namespace TestTaskCrypto.ViewModel.DataPage
{
    internal class CoinsDataViewModel : ViewModel<CoinsDataViewModel>
    {
        private CoinsDataModel _model;
         
        private ICommand _updateCountShowDataGrid;

        public CoinsDataViewModel() 
        {
            _model = new CoinsDataModel();
            _coins = new List<Coin>();

            _coutShowDataGrid = new List<string>();
            _selectedItemComboCox = string.Empty;
            _searchItem = string.Empty;
             
            _updateCountShowDataGrid = new DelegateCommand(UpdateCount);

            Coins = _model.GetCoin();

            setDataComboBox();
        }

        private void setDataComboBox()
        {
            CountShowDataGrid.Add("10");
            CountShowDataGrid.Add("15");
            CountShowDataGrid.Add("20");
            CountShowDataGrid.Add("30");
            CountShowDataGrid.Add("50");
            CountShowDataGrid.Add("100"); 
        }


        private List<Coin> _coins;
        public List<Coin> Coins
        {
            get { return _coins; }
            set { _coins = value; OnPropertyChanged(nameof(Coins)); }
        }

        private List<string> _coutShowDataGrid;
        public List<string> CountShowDataGrid
        {
            get { return _coutShowDataGrid; }
            set { _coutShowDataGrid = value; OnPropertyChanged(nameof(CountShowDataGrid)); }
        }

        private string _selectedItemComboCox;
        public string SelectedItemComboCox
        {
            get { return _selectedItemComboCox; }
            set { _selectedItemComboCox = value; OnPropertyChanged(nameof(SelectedItemComboCox)); }
        }

        private string _searchItem;
        public string SearchItem
        {
            get { return _searchItem; }
            set { _searchItem = value; OnPropertyChanged(nameof(SearchItem)); }
        }

        public ICommand UpdateCountShowDataGrid => _updateCountShowDataGrid;
        private void UpdateCount()
        {
            Coins = _model.GetCoin(Convert.ToInt32(SelectedItemComboCox));
        }

        public ICommand RedirectWebCiteCommand { get => new DelegateParameterCommand(RedirectWebCite, CanRegister); }
        private void RedirectWebCite(object parameter)
        {
            Process.Start(new ProcessStartInfo(((Coin)parameter).explorer) { UseShellExecute = true });
        }

        public ICommand OpenCoinInformanionComman { get => new DelegateParameterCommand(OpenCoinInformanion, CanRegister); }
        private void OpenCoinInformanion(object parameter)
        {
            Session.Coin = ((Coin)parameter);
            Session.CoinList = Coins;
            Navigation.Notify("OpenCoinsDataNavigationButton");
        }

        private bool CanRegister(object parameter) => true;


        public ICommand SearchCommand { get => new DelegateParameterCommand(Search, CanRegister); }
        public void Search(object parameter)
        {
            if (SelectedItemComboCox == string.Empty)
            { 
                Coins = _model.Search(parameter.ToString());
            }
            else
            { 
                Coins = _model.Search(parameter.ToString(), Convert.ToInt32(SelectedItemComboCox));
            } 
        }

    }
}
