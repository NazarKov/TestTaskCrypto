using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Model.HomePage;

namespace TestTaskCrypto.ViewModel.HomePage
{
    internal class HomeViewModel : ViewModel<HomeViewModel>
    {
        private HomeModel _model;

        public HomeViewModel()
        { 
            _model = new HomeModel();
        }

    }
}
