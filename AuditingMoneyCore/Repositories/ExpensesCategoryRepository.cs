using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoneyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class ExpensesCategoryRepository : IExpensesCategoryRepository
    {
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ExpensesCategory> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<ExpensesCategory> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ExpensesCategory>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(ExpensesCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(ExpensesCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(ExpensesCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
