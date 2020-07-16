using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoneyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class ExpensesRepository : IExpensesRepository
    {
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Expenses> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<Expenses> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Expenses>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(Expenses entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(Expenses entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Expenses entity)
        {
            throw new NotImplementedException();
        }
    }
}
