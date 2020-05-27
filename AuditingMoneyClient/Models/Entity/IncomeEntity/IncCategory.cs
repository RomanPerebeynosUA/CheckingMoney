using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.IncomeEntity
{
    public class IncCategory
    {
        public int IncomeId { get; set; }
        public Income Income { get; set; }

        public int IncomeCategoryId { get; set; }
        public IncomeCategory IncomeCategory { get; set; }
    }
}
