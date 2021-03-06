﻿using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoney.Entity.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IIncomeRepository
    {
        public IEnumerable<IncomeJsonModel> GetIncomesForView(int id);
        bool Exists(int id);
        bool ExistsByCashAccountId(int id);

        Task<List<Income>> GetListItems();
        Task<List<Income>> GetListItems(int id);
        Task<Income> GetItem(int id);
        Task<Income> GetItemByDate(DateTime dateTime);

        Task CreateComunication(Income income, IncomeCategory incomeCategory);
        Task Create(Income entity, int cashAccountId);
        Task Remove(Income entity);
        Task Update(Income entity);
    }
}
