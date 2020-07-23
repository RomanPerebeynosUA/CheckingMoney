using AuditingMoney.Entity.Domain.IncomeEntity;
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
    public class IncomeRepository : IIncomeRepository
    {
        private readonly AuditingDbContext _context;
        public IncomeRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Incomes.Any(e => e.Id == id);
        }
        public bool ExistsByCashAccountId(int id)
        {
            return _context.Incomes.Any(e => e.CashAccount.Id == id);
        }
        public async Task<Income> GetItem(int id)
        {
            return await _context.Incomes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Income>> GetListItems()
        {
            return await _context.Incomes.ToListAsync();
        }
        public async Task<List<Income>> GetListItems(int id)
        {
            return await _context.Incomes.
                Where(e => e.CashAccount.Id == id).ToListAsync();

        }
        public async Task Remove(Income entity)
        {
            _context.Incomes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Income entity)
        {
            _context.Incomes.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Income entity)
        {
            _context.Incomes.Update(entity);
            await _context.SaveChangesAsync();
        }   
        public async Task<Income> GetItemByDate(DateTime dateTime)
        {
            return await _context.Incomes.FirstOrDefaultAsync(e => e.Date == dateTime);
        }

        public async Task CreateComunication(Income income, IncomeCategory incomeCategory)
        {
            var incCategory = new IncCategory()
            {
                IncomeId = income.Id,
                IncomeCategoryId = incomeCategory.Id
            };

            _context.IncCategories.Add(incCategory);
            await _context.SaveChangesAsync();
        }
    }
}
