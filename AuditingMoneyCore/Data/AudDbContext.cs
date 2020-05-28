using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoney.Entity.Domain.IncomeEntity;
using AuditingMoney.Entity.Domain.TransferEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Data
{
    public class AudDbContext : DbContext
    {
        public DbSet<KindOfCurrency> KindOfCurrencies { get; set; }
        public DbSet<Balance> Balances { get; set; }
       // public DbSet<BalanKindOfCurr> BalanKindOfCurrs { get; set; }

        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<ExpensesCategory> ExpensesCategories { get; set; }
      //  public DbSet<ExpCategory> ExpCategories { get; set; }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
      //  public DbSet<IncCategory> IncCategories { get; set; }

        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<TransferFrom> TransfersFrom { get; set; }
        public DbSet<TransferTo> TransfersTo { get; set; }

        public DbSet<CashAccount> CashAccounts { get; set; }


        public AudDbContext(DbContextOptions<AudDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IncCategory>()
                .HasKey(t => new { t.IncomeId, t.IncomeCategoryId });

            modelBuilder.Entity<IncCategory>()
                .HasOne(sc => sc.Income)
                .WithMany(s => s.IncCategories)
                .HasForeignKey(sc => sc.IncomeId);

            modelBuilder.Entity<IncCategory>()
                .HasOne(sc => sc.IncomeCategory)
                .WithMany(c => c.IncCategories)
                .HasForeignKey(sc => sc.IncomeCategoryId);
            /////////////////////////////////////////////////////////////////
            modelBuilder.Entity<ExpCategory>()
              .HasKey(t => new { t.ExpensesCategoryId, t.ExpensesId });

            modelBuilder.Entity<ExpCategory>()
                .HasOne(sc => sc.Expenses)
                .WithMany(s => s.ExpCategories)
                .HasForeignKey(sc => sc.ExpensesId);

            modelBuilder.Entity<ExpCategory>()
                .HasOne(sc => sc.ExpensesCategory)
                .WithMany(c => c.ExpCategories)
                .HasForeignKey(sc => sc.ExpensesCategoryId);

            ////////////////////////////////////////////////////////////////
            modelBuilder.Entity<BalanKindOfCurr>()
            .HasKey(t => new { t.BalanceId, t.KindOfCurrencyId });

            modelBuilder.Entity<BalanKindOfCurr>()
                .HasOne(sc => sc.Balance)
                .WithMany(s => s.BalanKindOfCurrs)
                .HasForeignKey(sc => sc.BalanceId);

            modelBuilder.Entity<BalanKindOfCurr>()
                .HasOne(sc => sc.KindOfCurrency)
                .WithMany(c => c.BalanKindOfCurrs)
                .HasForeignKey(sc => sc.KindOfCurrencyId);

        }
    }
}
