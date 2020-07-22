using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.JsonModels;
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

        public async Task<IEnumerable<Balance>> GetListItems()
        {
            return await _context.Balances.ToListAsync();          
        }
        public async Task<IEnumerable<Balance>> GetListItems(string id)
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

        public async Task CreateComunication(Balance balance, KindOfCurrency kindOfCurrency)
        {
            var balanKindOfCurr = new BalanKindOfCurr() 
            {
                BalanceId = balance.Id,
                KindOfCurrencyId = kindOfCurrency.Id
            };
            _context.BalanKindOfCurrs.Add(balanKindOfCurr);
            await _context.SaveChangesAsync();
        }

        public async Task<Balance> GetItemByDateCreated(DateTime dateTime)
        {
            return await _context.Balances.FirstOrDefaultAsync(e => e.DateCreated == dateTime);
        }
        
        public IEnumerable<BalanceJsonModel> GetBalancesForView(string id)
        {
            List<BalanceJsonModel> jsonModels = new List<BalanceJsonModel>();
            var balances = from b in _context.Balances
                           join bk in _context.BalanKindOfCurrs on b.Id equals bk.BalanceId
                           join k in _context.KindOfCurrencies on bk.KindOfCurrencyId equals k.Id
                           where (b.UserId == id)
                           select new
                           {
                               User_id = b.UserId,
                               Id = b.Id,
                               Amount = b.Amount,
                               Name = k.Name
                           };

            foreach (var b in balances)
            {
                var balance = new BalanceJsonModel() 
                {
                    Id = b.Id,
                    UserId = b.User_id,
                    Amount = b.Amount,
                    Name = b.Name
                };
                jsonModels.Add(balance);
            }
            return jsonModels;
        }
    }
}
