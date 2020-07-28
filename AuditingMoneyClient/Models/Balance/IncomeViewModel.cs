using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class IncomeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Кількість")]
        public double Amount { get; set; }
        [Display(Name = "Вид доходу")]
        public string Category { get; set;}
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }
        [Display(Name = "Опис")]
        public string Note { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public int CashAccount_Id { get; set; }


    }
}
