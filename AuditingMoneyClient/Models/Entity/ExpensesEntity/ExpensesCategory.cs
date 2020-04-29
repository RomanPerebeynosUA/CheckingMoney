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
        /// one to many connection 
        /// </summary>
        public int Id_Expenses { get; set; }
        public  Expenses Expenses { get; set; }


    }
}
