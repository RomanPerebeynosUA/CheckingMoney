using AuditingMoney.Entity.Domain.BalanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IKindOfCurrencyRepository
    {
        bool Exists(int id);
        Task<List<KindOfCurrency>> GetListItems();
        Task<KindOfCurrency> GetItemByName(string name);
        Task<KindOfCurrency> GetItem(int id);
        

        Task Create(KindOfCurrency entity);
        Task Remove(KindOfCurrency entity);
        Task Update(KindOfCurrency entity);
        
    }
}
