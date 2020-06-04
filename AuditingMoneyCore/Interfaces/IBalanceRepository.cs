using AuditingMoney.Entity.Domain.BalanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
    public interface IBalanceRepository
    {
        bool Exists(string id);
        Task<List<Balance>> GetListItems();
        Task<Balance> GetItem(int id);
        Task SaveEntity(Balance entity);
        Task RemoveEntity(Balance entity);
        Task UpdateEntity(Balance entity);
        IQueryable<Balance> GetEntityNoAsyncListItems();
    }
}
