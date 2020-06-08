using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AuditingMoneyClient.Controllers
{

    public class AccountController : Controller
    {
        public async Task<IActionResult> IdentityPage()
        {
            //var accessToken = await HttpContext.GetTokenAsync("access_token");

            //var client = new HttpClient();
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            //var content = await client.GetStringAsync("https://localhost:44382/identity");

            //ViewBag.Json = JArray.Parse(content).ToString();
            return View();
        }
        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("https://localhost:44382/identity");

            //ViewBag.Json = JArray.Parse(content).ToString();
            ViewBag.Json = JObject.Parse(content).ToString();
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}




    }
}