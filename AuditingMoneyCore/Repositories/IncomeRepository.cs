using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoney.Entity.JsonModels;
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
            await UpdateAmount(entity, false);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Income entity, int cashAccountId)
        {
            entity.CashAccount = await _context.CashAccounts.
                FirstOrDefaultAsync(e => e.Id == cashAccountId);

            _context.Incomes.Add(entity);
            await UpdateAmount(entity, true);
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

        public IEnumerable<IncomeJsonModel> GetIncomesForView(int id)
        {
            List<IncomeJsonModel> jsonModels = new List<IncomeJsonModel>();

            var incomes = from i in _context.Incomes
                           join inc in _context.IncCategories on i.Id equals inc.IncomeId
                           join c in _context.IncomeCategories on inc.IncomeCategoryId equals c.Id
                           where (i.CashAccount.Id == id)
                           select new
                           {
                               Id = i.Id,
                               Amount = i.Amount,
                               Category = c.Name,
                               Note = i.Note,
                               Date = i.Date,
                               CashAccount_Id = i.CashAccount.Id
                           };

            foreach (var i in incomes)
            {
                var income = new IncomeJsonModel()
                {
                    Id = i.Id,                  
                    Amount = i.Amount,
                    Category = i.Category,
                    Note = i.Note,
                    Date = i.Date,
                    CashAccount_Id = i.CashAccount_Id
                };
                jsonModels.Add(income);
            }
            return jsonModels;
        }

        private async Task UpdateAmount(Income entity, bool change)
        {
            CashAccount cashAccount = await _context.CashAccounts.FirstOrDefaultAsync
                (e => e.Id == entity.CashAccount.Id);

             Balance balance = await _context.Balances.FirstOrDefaultAsync
               (e => e.CashAccounts.Contains(cashAccount));

            if (change == true)
            {
                cashAccount.Amount += entity.Amount;
                balance.Amount += entity.Amount;
            }
            else
            {
                cashAccount.Amount -= entity.Amount;
                balance.Amount -= entity.Amount;
            }
            _context.CashAccounts.Update(cashAccount);
            _context.Balances.Update(balance);
        }
    }
}
