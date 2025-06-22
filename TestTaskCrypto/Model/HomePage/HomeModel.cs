using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi;

namespace TestTaskCrypto.Model.HomePage
{
    internal class HomeModel
    {
        public HomeModel()
        {
            MainCoinCapController mainCoinGeckoController = new MainCoinCapController();
        }

        public void RediretcToWebSite()
        {
            Process.Start(new ProcessStartInfo("https://github.com/NazarKov/TestProjectCryptocurrencies") { UseShellExecute = true });
        }

    }
}
