using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly AuditingDbContext _context;
        public BalanceRepository(AuditingDbContext context)
        {
           _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Balances.Any(e => e.Id == id);
        }

        public bool ExistsByUserId(string id)
        {
            return _context.Balances.Any(e => e.UserId == id);
        }

      

        public async Task<Balance> GetItem(int id)
        {
            return await _context.Balances.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Balance> GetItemByUserId(string id)
        {
            return await _context.Balances.FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<List<Balance>> GetListItems()
        {
            return await _context.Balances.ToListAsync();          
        }
        public async Task<List<Balance>> GetListItems(string id)
        {
            return await _context.Balances.Where(e => e.UserId == id).ToListAsync();
        }

        public async Task Remove(Balance entity)
        {
            _context.Balances.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Balance entity)
        {
            _context.Balances.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Balance entity)
        {
            _context.Balances.Update(entity);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Balance> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }
    }
}
