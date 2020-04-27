using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.IncomeEntity
{
    public class Income
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }

        public DateTime Date { get; set; }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public int CashAccount_Id { get; set; }
        public CashAccount CashAccount { get; set; }


        /// <summary>
        /// many to many connection 
        /// </summary>
        public List<Income_IncomeCategory> Income_IncomeCategories { get; set; }

        public Income()
        {
            Income_IncomeCategories = new List<Income_IncomeCategory>();
        }

    }
}
