﻿using AuditingMoney.Entity.Domain.IncomeEntity;
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
        Task SaveEntity(IncomeCategory entity);
        Task RemoveEntity(IncomeCategory entity);
        Task UpdateEntity(IncomeCategory entity);
        IQueryable<IncomeCategory> GetEntityNoAsyncListItems();
    }
}