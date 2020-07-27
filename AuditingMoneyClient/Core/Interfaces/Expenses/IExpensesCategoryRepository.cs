using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces.Expenses
{
    public interface IExpensesCategoryRepository
    {
        Task<string> GetExpCategory(string url, string accessToken);
        Task<HttpResponseMessage> CreateExpCategory(string url, string accessToken, 
            ExpensesCategoryJsonModel content);
        List<ExpensesCategoryJsonModel> DeseralizeExpCategories(string json);
        ExpensesCategoryJsonModel DeseralizeExpCategory(string json);
    }
}
