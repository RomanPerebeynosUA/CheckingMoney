using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyClient.Controllers
{
    public class KindOfCurrencyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}