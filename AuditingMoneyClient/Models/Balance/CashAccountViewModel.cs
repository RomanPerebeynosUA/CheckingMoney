using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class CashAccountViewModel
    {
        //    public int Id { get; set; }

        [Display(Name = "Рахунок")]
        public string Name { get; set; }
        [Display(Name = "Кількість")]
        public double Amount { get; set; }
        [Display(Name = "Валюта")]
        public string Currency { get; set; }
        [Display(Name = "Опис")]
        public string Note { get; set; }

        public int Balance_Id { get; set; }     

    }
}
