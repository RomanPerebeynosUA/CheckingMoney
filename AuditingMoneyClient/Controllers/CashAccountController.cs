using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AuditingMoneyClient.Controllers
{
    public class CashAccountController : Controller
    {
       
        private readonly ICashAccountRepository _cashAccount;
        private readonly IMapper _mapper;
        public CashAccountController(ICashAccountRepository cashAccount,
            IMapper mapper)
        {
            _cashAccount = cashAccount;
            _mapper = mapper;         
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
        public async Task<IActionResult> Create(CashAccountViewModel cashAccountViewModel, int id)   
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                CashAccountJsonModel cashAccount = _mapper.Map <CashAccountViewModel, CashAccountJsonModel>(cashAccountViewModel);
                cashAccount.Balance_Id = id;

                var result = await _cashAccount.CreateCashAccount("https://localhost:44382/CashAccount/Create", accessToken, cashAccount);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(cashAccountViewModel);
        }
    }
}