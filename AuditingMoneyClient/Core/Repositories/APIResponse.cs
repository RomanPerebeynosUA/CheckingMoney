using AuditingMoneyClient.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuditingMoneyClient.Models.JsonModels;

namespace AuditingMoneyClient.Core.Repositories
{
   public  class APIResponse : IAPIResponse<CashAccountJsonModel>
    {
        private readonly HttpClient _client;
        public APIResponse(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> ConnectToAPI(string url, string accessToken)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                // throw new Exception((int)response.StatusCode + "-" + response.StatusCode.ToString());
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return  result;
        }

        public async Task<HttpResponseMessage> SendContentToAPI(string url, string accessToken, StringContent content)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //var response = await  _client.PostAsJsonAsync(url, content);
           var response = await _client.PostAsync(url, content);


            return response.EnsureSuccessStatusCode();
        }
        public async Task<HttpResponseMessage> SendObjToAPI(string url, string accessToken, CashAccountJsonModel content)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            _client.DefaultRequestHeaders
                   .Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await _client.PostAsJsonAsync<object>(url, content);
            //  var response = await _client.PostAsync(url, content);


            return response.EnsureSuccessStatusCode();
        }
    }
}
