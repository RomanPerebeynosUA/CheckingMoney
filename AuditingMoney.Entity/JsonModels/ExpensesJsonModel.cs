using System;
using System.Collections.Generic;
using System.Text;

namespace AuditingMoney.Entity.JsonModels
{
   public class ExpensesJsonModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Category { get; set; }
    
        public string Note { get; set; }

        public DateTime Date { get; set; }

        public int CashAccount_Id { get; set; }
    }
}
