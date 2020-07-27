using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Expenses
{
   public interface IExpensesRepository
    {
        Task<string> GetExpenses(string url, string accessToken);
        Task<HttpResponseMessage> CreateExpens(string url, string accessToken, ExpensesJsonModel content);
        List<ExpensesJsonModel> DeseralizeExpenses(string json);
        ExpensesJsonModel DeseralizeExpens(string json);
    }
}
