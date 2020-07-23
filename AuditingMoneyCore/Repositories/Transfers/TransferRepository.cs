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
    public class TransferRepository : ITransferRepository
    {
        private readonly AuditingDbContext _context;
        public TransferRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Transfers.Any(e => e.Id == id);
        }

        public bool ExistsRemittanceFrom(int id)
        {
            return _context.Transfers.Any(e => e.TransfersFrom.
            Any(c => c.CashAccount.Id == id));   
        }
        public bool ExistsRemittanceTo(int id)
        {
            return _context.Transfers.Any(e => e.TransfersTo.
            Any(c => c.CashAccount.Id == id));
        }

        public async Task<Transfer> GetItem(int id)
        {
            return await _context.Transfers.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<Transfer> GetItemByDate(DateTime dateTime)
        {
            return await _context.Transfers.FirstOrDefaultAsync(e => e.Date == dateTime);
        }

        public async  Task<List<Transfer>> GetListItems()
        {
            return await _context.Transfers.ToListAsync();
        }

        public async  Task<List<Transfer>> GetListItemsRemittanceTo(int id)
        {
            return await _context.Transfers.Where(
                e => e.TransfersTo.Any(c => c.CashAccount.Id == id)).ToListAsync();
        }
        public async Task<List<Transfer>> GetListItemsRemittanceFrom(int id)
        {
            return await _context.Transfers.Where(
                e => e.TransfersFrom.Any(c => c.CashAccount.Id == id)).ToListAsync();
        }

        public async Task Create(Transfer entity)
        {
            _context.Transfers.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async  Task Remove(Transfer entity)
        {
            _context.Transfers.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async  Task Update(Transfer entity)
        {
            _context.Transfers.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateComunication(Transfer transfer, 
            int CashAccountFrom, int CashAccountTo)
        {
            var transferFrom = new TransferFrom();
            transferFrom.CashAccount.Id = CashAccountFrom;
            transferFrom.Transfer.Id = transfer.Id;
            _context.TransfersFrom.Add(transferFrom);

            var transferTo = new TransferTo();
            transferTo.CashAccount.Id = CashAccountTo;
            transferTo.Transfer.Id = transfer.Id;
            _context.TransfersTo.Add(transferTo);

            await _context.SaveChangesAsync();
        }
    }
}
