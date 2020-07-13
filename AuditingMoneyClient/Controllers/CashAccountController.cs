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
       
        private readonly ICashAccountRepository _cashAccountRepository;
        private readonly IMapper _mapper;
        public CashAccountController(ICashAccountRepository cashAccountRepository,
            IMapper mapper)
        {
            _cashAccountRepository = cashAccountRepository;
            _mapper = mapper;         
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _cashAccountRepository.GetCashAccount("https://localhost:44382/CashAccount/Get", accessToken);

            if (content == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var cashAccounts = _cashAccountRepository.DeseralizeCashAccounts(content);
                List<CashAccountViewModel> CashAccountViewModels = _mapper.Map<List<CashAccountJsonModel>, List<CashAccountViewModel>>(cashAccounts);

                return View(CashAccountViewModels);
            }
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

                var result = await _cashAccountRepository.CreateCashAccount("https://localhost:44382/CashAccount/Create", accessToken, cashAccount);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                } 
            }
            return View(cashAccountViewModel);
        }
    }
}