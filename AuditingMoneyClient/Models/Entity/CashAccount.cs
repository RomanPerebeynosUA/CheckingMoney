using AuditingMoneyClient.Models.Entity.BalanceEntity;
using AuditingMoneyClient.Models.Entity.ExpensesEntity;
using AuditingMoneyClient.Models.Entity.IncomeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity
{
    public class CashAccount
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public string Note { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>

        public int Balance_Id { get; set; }
        public Balance Balance { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<Income> Incomes { get; set; }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<Expenses> ListExpenses { get; set; }

    }
}
