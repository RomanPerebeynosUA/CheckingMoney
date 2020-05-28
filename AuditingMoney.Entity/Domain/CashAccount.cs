using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoney.Entity.Domain.TransferEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoney.Entity.Domain
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

        public Balance Balance { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<Income> Incomes { get; set; }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<Expenses> ListExpenses { get; set; }


        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<TransferFrom> TransfersFrom { get; set; }

        /// <summary>
        /// one to many connection 
        /// </summary>
        public List<TransferTo> TransfersTo { get; set; }

    }
}
