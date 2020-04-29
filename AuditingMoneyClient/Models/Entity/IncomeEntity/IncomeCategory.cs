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
        /// one to many connection 
        /// </summary>
        public int Income_Id { get; set; }
        public Income Income { get; set; }
    }
}
