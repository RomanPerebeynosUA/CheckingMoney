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
    public class TransferFromRepository : ITransferFromRepository
    {
        private readonly AuditingDbContext _context;
        public TransferFromRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.TransfersFrom
                .Any(e => e.Id == id);
        }

        public bool ExistsByCashAccountId(int id)
        {
            return _context.TransfersFrom
                .Any(e => e.CashAccount.Id == id);
        }
        public bool ExistsByTransferId(int id)
        {
            return _context.TransfersFrom
                .Any(e => e.Transfer.Id == id);
        }

        public async Task<TransferFrom> GetItem(int id)
        {
            return await _context.TransfersFrom
                .FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<TransferFrom> GetItemByTransferId(int id)
        {
            return await _context.TransfersFrom
                .FirstOrDefaultAsync(e => e.Transfer.Id == id);
        }
        public async Task<TransferFrom> GetItemByCashAccountId(int id)
        {
            return await _context.TransfersFrom
                .FirstOrDefaultAsync(e => e.CashAccount.Id == id);
        }

        public async Task<List<TransferFrom>> GetListItems()
        {
            return await _context.TransfersFrom.ToListAsync();
        }
        public async Task<List<TransferFrom>> GetListByCashAccountId(int id)
        {
            return await _context.TransfersFrom
                .Where(e => e.CashAccount.Id == id).ToListAsync();
        }

        public async Task<List<TransferFrom>> GetListByTransferId(int id)
        {
            return await _context.TransfersFrom
                .Where(e => e.Transfer.Id == id).ToListAsync();
        }

        public async Task Create(TransferFrom entity)
        {
            _context.TransfersFrom.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Remove(TransferFrom entity)
        {
            _context.TransfersFrom.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TransferFrom entity)
        {
            _context.TransfersFrom.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
