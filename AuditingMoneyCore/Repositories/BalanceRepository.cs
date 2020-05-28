using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyCore.Data;
using AuditingMoneyCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Repositories
{
    public class BalanceRepository : IBalanceRepository
    {
       private readonly  AudDbContext _context;
        public BalanceRepository(AudDbContext context)
        {
           _context = context;
        }


        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Balance> GetEntityNoAsyncListItems()
        {
            throw new NotImplementedException();
        }

        public Task<Balance> GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Balance>> GetListItems()
        {
            throw new NotImplementedException();
        }

        public Task RemoveEntity(Balance entity)
        {
            throw new NotImplementedException();
        }

        public Task SaveEntity(Balance entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateEntity(Balance entity)
        {
            throw new NotImplementedException();
        }
    }
}
