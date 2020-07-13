using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class BalanceViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Кількість")]
        public double Amount { get; set; }

        [Display(Name = "Валюта")]
        public string Name { get; set; }

        public IEnumerable<SelectListItem> Currencies { get; set; }
    }
}
