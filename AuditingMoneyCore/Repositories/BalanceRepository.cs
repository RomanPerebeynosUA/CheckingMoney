using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces;
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

        public IQueryable<Balance> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<Balance> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Balance>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public async Task RemoveEntity(Balance entity)
        {
            _context.Balances.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Balance entity)
        {
            _context.Balances.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Balance entity)
        {
            _context.Balances.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
