using AuditingMoneyClient.Core.Interfaces.Expenses;
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

namespace AuditingMoneyClient.Core.Repositories.Expenses
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public ExpensesRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateExpens(string url, 
            string accessToken, ExpensesJsonModel content)
        {
            var response = await _clientFactory.CreateClient(accessToken)
                .PostAsJsonAsync(url, content);
            return response.EnsureSuccessStatusCode();
        }

        public List<ExpensesJsonModel> DeseralizeExpenses(string json)
        {
            var expenses = JsonConvert.DeserializeObject<List<ExpensesJsonModel>>(json);
            return expenses;
        }

        public ExpensesJsonModel DeseralizeExpens(string json)
        {
            var expens = JsonConvert.DeserializeObject<ExpensesJsonModel>(json);
            return expens;
        }

        public async Task<string> GetExpenses(string url, string accessToken)
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
