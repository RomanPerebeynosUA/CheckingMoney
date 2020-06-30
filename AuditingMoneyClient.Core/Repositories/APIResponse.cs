using AuditingMoneyClient.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories
{
    class APIResponse : IAPIResponse
    {
        private readonly HttpClient _client;
        public APIResponse(HttpClient client)
        {
            _client = client;
        }
        public async Task ConnectToAPI(string url)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
           
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetAsync("https://localhost:44382/Balance/Get");
          
        }
    }
}
