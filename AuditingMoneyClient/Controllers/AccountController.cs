using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuditingMoneyClient.Controllers
{

    public class AccountController : Controller
    {
        public IActionResult IdentityPage()
        {          
            return View();
        }
        public IActionResult CallApi()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        // var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44382/Balance/Get");
        // await client.SendAsync(request); // відправка повідомлення

        //var content =  await client.GetStringAsync("https://localhost:44382/Balance/Get");

    }
}