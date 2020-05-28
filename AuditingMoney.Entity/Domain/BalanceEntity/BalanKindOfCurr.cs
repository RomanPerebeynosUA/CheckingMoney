using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.BalanceEntity
{
    public class BalanKindOfCurr
    {
        public int BalanceId { get; set; }
        public Balance Balance { get; set; }

        public int KindOfCurrencyId { get; set; }
        public KindOfCurrency KindOfCurrency { get; set; }
    }
}
