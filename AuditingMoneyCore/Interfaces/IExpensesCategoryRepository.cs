using AuditingMoney.Entity.Domain.ExpensesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IExpensesCategoryRepository
    {
        bool Exists(int id);

        Task<List<ExpensesCategory>> GetListItems();
        Task<ExpensesCategory> GetItem(int id);
        Task<ExpensesCategory> GetItemByName(string name);

        Task Create(ExpensesCategory entity);
        Task Remove(ExpensesCategory entity);
        Task Update(ExpensesCategory entity);

    }
}
