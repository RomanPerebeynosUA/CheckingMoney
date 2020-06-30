using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Interfaces
{
    public interface IConvertCashAccount
    {
        CashAccountViewModel ConvertTo(CashAccountJsonModel item);
        CashAccountJsonModel ConvertTo(CashAccountViewModel item, int balance_id);
        List<CashAccountViewModel> ConverListTo(List<CashAccountJsonModel> items);
        List<CashAccountJsonModel> ConverListTo(List<CashAccountViewModel> items);
    }
}
