﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.JsonModels
{
    public class CashAccountJsonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public string Note { get; set; }

        public int BalanceId { get; set; }

    }
}
