using AuditingMoneyClient.Core.Interfaces.Incomes;
using AuditingMoneyClient.Core.Interfaces.Common;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories.Incomes
{
    public class IncomeRepository : IIncomeRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public IncomeRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateIncome(string url, string accessToken, 
            IncomeJsonModel content)
        {

            var response = await _clientFactory.CreateClient(accessToken)
                .PostAsJsonAsync(url, content);
            return response.EnsureSuccessStatusCode();
        }

        public IncomeJsonModel DeseralizeIncome(string json)
        {
            var income = JsonConvert.DeserializeObject<IncomeJsonModel>(json);
            return income;
        }

        public List<IncomeJsonModel> DeseralizeIncomes(string json)
        {
            var incomes = JsonConvert.DeserializeObject<List<IncomeJsonModel>>(json);
            return incomes;
        }

        public async Task<string> GetIncome(string url, string accessToken)
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
