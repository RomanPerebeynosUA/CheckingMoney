using AuditingMoney.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
  public interface ICashAccountRepository
    {
        bool Exists(int id);
        bool ExistsByBalanceId(int id);

        Task<List<CashAccount>> GetListItems();
        Task<List<CashAccount>> GetListItems(int id);

        Task<CashAccount> GetItem(int id);
        Task<CashAccount> GetItemByBalanceId(int id);


        Task Create(CashAccount entity);
        Task Remove(CashAccount entity);
        Task Update(CashAccount entity);

    }
}
