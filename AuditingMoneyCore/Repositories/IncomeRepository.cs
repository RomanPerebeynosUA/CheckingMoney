using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoneyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class IncomeRepository : IIncomeRepository
    {
        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Income> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Income>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(Income entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(Income entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Income entity)
        {
            throw new NotImplementedException();
        }
    }
}
