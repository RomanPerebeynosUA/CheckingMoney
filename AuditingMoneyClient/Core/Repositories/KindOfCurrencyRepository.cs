﻿using AuditingMoneyClient.Core.Interfaces;
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

namespace AuditingMoneyClient.Core.Repositories
{
    public class KindOfCurrencyRepository : IKindOfCurrencyRepository
    {
        private readonly IHttpClientFactoryRepository _clientFactory;
        public KindOfCurrencyRepository(IHttpClientFactoryRepository clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> CreateKindOfCurrency(string url, string accessToken, 
            KindOfCurrencyJsonModel content)
        {
            var response = await _clientFactory.CreateClient(accessToken)
                .PostAsJsonAsync(url, content);
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
            var response = await _clientFactory.CreateClient(accessToken).GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return response.StatusCode.ToString();
            }
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
