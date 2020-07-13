using AuditingMoney.Entity.Domain.BalanceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
    public interface IBalanceRepository
    {
        Task CreateComunication(Balance balance, KindOfCurrency kindOfCurrency);
        bool Exists(int id);
        bool ExistsByUserId(string id);

        Task<List<Balance>> GetListItems();
        Task<List<Balance>> GetListItems(string id);
        Task<Balance> GetItemByDateCreated(DateTime dateTime);

        Task<Balance> GetItem(int id);
        Task<Balance> GetItemByUserId(string id);

        Task Create(Balance entity);
        Task Remove(Balance entity);
        Task Update(Balance entity);

        IQueryable<Balance> GetEntityNoAsyncListItems();
    }
}
