using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Core.Repositories
{
    public class CashAccountRepository : IEntityDeseralizeJson<CashAccountJsonModel>,
       IConvertCashAccount
    {
        public List<CashAccountJsonModel> ConverListTo(List<CashAccountViewModel> items)
        {
            throw new NotImplementedException();
        }
      
        public List<CashAccountViewModel> ConverListTo(List<CashAccountJsonModel> items)
        {
            throw new NotImplementedException();
        }

        public CashAccountViewModel ConvertTo(CashAccountJsonModel item)
        {
            throw new NotImplementedException();
        }

        public CashAccountJsonModel ConvertTo(CashAccountViewModel item, int balance_id)
        {
            CashAccountJsonModel cashAccount = new CashAccountJsonModel
            {
                Amount = item.Amount,
                Name = item.Name,
                Note = item.Note,
                Balance_Id = balance_id,
            };
            return cashAccount;
        }

        public List<CashAccountJsonModel> DeseralizeList(string json)
        {
            var cash = JsonConvert.DeserializeObject<List<CashAccountJsonModel>>(json);
            return cash;
        }

        public CashAccountJsonModel DeseralizeObject(string json)
        {
            var cash = JsonConvert.DeserializeObject<CashAccountJsonModel>(json);
            return cash;
        }
    }
}
