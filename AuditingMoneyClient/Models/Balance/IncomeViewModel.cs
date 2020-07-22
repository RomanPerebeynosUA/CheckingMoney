using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuditingMoneyClient.Models.Balance
{
    public class IncomeViewModel
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Category { get; set;}
        public DateTime Date { get; set; }

        public string Note { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }


    }
}
