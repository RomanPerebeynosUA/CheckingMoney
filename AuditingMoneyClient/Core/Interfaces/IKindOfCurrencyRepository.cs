using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface IKindOfCurrencyRepository
    {
        Task<string> GetKindOfCurrency(string url, string accessToken);
        Task<HttpResponseMessage> CreateKindOfCurrency(string url, string accessToken, KindOfCurrencyJsonModel content);
        List<KindOfCurrencyJsonModel> DeseralizeKindOfCurrencies(string json);
        KindOfCurrencyJsonModel DeseralizeKindOfCurrency(string json);
    }
}
