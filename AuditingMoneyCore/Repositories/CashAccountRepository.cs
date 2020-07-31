using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.JsonModels;
using AuditingMoney.Entity.JsonModels.Statistics;
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
    public class CashAccountRepository : ICashAccountRepository
    {
        private readonly AuditingDbContext _context;
        public CashAccountRepository(AuditingDbContext context)
        {
            _context = context;
        }

        public bool Exists(int id)
        {
            return _context.CashAccounts.Any(e => e.Id == id);
        }

        public bool ExistsByBalanceId(int id)
        {
            return _context.CashAccounts.Any(e => e.Balance.Id == id);
        }

       
        public async Task<CashAccount> GetItem(int id)
        {
            return await _context.CashAccounts.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<CashAccount> GetItemByBalanceId(int id)
        {
            return await _context.CashAccounts.FirstOrDefaultAsync(e => e.Balance.Id == id);
        }

        public async Task<List<CashAccount>> GetListItems()
        {
            return await _context.CashAccounts.ToListAsync();
        }

        public async  Task<List<CashAccount>> GetListItems(int id)
        {
           return await _context.CashAccounts.Where(e => e.Balance.Id == id).ToListAsync();
        }

        public async Task Remove(CashAccount entity)
        {
            _context.CashAccounts.Remove(entity);
             await UpdateBalance(entity, false);
            await _context.SaveChangesAsync();
        }

        public async Task Create(CashAccount entity)
        {
            _context.CashAccounts.Add(entity);
            await _context.SaveChangesAsync();
            await UpdateBalance(entity, true);
        }

        public async Task Update(CashAccount entity)
        {
            _context.CashAccounts.Update(entity);
            await _context.SaveChangesAsync();
        }

        private async  Task UpdateBalance (CashAccount entity, bool change)
        {
            var balance = await _context.Balances.FirstOrDefaultAsync
                (e => e.Id == entity.Balance.Id);
            if (change == true)
            {
                balance.Amount += entity.Amount;
            }
            else
            {
                balance.Amount -= entity.Amount;
            }
            _context.Balances.Update(balance);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<CashAccountJsonModel> GetCashAccountsForView(int id)
        {
            List<CashAccountJsonModel> jsonModels = new List<CashAccountJsonModel>();
            
            var cashAccounts = from c in _context.CashAccounts
                               join b in _context.Balances on c.Balance.Id equals b.Id
                               join bk in _context.BalanKindOfCurrs on b.Id equals bk.BalanceId
                               join k in _context.KindOfCurrencies on bk.KindOfCurrencyId equals k.Id
                               where(b.Id == id)
                               select new
                               {
                                   Id = c.Id,
                                   Name = c.Name,
                                   Amount = c.Amount,
                                   Currency = k.Name,
                                   Note = c.Note,
                                   BalanceId = b.Id
                               };

            foreach (var c in cashAccounts)
            {
                var cashAccount = new CashAccountJsonModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Amount = c.Amount,
                    Currency = c.Currency,
                    Note = c.Note,
                    BalanceId = c.Id
                };
                jsonModels.Add(cashAccount);
            }
            return jsonModels;
        }
        public IEnumerable<CashAccountHistory> GetCashAccountHistory(int id)
        {
            List<CashAccountHistory> cashAccountHistory = new List<CashAccountHistory>();

            var incomes = from i in _context.Incomes
                          join inc in _context.IncCategories on i.Id equals inc.IncomeId
                          join c in _context.IncomeCategories on inc.IncomeCategoryId equals c.Id
                          where (i.CashAccount.Id == id)
                          select new
                          {
                              Amount = i.Amount,
                              Category = c.Name,
                              Note = i.Note,
                              Date = i.Date,
                              CashAccount_Id = i.CashAccount.Id
                          };

            var expenses = from e in _context.Expenses
                           join enc in _context.ExpCategories on e.Id equals enc.ExpensesId
                           join c in _context.ExpensesCategories on enc.ExpensesCategoryId equals c.Id
                           where (e.CashAccount.Id == id)
                           select new
                           {
                               Amount = e.Amount,
                               Category = c.Name,
                               Note = e.Note,
                               Date = e.Date,
                               CashAccount_Id = e.CashAccount.Id
                           };

            foreach (var i in incomes)
            {
                var historyItem = new CashAccountHistory()
                {
                    Change = true,
                    Amount = i.Amount,
                    Category = i.Category,
                    Note = i.Note,
                    Date = i.Date,
                    CashAccount_Id = i.CashAccount_Id
                };
                cashAccountHistory.Add(historyItem);
            }

            foreach (var i in expenses)
            {
                var historyItem = new CashAccountHistory()
                {
                    Change = false,
                    Amount = i.Amount,
                    Category = i.Category,
                    Note = i.Note,
                    Date = i.Date,
                    CashAccount_Id = i.CashAccount_Id
                };
                cashAccountHistory.Add(historyItem);
            }
            cashAccountHistory.OrderBy(e => e.Date);

            return cashAccountHistory;
        }

        public async Task<List<CashAccount>> GetCashAccountNames(int id)
        {
            //var cashAccount = await _context.CashAccounts.FirstOrDefaultAsync(e => e.Id == id);

            //var balance =  await _context.Balances.FirstOrDefaultAsync
            //    (e => e.Id == cashAccount.Balance.Id);

            var cashAccounts  = await _context.CashAccounts.Where(e => e.Balance.Id == 1).ToListAsync();

            return cashAccounts;
        }
    }
}
