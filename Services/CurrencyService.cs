using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services
{

    interface ICurrencyService
    {
        Task<string> GetCurrency();
    }

    public class CurrencyService : ICurrencyService
    {
        

        private readonly RestClient _client;

        public CurrencyService()
        {
            _client = new RestClient("https://api.genelpara.com/");
        }

        public async Task<string> GetCurrency()
        {
            var request = new RestRequest("embed/doviz.json");
            var response = await _client.ExecuteGetAsync(request);
            if (!response.IsSuccessful)
            {
                //Logic for handling unsuccessful response
            }
            var data = response.Content;
            var objects = JsonConvert.DeserializeObject<dynamic>(data);
            dynamic veri = objects.USD["alis"];
            string currency = ((object)veri).ToString();
            return currency;
        }
    }
}
