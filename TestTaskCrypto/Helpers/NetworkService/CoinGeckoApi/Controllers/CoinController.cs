using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestTaskCrypto.DataBase.Entity;
using TestTaskCrypto.DataBase.Enum;

namespace TestTaskCrypto.Helpers.NetworkService.CoinGeckoApi.Controllers
{
    public class CoinController
    {
        private string _url;
        private string _token;

        public CoinController(string url, string token)
        {
            _url = url;
            _token = token;
        }

        public async Task<CointRoot> Get()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_url + "/assets"),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization","Bearer "+ _token },
                    },
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();



                if (body != null)
                {
                    return JsonSerializer.Deserialize<CointRoot>(body);
                }
                return new CointRoot();
            }
        }

        public async Task<CoinHistoryRoot> GetHistory(string nameCoin, TypeInterval interval)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization","Bearer "+ _token },
                    },
                };
                nameCoin = nameCoin.ToLower();


                switch (interval)
                {
                    case TypeInterval.OneDay:
                        {
                            request.RequestUri = new Uri(_url + "/assets/" + nameCoin + "/history?interval=m1");
                            break;
                        }
                    case TypeInterval.SevenDays:
                        {

                            request.RequestUri = new Uri(_url + "/assets/" + nameCoin + "/history?interval=m15");
                            break;
                        }
                    case TypeInterval.OneMounth:
                        {

                            request.RequestUri = new Uri(_url + "/assets/" + nameCoin + "/history?interval=m30");
                            break;
                        }
                    case TypeInterval.ThreeMounth:
                        {

                            request.RequestUri = new Uri(_url + "/assets/" + nameCoin + "/history?interval=h6");
                            break;
                        }
                    case TypeInterval.OneYear:
                        { 
                            request.RequestUri = new Uri(_url + "/assets/" + nameCoin + "/history?interval=d1");
                            break;
                        }
                }


                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();



                if (body != null)
                {
                    var reslut = JsonSerializer.Deserialize<CoinHistoryRoot>(body);
                    return reslut;
                }
                return new CoinHistoryRoot();
            }
        }

        public async Task<CoinMarkerRoot> GetMarkets(string nameCoin)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_url + "/assets/"+ nameCoin.ToLower() +"/markets"),
                    Headers =
                    {
                        { "accept", "application/json" },
                        { "Authorization","Bearer "+ _token },
                    },
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var body = await response.Content.ReadAsStringAsync();



                if (body != null)
                {
                    var result = JsonSerializer.Deserialize<CoinMarkerRoot>(body);
                    return result;
                }
                return new CoinMarkerRoot();
            }
        }
    }
}
