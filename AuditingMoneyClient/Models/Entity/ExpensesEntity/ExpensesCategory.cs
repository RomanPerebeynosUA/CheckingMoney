using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.ExpensesEntity
{
    public class ExpensesCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }


        /// <summary>
        /// many to many connection 
        /// </summary>
        public List<Expenses_ExpensesCategory> Expenses_ExpensesCategories { get; set; }

        public ExpensesCategory()
        {
            Expenses_ExpensesCategories = new List<Expenses_ExpensesCategory>();
        }
    }
}
