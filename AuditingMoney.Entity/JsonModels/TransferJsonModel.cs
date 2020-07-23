using System;
using System.Collections.Generic;
using System.Text;

namespace AuditingMoney.Entity.JsonModels
{
    public class TransferJsonModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public int CashAccountFrom_Id { get; set; }

        public int CashAccountTo_Id { get; set; }

        public string Note { get; set; }
    }
}
