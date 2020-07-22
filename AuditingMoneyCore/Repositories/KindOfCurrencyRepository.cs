using AuditingMoney.Entity.Domain.BalanceEntity;
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
    public class KindOfCurrencyRepository : IKindOfCurrencyRepository
    {
        private readonly AuditingDbContext _context;
        public KindOfCurrencyRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.KindOfCurrencies.Any(e => e.Id == id);
        }

        public async Task<KindOfCurrency> GetItem(int id)
        {
            return await _context.KindOfCurrencies.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<KindOfCurrency>> GetListItems()
        {
            return await _context.KindOfCurrencies.ToListAsync();
        }

        public async Task Remove(KindOfCurrency entity)
        {
            _context.KindOfCurrencies.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Create(KindOfCurrency entity)
        {
            _context.KindOfCurrencies.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(KindOfCurrency entity)
        {
            _context.KindOfCurrencies.Update(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task<KindOfCurrency> GetItemByName(string name)
        {
            return await _context.KindOfCurrencies.FirstOrDefaultAsync(e => e.Name == name);
        }
    }
}
