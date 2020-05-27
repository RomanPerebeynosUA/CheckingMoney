using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.ExpensesEntity
{
    public class ExpCategory
    {
        public int ExpensesId { get; set; }
        public Expenses Expenses { get; set; }

        public int ExpensesCategoryId { get; set; }
        public ExpensesCategory ExpensesCategory { get; set; }
    }
}
