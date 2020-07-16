using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
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
            CreateMap<CashAccount, CashAccountJsonModel>();
            CreateMap<KindOfCurrency, KindOfCurrencyJsonModel>();

            CreateMap<BalanceJsonModel, Balance>();
            CreateMap<CashAccountJsonModel, CashAccount>();

        }
    }
}
