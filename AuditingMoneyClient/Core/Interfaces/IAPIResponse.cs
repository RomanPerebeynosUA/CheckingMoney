using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface IAPIResponse<T>
    {
        Task<string> ConnectToAPI(string url, string accessToken);

        Task<HttpResponseMessage> SendContentToAPI(string url, string accessToken, StringContent content);

        Task<HttpResponseMessage> SendObjToAPI(string url, string accessToken, T content);
    }
}
