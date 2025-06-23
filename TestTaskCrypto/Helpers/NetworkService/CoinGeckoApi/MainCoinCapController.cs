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
        private readonly string _token = "a7e605aaa3bee607c51809af13f58b272f8caac3c28d36c0231650707ff88ebf";

        public static CoinController Coin; 
        
        public MainCoinCapController()
        {
            Coin = new CoinController(_url,_token); 
        }


    }
}
