using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTaskCrypto.DataBase.Entity;
using TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi;

namespace TestTaskCrypto.Model.DataPage
{
    public class CoinsDataModel
    {
        private List<Coin> _coins;

        public CoinsDataModel()
        {
            _coins = new List<Coin>();
        }

        public List<Coin> GetCoin(int count = 10)
        {
            try
            {
                Task t = Task.Run(async () =>
                {
                    var result = await MainCoinCapController.Coin.Get();
                    if (result != null && result.data.Count > 0)
                    {
                        _coins = result.data;
                    }
                });
                t.Wait();
                return _coins.Take(count).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Coin>();
            }
        }



        public List<Coin> Search(string item,int count = 10)
        {
            try
            {
                List<Coin> resultSearh = new List<Coin>();
                foreach (Coin coin in _coins)
                {
                    if (coin.name.ToLower().Contains(item.ToLower()))
                        resultSearh.Add(coin);
                }
                if (resultSearh.Count == 0)
                {
                    foreach (Coin coin in _coins)
                    {
                        if (coin.symbol.ToLower().Contains(item.ToLower()))
                            resultSearh.Add(coin);
                    }
                }

                return resultSearh.Take(count).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Coin>();
            }
        }

    }
}
