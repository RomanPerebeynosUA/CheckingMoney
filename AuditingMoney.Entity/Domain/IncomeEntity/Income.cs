using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain.IncomeEntity
{
    public class Income
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }


        public List<IncCategory> IncCategories { get; set; }

        public Income()
        {
            IncCategories = new List<IncCategory>();
        }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public CashAccount CashAccount { get; set; }


        ///// <summary>
        ///// one to many connection 
        ///// </summary>
        //public List<IncomeCategory> IncomeCategories { get; set; }
    }
}
