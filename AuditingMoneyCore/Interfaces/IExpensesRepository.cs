﻿using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoney.Entity.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Interfaces
{
   public interface IExpensesRepository
    {
        public IEnumerable<ExpensesJsonModel> GetExpensesForView(int id);
        bool Exists(int id);
        bool ExistsByCashAccountId(int id);

        Task<List<Expenses>> GetListItems();
        Task<List<Expenses>> GetListItems(int id);
        Task<Expenses> GetItem(int id);
        Task<Expenses> GetItemByDate(DateTime dateTime);

        Task CreateComunication(Expenses expenses, ExpensesCategory expensesCategory);
        Task Create(Expenses entity, int cashAccountId);
        Task Remove(Expenses entity);
        Task Update(Expenses entity);
  
    }

}
