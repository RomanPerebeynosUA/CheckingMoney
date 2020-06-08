using AuditingMoney.Entity.Domain;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class CashAccountRepository : ICashAccountRepository
    {
        private readonly AuditingDbContext _context;
        public CashAccountRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.CashAccounts.Any(e => e.Id == id);
        }

        public bool ExistsByBalanceId(int id)
        {
            return _context.CashAccounts.Any(e => e.Balance.Id == id);
        }

       
        public async Task<CashAccount> GetItem(int id)
        {
            return await _context.CashAccounts.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<CashAccount> GetItemByBalanceId(int id)
        {
            return await _context.CashAccounts.FirstOrDefaultAsync(e => e.Balance.Id == id);
        }

        public async Task<List<CashAccount>> GetListItems()
        {
            return await _context.CashAccounts.ToListAsync();
        }

        public async  Task<List<CashAccount>> GetListItems(int id)
        {
           return await _context.CashAccounts.Where(e => e.Balance.Id == id).ToListAsync();
        }

        public async Task Remove(CashAccount entity)
        {
            _context.CashAccounts.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(CashAccount entity)
        {
            _context.CashAccounts.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CashAccount entity)
        {
            _context.CashAccounts.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<CashAccount> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }
    }
}
