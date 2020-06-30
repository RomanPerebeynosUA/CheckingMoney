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
    public class BalanceRepository : IEntityDeseralizeJson<BalanceJsonModel>, 
        IConvertBalance
    {
        public List<BalanceJsonModel> ConverListTo(List<BalanceViewModel> items)
        {
            List<BalanceJsonModel> balances = new List<BalanceJsonModel>();
            return balances;
        }

        public List<BalanceViewModel> ConverListTo(List<BalanceJsonModel> items)
        {
            List<BalanceViewModel> balances = new List<BalanceViewModel>();
            foreach(BalanceJsonModel item in items)
            {
                BalanceViewModel balance = new BalanceViewModel
                {
                    Amount = item.Amount,
                    Id = item.Id,
                };
                balances.Add(balance);
            }
            return balances;
        }

        public BalanceViewModel ConvertTo(BalanceJsonModel item)
        {
            BalanceViewModel balance = new BalanceViewModel
            {
                Amount = item.Amount,
                Id = item.Id,

            };
            return balance;
        }

        public BalanceJsonModel ConvertTo(BalanceViewModel item)
        {
            throw new NotImplementedException();
        }

        public List<BalanceJsonModel> DeseralizeList(string json)
        {
            var balances =  JsonConvert.DeserializeObject<List<BalanceJsonModel>>(json);
            return balances;
        }

        public BalanceJsonModel DeseralizeObject(string json)
        {
            var balance = JsonConvert.DeserializeObject<BalanceJsonModel>(json);
            return balance;
        }
    }
    
}
