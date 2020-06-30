using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudititngMoneyAPI.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index(string user_id)
        {
            ViewBag.UserId = user_id;
            return View();
        }
    }
}