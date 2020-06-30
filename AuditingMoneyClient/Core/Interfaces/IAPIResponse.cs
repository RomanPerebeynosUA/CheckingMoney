using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface IAPIResponse
    {
        Task<string> ConnectToAPI(string url, string accessToken);

        Task<string> SendContentToAPI(string url, string accessToken);
    }
}
