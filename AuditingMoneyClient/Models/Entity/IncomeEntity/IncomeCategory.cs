using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.IncomeEntity
{
    public class IncomeCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }


        /// <summary>
        /// many to many connection 
        /// </summary>
        public List<Income_IncomeCategory> Income_IncomeCategories { get; set; }

        public IncomeCategory()
        {
            Income_IncomeCategories = new List<Income_IncomeCategory>();
        }
    }
}
