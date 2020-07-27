using AuditingMoneyClient.Core.Interfaces.Incomes;
using AuditingMoneyClient.Core.Interfaces.Common;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories.Incomes
{
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public IncomeCategoryRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateIncCategory(string url, string accessToken, 
            IncomeCategoryJsonModel content)
        {
            var response = await _clientFactory.CreateClient(accessToken)
            .PostAsJsonAsync(url, content);
            return response.EnsureSuccessStatusCode();
        }

        public List<IncomeCategoryJsonModel> DeseralizeIncCategories(string json)
        {
            var incCategory = JsonConvert.DeserializeObject<List<IncomeCategoryJsonModel>>(json);
            return incCategory;
        }

        public IncomeCategoryJsonModel DeseralizeIncCategory(string json)
        {
            var incCategory = JsonConvert.DeserializeObject<IncomeCategoryJsonModel>(json);
            return incCategory;
        }

        public async Task<string> GetIncCategory(string url, string accessToken)
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
