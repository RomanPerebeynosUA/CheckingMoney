using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
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
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public BalanceRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<HttpResponseMessage> CreateBalance(string url, string accessToken, BalanceJsonModel content)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders
                   .Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync(url, content);       
            return response.EnsureSuccessStatusCode();
        }
        public List<BalanceJsonModel> DeseralizeBalances(string json)
        {
            var balances =  JsonConvert.DeserializeObject<List<BalanceJsonModel>>(json);
            return balances;
        }

        public BalanceJsonModel DeseralizeBalance(string json)
        {
            var balance = JsonConvert.DeserializeObject<BalanceJsonModel>(json);
            return balance;
        }

        public async Task<string> GetBalance(string url, string accessToken)
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
