using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class CashAccountViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }

        public string Currency { get; set; }

    }
}
