using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Common
{
   public interface IHttpClientFactoryRepository
    {
        HttpClient CreateClient(string accessToken);
    }
}
