using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.ExpensesEntity
{
    public class Expenses
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }


        public List<ExpCategory> ExpCategories { get; set; }

        public Expenses()
        {
            ExpCategories = new List<ExpCategory>();
        }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public CashAccount CashAccount { get; set; }


    }
}
