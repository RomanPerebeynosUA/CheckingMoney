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

        [Display(Name = "Переказ в акаунт")]
        public string Name { get; set; }

        [Display(Name = "Переказ з акаунта")]
        public string NameFrom { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        [Display(Name = "Опис")]
        public string Note { get; set; }

        public IEnumerable<SelectListItem> Accounts { get; set; }

        public int CashAccountFrom_Id { get; set; }

        public int CashAccountTo_Id { get; set; }

    }
}
