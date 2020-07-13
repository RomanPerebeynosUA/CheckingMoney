using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<BalanceViewModel, BalanceJsonModel>();
            CreateMap<BalanceJsonModel, BalanceViewModel>();

            //CreateMap<List<BalanceViewModel>, List<BalanceJsonModel>>();
            //CreateMap<List<BalanceJsonModel>, List<BalanceViewModel>>();

            CreateMap<CashAccountViewModel, CashAccountJsonModel>();
            CreateMap<CashAccountJsonModel, CashAccountViewModel>();


        }
    }
}
