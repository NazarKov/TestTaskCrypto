using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TestTaskCrypto.DataBase.Entity;
using TestTaskCrypto.DataBase.Enum;
using TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi;

namespace TestTaskCrypto.Model.DataPage
{
    public class CoinDataModel
    {
        private List<CoinHistory> _coinHistory;
        private List<CoinMarker> _coinMarker;

        public CoinDataModel()
        {
            _coinHistory = new List<CoinHistory>();
            _coinMarker = new List<CoinMarker>();
        }

        public List<CoinHistory> GetCoinHistory(string nameCoin, TypeInterval type)
        {
            try
            {
                Task t = Task.Run(async () =>
                {
                    var result = await MainCoinCapController.Coin.GetHistory(nameCoin,type);
                    if (result != null && result.data.Count > 0)
                    {
                        _coinHistory = result.data;
                    }
                });
                t.Wait();

                return _coinHistory; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<CoinHistory>();
            }

        }
        public List<CoinMarker> GetMarkets(string nameCoin)
        {
            try
            {
                Task t = Task.Run(async () =>
                {
                    var result = await MainCoinCapController.Coin.GetMarkets(nameCoin);
                    if (result != null && result.data.Count > 0)
                    {
                        _coinMarker = result.data;
                    }
                });
                t.Wait();

                return _coinMarker;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<CoinMarker>();
            }
        }
    }
}
