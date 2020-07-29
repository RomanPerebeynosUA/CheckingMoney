using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class TransferViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Кількість")]
        public double Amount { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Опис")]
        public string Note { get; set; }

        public IEnumerable<SelectListItem> Accounts { get; set; }
    }
}
