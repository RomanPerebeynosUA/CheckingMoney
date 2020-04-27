using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Entity.ExpensesEntity
{
    public class Expenses_ExpensesCategory
    {
        public int Expenses_Id { get; set; }
        public Expenses Expenses { get; set; }

        public int ExpensesCategory_Id { get; set; }
        public ExpensesCategory ExpensesCategory { get; set; }
    }
}
