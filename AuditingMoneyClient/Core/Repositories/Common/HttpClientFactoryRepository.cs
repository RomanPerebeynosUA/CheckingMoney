using AuditingMoneyClient.Core.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories.Common
{
    public class HttpClientFactoryRepository : IHttpClientFactoryRepository
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientFactoryRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public HttpClient CreateClient(string accessToken)
        {
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders
                   .Accept
                   .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
    }
}
