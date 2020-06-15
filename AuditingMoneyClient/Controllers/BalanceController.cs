using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Models.Balance;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyClient.Controllers
{
    public class BalanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Name, Amount, Note, Currency")] CashAccountViewModel CashAccount)
        {
            if (ModelState.IsValid)
            {

                //  await dataManager.CountryRepository.SaveEntity(country);
                return RedirectToAction(nameof(Index));
            }
            // return View(country);
            return View();
        }
    }
}