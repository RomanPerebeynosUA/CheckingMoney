using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.ExpensesEntity
{
    public class ExpensesCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }


        public List<ExpCategory> ExpCategories { get; set; }

        public ExpensesCategory()
        {
            ExpCategories = new List<ExpCategory>();
        }


    }
}
