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
        public async Task<Income> GetItem(int id)
        {
            return await _context.Incomes.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<Income>> GetListItems()
        {
            return await _context.Incomes.ToListAsync();
        }

        public async Task RemoveEntity(Income entity)
        {
            _context.Incomes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveEntity(Income entity)
        {
            _context.Incomes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEntity(Income entity)
        {
            _context.Incomes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
