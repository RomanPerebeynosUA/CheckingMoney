﻿using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyAPI.Models.JsonModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudititngMoneyAPI.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap <Balance, BalanceJsonModel>();
            CreateMap<CashAccount, CashAccountJsonModel>();
        }
    }
}
