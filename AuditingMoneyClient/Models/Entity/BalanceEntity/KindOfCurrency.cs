using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.BalanceEntity
{
    public class KindOfCurrency
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Badge { get; set; }

        public List<BalanKindOfCurr> BalanKindOfCurrs { get; set; }
        public KindOfCurrency()
        {
            BalanKindOfCurrs = new List<BalanKindOfCurr>();
        }
    }
}
