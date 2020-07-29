using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Statistics
{
    public class CashAccountHistoryViewModel
    {
        [Display(Name = "Знак")]
        public string Icon { get; set; }
        [Display(Name = "Кількість")]
        public double Amount { get; set; }
        [Display(Name = "Категорія")]
        public string Category { get; set; }
        [Display(Name = "Опис")]
        public string Note { get; set; }
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        public bool Change { get; set; }
    }
}
