using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.ExpensesEntity;
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
            await UpdateAmount(entity, false);
            _context.Expenses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Expenses entity, int cashAccountId)
        {
            entity.CashAccount = await _context.CashAccounts.
                 FirstOrDefaultAsync(e => e.Id == cashAccountId);

            _context.Expenses.Add(entity);
            await UpdateAmount(entity, true);
            await _context.SaveChangesAsync();

        }

        public async Task Update(Expenses entity)
        {
            _context.Expenses.Update(entity);
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

        public IEnumerable<ExpensesJsonModel> GetExpensesForView(int id)
        {
            List<ExpensesJsonModel> jsonModels = new List<ExpensesJsonModel>();

            var expenses = from e in _context.Expenses
                          join enc in _context.ExpCategories on e.Id equals enc.ExpensesId
                          join c in _context.ExpensesCategories on enc.ExpensesCategoryId equals c.Id
                          where (e.CashAccount.Id == id)
                          select new
                          {
                              Id = e.Id,
                              Amount = e.Amount,
                              Category = c.Name,
                              Note = e.Note,
                              Date = e.Date,
                              CashAccount_Id = e.CashAccount.Id
                          };

            foreach (var e in expenses)
            {
                var expense = new ExpensesJsonModel()
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Category = e.Category,
                    Note = e.Note,
                    Date = e.Date,
                    CashAccount_Id = e.CashAccount_Id
                };
                jsonModels.Add(expense);
            }
            return jsonModels;
        }

        private async Task UpdateAmount(Expenses entity, bool change)
        {
            CashAccount cashAccount = await _context.CashAccounts.FirstOrDefaultAsync
                (e => e.Id == entity.CashAccount.Id);

            Balance balance = await _context.Balances.FirstOrDefaultAsync
              (e => e.CashAccounts.Contains(cashAccount));

            if (change == true)
            {
                cashAccount.Amount -= entity.Amount;
                balance.Amount -= entity.Amount;
            }
            else
            {
                cashAccount.Amount += entity.Amount;
                balance.Amount += entity.Amount;
            }
            _context.CashAccounts.Update(cashAccount);
            _context.Balances.Update(balance);
        }
    }
}
