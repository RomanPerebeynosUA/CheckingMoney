using AuditingMoney.Entity.Domain.TransferEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces.Transfers
{
    public interface ITransferToRepository
    {
        bool Exists(int id);
        bool ExistsByCashAccountId(int id);
        bool ExistsByTransferId(int id);

        Task<List<TransferTo>> GetListItems();
        Task<List<TransferTo>> GetListByCashAccountId(int id);
        Task<List<TransferTo>> GetListByTransferId(int id);


        Task<TransferTo> GetItem(int id);
        Task<TransferTo> GetItemByCashAccountId(int id);
        Task<TransferTo> GetItemByTransferId(int id);


        Task Create(TransferTo entity);
        Task Remove(TransferTo entity);
        Task Update(TransferTo entity);
    }
}
