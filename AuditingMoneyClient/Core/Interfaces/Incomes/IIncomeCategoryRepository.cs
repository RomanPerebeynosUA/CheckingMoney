using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Incomes
{
    public interface IIncomeCategoryRepository
    {
        Task<string> GetIncCategory(string url, string accessToken);
        Task<HttpResponseMessage> CreateIncCategory(string url, string accessToken, IncomeCategoryJsonModel content);
        List<IncomeCategoryJsonModel> DeseralizeIncCategories(string json);
        IncomeCategoryJsonModel DeseralizeIncCategory(string json);
    }
}
