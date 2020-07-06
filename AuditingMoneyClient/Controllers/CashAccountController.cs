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
        private readonly IAPIResponse<CashAccountJsonModel> _apiResponse;
        private readonly IConvertCashAccount _convert;
        public CashAccountController(IConvertCashAccount convert, IAPIResponse<CashAccountJsonModel> apiResponse)
        {

            _convert = convert;
            _apiResponse = apiResponse;
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
        public async Task<IActionResult> Create(CashAccountViewModel cashAccountViewModel)
            //int balanceid)
        {
            if (ModelState.IsValid)
            {
              CashAccountJsonModel cashAccount = _convert.ConvertTo(cashAccountViewModel, 1);
                var accessToken = await HttpContext.GetTokenAsync("access_token");
              //  var content = new StringContent(JsonConvert.SerializeObject(cashAccount));

                //var result = await _apiResponse.SendContentToAPI("https://localhost:44382/CreateCash", accessToken, content);

                var result = await _apiResponse.SendObjToAPI("https://localhost:44382/CashAccount/PostCash", accessToken, cashAccount);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(cashAccountViewModel);
        }
    }
}