using AuditingMoney.Entity.Domain.IncomeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IIncomeRepository
    {
        bool Exists(int id);
        Task<List<Income>> GetListItems();
        Task<Income> GetItem(int id);
        Task SaveEntity(Income entity);
        Task RemoveEntity(Income entity);
        Task UpdateEntity(Income entity);
        IQueryable<Income> GetEntityNoAsyncListItems();
    }
}
