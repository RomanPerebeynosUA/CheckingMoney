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
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        private readonly AuditingDbContext _context;
        public IncomeCategoryRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.IncomeCategories.Any(e => e.Id == id);
        }

        public async Task<IncomeCategory> GetItem(int id)
        {
            return await _context.IncomeCategories.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IncomeCategory> GetItemByName(string name)
        {
            return await _context.IncomeCategories.FirstOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<IncomeCategory>> GetListItems()
        {
            return await _context.IncomeCategories.ToListAsync();
        }

        public async Task RemoveEntity(IncomeCategory entity)
        {
            _context.IncomeCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(IncomeCategory entity)
        {
            _context.IncomeCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(IncomeCategory entity)
        {
            _context.IncomeCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
