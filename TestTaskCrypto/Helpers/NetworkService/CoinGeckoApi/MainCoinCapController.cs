using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi.Controllers;

namespace TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi
{
    public class MainCoinCapController
    {
        private readonly string _url = "https://rest.coincap.io/v3";
        private readonly string _token = "16746262e51c8c999e0a7d6670873dfd73a6fd97272f3d8b130679f416b3c747";

        public static CoinController Coin; 
        
        public MainCoinCapController()
        {
            Coin = new CoinController(_url,_token); 
        }


    }
}
