using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Incomes
{
   public interface IIncomeRepository
    {
        Task<string> GetIncome(string url, string accessToken);
        Task<HttpResponseMessage> CreateIncome(string url, string accessToken, IncomeJsonModel content);
        List<IncomeJsonModel> DeseralizeIncomes(string json);
        IncomeJsonModel DeseralizeIncome(string json);
    }
}
