using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoney.Entity.Domain.ExpensesEntity;
using AuditingMoney.Entity.Domain.IncomeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyCore.Data
{
    public class ConfigDatabase
    {
        public static void Initilize(AudDbContext context)
        {
            if (!context.IncomeCategories.Any())
            {
                List<IncomeCategory> incomeCategories = new List<IncomeCategory>()
                {
                   
                    new IncomeCategory{ Name = "Різне"},
                    new IncomeCategory{ Name = "Зарплата"},
                    new IncomeCategory{ Name = "Подарунок"},
                }; 
                foreach (var e  in incomeCategories)
                {
                    context.IncomeCategories.Add(e);
                }
                context.SaveChanges();
            }

            if (!context.ExpensesCategories.Any())
            {
                List<ExpensesCategory> expensesCategories = new List<ExpensesCategory>()
                {
                    new ExpensesCategory {  Name = "Покупки" },
                        new ExpensesCategory { Name = "Харчування" },
                        new ExpensesCategory {  Name = "Транспорт" },
                        new ExpensesCategory {  Name = "Транспорт" },
                        new ExpensesCategory {  Name = "Різне" },
                };
                foreach (var e in expensesCategories)
                {
                    context.ExpensesCategories.Add(e);
                }
                context.SaveChanges();
            }
            if (!context.KindOfCurrencies.Any())
            {
                List<KindOfCurrency> kindOfCurrencies = new List<KindOfCurrency>()
                {
                    new KindOfCurrency{  Name = "грн."},
                    new KindOfCurrency{  Name = "дол."},
                    new KindOfCurrency{  Name = "євро"},
                    new KindOfCurrency{  Name = "руб"},
                };
                foreach (var e in kindOfCurrencies)
                {
                    context.KindOfCurrencies.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}
