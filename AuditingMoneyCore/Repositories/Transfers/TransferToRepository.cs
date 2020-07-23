using AuditingMoney.Entity.Domain.TransferEntity;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces.Transfers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories.Transfers
{
    public class TransferToRepository : ITransferToRepository
    {
        private readonly AuditingDbContext _context;
        public TransferToRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.TransfersTo.Any(e => e.Id == id);
        }
        public bool ExistsByTransferId(int id)
        {
            return _context.TransfersTo.Any(e => e.Transfer.Id == id);
        }
        public bool ExistsByCashAccountId(int id)
        {
            return _context.TransfersTo.Any(e => e.CashAccount.Id == id);
        }

        public async Task<TransferTo> GetItem(int id)
        {
            return await _context.TransfersTo.
                FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<TransferTo> GetItemByCashAccountId(int id)
        {
            return await _context.TransfersTo.
               FirstOrDefaultAsync(e => e.CashAccount.Id == id);
        }
        public async Task<TransferTo> GetItemByTransferId(int id)
        {
            return await _context.TransfersTo.
                FirstOrDefaultAsync(e => e.Transfer.Id == id);
        }

        public async Task<List<TransferTo>> GetListItems()
        {
            return await _context.TransfersTo.ToListAsync();
               
        }
        public async Task<List<TransferTo>> GetListByCashAccountId(int id)
        {
            return await _context.TransfersTo.
                Where(e => e.CashAccount.Id == id).ToListAsync();
        }

        public async Task<List<TransferTo>> GetListByTransferId(int id)
        {
            return await _context.TransfersTo.
                Where(e => e.Transfer.Id == id).ToListAsync();
        }

        public async Task Create(TransferTo entity)
        {
            _context.TransfersTo.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TransferTo entity)
        {
            _context.TransfersTo.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TransferTo entity)
        {
            _context.TransfersTo.Update(entity);
            await _context.SaveChangesAsync();
        }  
    }
}
