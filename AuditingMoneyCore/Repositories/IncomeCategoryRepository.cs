using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoneyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class IncomeCategoryRepository : IIncomeCategoryRepository
    {
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<IncomeCategory> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<IncomeCategory> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<IncomeCategory>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(IncomeCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(IncomeCategory entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(IncomeCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
