using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
   public interface IBalanceRepository
    {
        Task<string> GetBalance (string url, string accessToken);
        Task<HttpResponseMessage> CreateBalance(string url, string accessToken, BalanceJsonModel content);
        List<BalanceJsonModel> DeseralizeBalances(string json);
        BalanceJsonModel DeseralizeBalance(string json);

    }
}
