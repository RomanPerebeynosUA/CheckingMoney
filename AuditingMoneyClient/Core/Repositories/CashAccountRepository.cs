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
    public class CashAccountRepository : ICashAccountRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public CashAccountRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<HttpResponseMessage> CreateCashAccount(string url, string accessToken, 
            CashAccountJsonModel content)
        {
           var response = await _clientFactory.CreateClient(accessToken).
                PostAsJsonAsync(url, content);
           
           return response.EnsureSuccessStatusCode();
        }

        public CashAccountJsonModel DeseralizeCashAccount(string json)
        {
            var cashAccount = JsonConvert.DeserializeObject<CashAccountJsonModel>(json);
            return cashAccount;
        }

        public List<CashAccountJsonModel> DeseralizeCashAccounts(string json)
        {
            var cashAccounts = JsonConvert.DeserializeObject<List<CashAccountJsonModel>>(json);
        
            return cashAccounts;
        }

        public async Task<string> GetCashAccount(string url, string accessToken)
        {     
            var response = await _clientFactory.CreateClient(accessToken).GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
