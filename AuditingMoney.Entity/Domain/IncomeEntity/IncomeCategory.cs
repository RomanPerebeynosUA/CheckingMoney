using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.IncomeEntity
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }


        public List<IncCategory> IncCategories { get; set; }

        public IncomeCategory()
        {
            IncCategories = new List<IncCategory>();
        }

    }
}
