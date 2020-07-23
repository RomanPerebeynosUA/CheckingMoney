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
    public class ExpensesCategoryRepository : IExpensesCategoryRepository
    {
        private readonly AuditingDbContext _context;
        public ExpensesCategoryRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.ExpensesCategories.Any(e => e.Id == id);
        }
        public async  Task<ExpensesCategory> GetItem(int id)
        {
            return await _context.ExpensesCategories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<ExpensesCategory> GetItemByName(string name)
        {
            return await _context.ExpensesCategories.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<ExpensesCategory>> GetListItems()
        {
            return await _context.ExpensesCategories.ToListAsync();
        }

        public async Task Remove(ExpensesCategory entity)
        {
            _context.ExpensesCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(ExpensesCategory entity)
        {
            _context.ExpensesCategories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ExpensesCategory entity)
        {
            _context.ExpensesCategories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
