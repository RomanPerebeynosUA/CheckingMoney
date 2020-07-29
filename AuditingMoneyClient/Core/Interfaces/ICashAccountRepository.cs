using AuditingMoneyClient.Models.JsonModels;
using AuditingMoneyClient.Models.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface ICashAccountRepository
    {
        Task<string> GetCashAccount(string url, string accessToken);
        Task<List<CashAccountJsonModel>> GetNames(string url, string accessToken);

        Task<HttpResponseMessage> CreateCashAccount(string url, string accessToken, CashAccountJsonModel content);
        List<CashAccountJsonModel> DeseralizeCashAccounts(string json);
        CashAccountJsonModel DeseralizeCashAccount(string json);

        List<CashAccountHistory> DeseralizeCashAccountHistory(string json);
    }
}
