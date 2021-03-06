﻿using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoney.Entity.Domain.TransferEntity;
using AuditingMoney.Entity.JsonModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyAPI.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap <Balance, BalanceJsonModel>();
            CreateMap<BalanceJsonModel, Balance>();

            CreateMap<KindOfCurrency, KindOfCurrencyJsonModel>();
            CreateMap<KindOfCurrencyJsonModel, KindOfCurrency>();

            CreateMap<CashAccount, CashAccountJsonModel>();
            CreateMap<CashAccountJsonModel, CashAccount>();

            CreateMap<Expenses,ExpensesJsonModel>();
            CreateMap<ExpensesJsonModel, Expenses>();

            CreateMap<ExpensesCategory, ExpensesCategoryJsonModel>();
            CreateMap<ExpensesCategoryJsonModel, ExpensesCategory>();

            CreateMap<Income, IncomeJsonModel>();
            CreateMap<IncomeJsonModel, Income>();

            CreateMap<IncomeCategory, IncomeCategoryJsonModel>();
            CreateMap<IncomeCategoryJsonModel, IncomeCategory>();

            CreateMap<Transfer, TransferJsonModel>();
            CreateMap<TransferJsonModel, Transfer>();








        }
    }
}
