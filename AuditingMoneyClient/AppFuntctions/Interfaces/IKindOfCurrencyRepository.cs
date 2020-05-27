using AuditingMoneyClient.Models.Entity.BalanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.AppFuntctions.Interfaces
{
   public interface IKindOfCurrencyRepository
    {
        bool Exists(int id);
        Task<List<KindOfCurrency>> GetListItems();
        Task<KindOfCurrency> GetItem(int id);
        Task SaveEntity(KindOfCurrency entity);
        Task RemoveEntity(KindOfCurrency entity);
        Task UpdateEntity(KindOfCurrency entity);
        IQueryable<KindOfCurrency> GetEntityNoAsyncListItems();
    }
}
