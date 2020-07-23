using AuditingMoney.Entity.Domain.IncomeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
    public interface IIncomeCategoryRepository
    {
        bool Exists(int id);

        Task<List<IncomeCategory>> GetListItems();
        Task<IncomeCategory> GetItem(int id);
        Task<IncomeCategory> GetItemByName(string name);

        Task Create(IncomeCategory entity);
        Task Remove(IncomeCategory entity);
        Task Update(IncomeCategory entity);

    }
}
