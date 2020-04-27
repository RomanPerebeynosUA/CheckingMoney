using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.IncomeEntity
{
    public class Income_IncomeCategory
    {
        public int Income_Id { get; set; }
        public Income Income { get; set; }

        public int IncomeCategory_Id { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}
