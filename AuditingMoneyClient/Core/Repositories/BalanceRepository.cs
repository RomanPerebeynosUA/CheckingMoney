using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Core.Interfaces.Common;
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
        private readonly IHttpClientFactoryRepository _clientFactory;
        public BalanceRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateBalance(string url, string accessToken, BalanceJsonModel content)
        {         
            var response = await _clientFactory.CreateClient(accessToken).
                PostAsJsonAsync(url, content);       
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
            var response = await _clientFactory.
                CreateClient(accessToken).GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
    
}
