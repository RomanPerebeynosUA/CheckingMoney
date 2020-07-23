using AuditingMoney.Entity.Domain.TransferEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces.Transfers
{
    public interface ITransferFromRepository
    {
        bool Exists(int id);
        bool ExistsByCashAccountId(int id);
        bool ExistsByTransferId(int id);

        Task<List<TransferFrom>> GetListItems();
        Task<List<TransferFrom>> GetListByCashAccountId(int id);
        Task<List<TransferFrom>> GetListByTransferId(int id);

        Task<TransferFrom> GetItem(int id);
        Task<TransferFrom> GetItemByCashAccountId(int id);
        Task<TransferFrom> GetItemByTransferId(int id);

        Task Create(TransferFrom entity);
        Task Remove(TransferFrom entity);
        Task Update(TransferFrom entity);
    }
}
