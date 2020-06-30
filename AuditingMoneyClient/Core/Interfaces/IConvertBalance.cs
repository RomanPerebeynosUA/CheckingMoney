using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface IConvertBalance
    {
        BalanceViewModel ConvertTo(BalanceJsonModel item);
        BalanceJsonModel ConvertTo(BalanceViewModel item);
        List<BalanceJsonModel> ConverListTo(List<BalanceViewModel> items);
        List<BalanceViewModel> ConverListTo(List<BalanceJsonModel> items);
    }
}
