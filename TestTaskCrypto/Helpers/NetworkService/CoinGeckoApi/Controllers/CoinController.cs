using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TestTaskCrypto.DataBase.Entity;

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
    }
}
