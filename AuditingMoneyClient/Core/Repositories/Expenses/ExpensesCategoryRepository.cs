using AuditingMoneyClient.Core.Interfaces.Expenses;
using AuditingMoneyClient.Core.Interfaces.Common;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories.Expenses
{
    public class ExpensesCategoryRepository : IExpensesCategoryRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public ExpensesCategoryRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateExpCategory(string url, string accessToken, 
            ExpensesCategoryJsonModel content)
        {
            var response = await _clientFactory.CreateClient(accessToken)
               .PostAsJsonAsync(url, content);
            return response.EnsureSuccessStatusCode();
        }

        public List<ExpensesCategoryJsonModel> DeseralizeExpCategories(string json)
        {
            var expCategory = JsonConvert.DeserializeObject<List<ExpensesCategoryJsonModel>>(json);
            return expCategory;
        }

        public ExpensesCategoryJsonModel DeseralizeExpCategory(string json)
        {
            var expCategory = JsonConvert.DeserializeObject<ExpensesCategoryJsonModel>(json);
            return expCategory;
        }

        public async Task<string> GetExpCategory(string url, string accessToken)
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
