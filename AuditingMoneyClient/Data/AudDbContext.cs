using AuditingMoneyClient.Models.Entity;
using AuditingMoneyClient.Models.Entity.BalanceEntity;
using AuditingMoneyClient.Models.Entity.ExpensesEntity;
using AuditingMoneyClient.Models.Entity.IncomeEntity;
using AuditingMoneyClient.Models.Entity.TransferEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Data
{
    public class AudDbContext : DbContext
    {
        public DbSet<KindOfCurrency> KindOfCurrencies { get; set; }
        public DbSet<Balance> Balances { get; set; }

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpensesCategory> ExpensesCategories { get; set; }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferFrom> TransfersFrom { get; set; }
        public DbSet<TransferTo> TransfersTo { get; set; }

        public DbSet<CashAccount> CashAccounts { get; set; }


        public AudDbContext(DbContextOptions<AudDbContext> options) : base(options)
        {
        }

    }
}
