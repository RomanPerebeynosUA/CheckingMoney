using AuditingMoneyClient.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories
{
   public  class APIResponse : IAPIResponse
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

        public Task<string> SendContentToAPI(string url, string accessToken)
        {
            throw new NotImplementedException();
        }

        ////public Task<string> SendContentToAPI(string url, string accessToken, )
        ////{
        ////    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        ////    return result;
        ////}
    }
}
