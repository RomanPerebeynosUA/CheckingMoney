using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyClient.Controllers
{
    public class AccountController : Controller
    {
        [Authorize]
        public IActionResult IdentityPage()
        {
            return View();
        }

    }
}