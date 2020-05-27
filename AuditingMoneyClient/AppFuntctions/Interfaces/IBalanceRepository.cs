using AuditingMoneyClient.Models.Entity.BalanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.AppFuntctions.Interfaces
{
    public interface IBalanceRepository
    {
        bool Exists(int id);
        Task<List<Balance>> GetListItems();
        Task<Balance> GetItem(int id);
        Task SaveEntity(Balance entity);
        Task RemoveEntity(Balance entity);
        Task UpdateEntity(Balance entity);
        IQueryable<Balance> GetEntityNoAsyncListItems();
    }
}
