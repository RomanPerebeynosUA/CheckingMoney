using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories
{
    public class KindOfCurrencyRepository : IKindOfCurrencyRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public KindOfCurrencyRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateKindOfCurrency(string url, string accessToken, KindOfCurrencyJsonModel content)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders
                   .Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsJsonAsync(url, content);
            return response.EnsureSuccessStatusCode();
        }

        public List<KindOfCurrencyJsonModel> DeseralizeKindOfCurrencies(string json)
        {
            var kindOfCurrencies = JsonConvert.DeserializeObject<List<KindOfCurrencyJsonModel>>(json);
            return kindOfCurrencies;
        }

        public KindOfCurrencyJsonModel DeseralizeKindOfCurrency(string json)
        {
            var kindOfCurrency = JsonConvert.DeserializeObject<KindOfCurrencyJsonModel>(json);
            return kindOfCurrency;
        }

        public async Task<string> GetKindOfCurrency(string url, string accessToken)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
