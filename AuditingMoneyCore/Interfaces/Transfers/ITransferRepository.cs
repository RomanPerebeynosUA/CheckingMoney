using AuditingMoney.Entity.Domain.TransferEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces.Transfers
{
    public interface ITransferRepository
    {
        bool Exists(int id);
        bool ExistsRemittanceTo(int id);
        bool ExistsRemittanceFrom(int id);

        Task<List<Transfer>> GetListItems();
        Task<List<Transfer>> GetListItemsRemittanceTo(int id);
        Task<List<Transfer>> GetListItemsRemittanceFrom(int id);

        Task<Transfer> GetItem(int id);
        Task<Transfer> GetItemByDate(DateTime dateTime);

        Task CreateComunication(Transfer transfer, 
            int CashAccountFrom, int CashAccountTo);
        Task Create(Transfer entity);
        Task Remove(Transfer entity);
        Task Update(Transfer entity);
    }
}
