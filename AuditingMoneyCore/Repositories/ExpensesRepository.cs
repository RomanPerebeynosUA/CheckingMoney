using AuditingMoney.Entity.Domain.ExpensesEntity;
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
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly AuditingDbContext _context;
        public ExpensesRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }

        public bool ExistsByCashAccountId(int id)
        {
            return _context.Expenses.Any(e => e.CashAccount.Id == id);
        }

        public async Task<Expenses> GetItem(int id)
        {
            return await _context.Expenses.
                FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Expenses>> GetListItems()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<List<Expenses>> GetListItems(int id)
        {
            return await _context.Expenses.
                Where(e => e.CashAccount.Id == id).ToListAsync();
        }

        public async Task Remove(Expenses entity)
        {
            _context.Expenses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Expenses entity)
        {
            _context.Expenses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Expenses entity)
        {
            _context.Expenses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateComunication(Expenses expenses, 
            ExpensesCategory expensesCategory)
        {
            var expCategory = new ExpCategory() 
            {
                ExpensesId = expenses.Id,
                ExpensesCategoryId = expensesCategory.Id
            };

            _context.ExpCategories.Add(expCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<Expenses> GetItemByDate(DateTime dateTime)
        {
            return await _context.Expenses.FirstOrDefaultAsync(e => e.Date == dateTime);
        }
    }
}
