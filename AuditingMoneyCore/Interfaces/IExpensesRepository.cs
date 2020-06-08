using AuditingMoney.Entity.Domain.ExpensesEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IExpensesRepository
    {
        bool Exists(int id);
        Task<List<Expenses>> GetListItems();
        Task<Expenses> GetItem(int id);
        Task SaveEntity(Expenses entity);
        Task RemoveEntity(Expenses entity);
        Task UpdateEntity(Expenses entity);
        IQueryable<Expenses> GetEntityNoAsyncListItems();
    }

}
