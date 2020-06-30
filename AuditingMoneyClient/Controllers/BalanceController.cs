using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyClient.Controllers
{
    public class BalanceController : Controller
    {
        public ActionResult Index()
        {
            List<BalanceJsonModel> balances = new List<BalanceJsonModel>();
         var balancesViews = new List<BalanceViewModel>();

            foreach (BalanceJsonModel b in balances)
            {
                balancesViews.Add(new BalanceViewModel
                {
                    Amount = b.Amount,
                    Name = "грн",
                 
                }) ;
            }

            return View(balancesViews);
        }

        public IActionResult Create()
        {
            return View();
        }

    }
}