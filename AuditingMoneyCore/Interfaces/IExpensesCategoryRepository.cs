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
        Task SaveEntity(ExpensesCategory entity);
        Task RemoveEntity(ExpensesCategory entity);
        Task UpdateEntity(ExpensesCategory entity);
        IQueryable<ExpensesCategory> GetEntityNoAsyncListItems();
    }
}
