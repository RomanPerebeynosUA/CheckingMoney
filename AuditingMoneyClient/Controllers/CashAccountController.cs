using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditingMoneyClient.Controllers
{
    public class CashAccountController : Controller
    {
        private readonly HttpClient _client;
        private readonly IConvertCashAccount _convert;
        public CashAccountController(IConvertCashAccount convert)
        {

            _convert = convert;
        }

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
        public async Task<IActionResult> Create(CashAccountViewModel cashAccountViewModel, int balanceid)
        {
            if (ModelState.IsValid)
            {
              CashAccountJsonModel cashAccount = _convert.ConvertTo(cashAccountViewModel, balanceid);

                var accessToken = await HttpContext.GetTokenAsync("access_token");
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var content = new StringContent(JsonConvert.SerializeObject(cashAccount));

                HttpResponseMessage response = await _client.PostAsync("https://localhost:44382/CashAccount/Create", content);
                response.EnsureSuccessStatusCode();

                return RedirectToAction(nameof(Index));
            }
            return View(cashAccountViewModel);
        }
    }
}