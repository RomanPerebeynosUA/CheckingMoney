using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.BalanceEntity
{
    public class Balance
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public string UserId { get; set; }

        public DateTime DateCreated { get; set; }
        public List<BalanKindOfCurr> BalanKindOfCurrs { get; set; }
        public Balance()
        {
            BalanKindOfCurrs = new List<BalanKindOfCurr>();
        }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<CashAccount> CashAccounts { get; set; }


    }
}
