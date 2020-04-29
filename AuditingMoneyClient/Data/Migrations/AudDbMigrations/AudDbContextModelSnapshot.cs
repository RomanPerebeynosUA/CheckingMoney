﻿// <auto-generated />
using System;
using AuditingMoneyClient.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuditingMoneyClient.Data.Migrations.AudDbMigrations
{
    [DbContext(typeof(AudDbContext))]
    partial class AudDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.BalanceEntity.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.BalanceEntity.KindOfCurrency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Badge")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BalanceId")
                        .HasColumnType("int");

                    b.Property<int>("Balance_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BalanceId");

                    b.ToTable("KindOfCurrencies");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.CashAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("BalanceId")
                        .HasColumnType("int");

                    b.Property<int>("Balance_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BalanceId");

                    b.ToTable("CashAccounts");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.ExpensesEntity.Expenses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CashAccountId")
                        .HasColumnType("int");

                    b.Property<int>("CashAccount_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CashAccountId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.ExpensesEntity.ExpensesCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExpensesId")
                        .HasColumnType("int");

                    b.Property<int>("Id_Expenses")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExpensesId");

                    b.ToTable("ExpensesCategories");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.IncomeEntity.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<int?>("CashAccountId")
                        .HasColumnType("int");

                    b.Property<int>("CashAccount_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CashAccountId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.IncomeEntity.IncomeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IncomeId")
                        .HasColumnType("int");

                    b.Property<int>("Income_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IncomeId");

                    b.ToTable("IncomeCategories");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.TransferEntity.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.TransferEntity.TransferFrom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CashAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Id_Account")
                        .HasColumnType("int");

                    b.Property<int>("Id_Transfer")
                        .HasColumnType("int");

                    b.Property<int?>("TransferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CashAccountId");

                    b.HasIndex("TransferId");

                    b.ToTable("TransfersFrom");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.TransferEntity.TransferTo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CashAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Id_Account")
                        .HasColumnType("int");

                    b.Property<int>("Id_Transfer")
                        .HasColumnType("int");

                    b.Property<int?>("TransferId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CashAccountId");

                    b.HasIndex("TransferId");

                    b.ToTable("TransfersTo");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.BalanceEntity.KindOfCurrency", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.BalanceEntity.Balance", "Balance")
                        .WithMany("KindOfCurrencies")
                        .HasForeignKey("BalanceId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.CashAccount", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.BalanceEntity.Balance", "Balance")
                        .WithMany("CashAccounts")
                        .HasForeignKey("BalanceId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.ExpensesEntity.Expenses", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.CashAccount", "CashAccount")
                        .WithMany("ListExpenses")
                        .HasForeignKey("CashAccountId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.ExpensesEntity.ExpensesCategory", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.ExpensesEntity.Expenses", "Expenses")
                        .WithMany("ExpensesCategories")
                        .HasForeignKey("ExpensesId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.IncomeEntity.Income", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.CashAccount", "CashAccount")
                        .WithMany("Incomes")
                        .HasForeignKey("CashAccountId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.IncomeEntity.IncomeCategory", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.IncomeEntity.Income", "Income")
                        .WithMany("IncomeCategories")
                        .HasForeignKey("IncomeId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.TransferEntity.TransferFrom", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.CashAccount", "CashAccount")
                        .WithMany("TransfersFrom")
                        .HasForeignKey("CashAccountId");

                    b.HasOne("AuditingMoneyClient.Models.Entity.TransferEntity.Transfer", "Transfer")
                        .WithMany("TransfersFrom")
                        .HasForeignKey("TransferId");
                });

            modelBuilder.Entity("AuditingMoneyClient.Models.Entity.TransferEntity.TransferTo", b =>
                {
                    b.HasOne("AuditingMoneyClient.Models.Entity.CashAccount", "CashAccount")
                        .WithMany("TransfersTo")
                        .HasForeignKey("CashAccountId");

                    b.HasOne("AuditingMoneyClient.Models.Entity.TransferEntity.Transfer", "Transfer")
                        .WithMany("TransfersTo")
                        .HasForeignKey("TransferId");
                });
#pragma warning restore 612, 618
        }
    }
}
