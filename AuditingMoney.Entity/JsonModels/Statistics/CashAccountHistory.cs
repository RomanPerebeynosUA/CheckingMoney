using System;
using System.Collections.Generic;
using System.Text;

namespace AuditingMoney.Entity.JsonModels.Statistics
{
    public class CashAccountHistory
    {
        public int CashAccount_Id { get; set; }
        public double Amount { get; set; }

        public string Category { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        public bool Change { get; set; }
    }
}
