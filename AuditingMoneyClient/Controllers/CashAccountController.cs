﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AuditingMoneyClient.Models.Statistics;
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

        public async Task<IActionResult> Index(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _cashAccountRepository.GetCashAccount(
                "https://localhost:44382/CashAccount/Get?id=" + Id.ToString(), accessToken);

            if (content == null)
            {
                return RedirectToAction("Index", "Balance");
            }
            else
            {
                var cashAccounts = _cashAccountRepository.DeseralizeCashAccounts(content);

                List<CashAccountViewModel> CashAccountViewModels = _mapper.Map<List<CashAccountJsonModel>,
                    List<CashAccountViewModel>>(cashAccounts);

                return View(CashAccountViewModels);
            }
        }
        public async Task<IActionResult> History(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _cashAccountRepository.GetCashAccount(
                "https://localhost:44382/CashAccount/GetAccountHistory?id=" + Id.ToString(), accessToken);

            List<CashAccountHistoryViewModel> historyView = new List<CashAccountHistoryViewModel>();
            if (content == null)
            {
                return View(historyView);
            }
            else
            {
                var cashAccountHistory = _cashAccountRepository.DeseralizeCashAccountHistory(content);

                historyView = _mapper.Map<List<CashAccountHistory>,
                    List<CashAccountHistoryViewModel>>(cashAccountHistory);

                return View(historyView);
            }
        } 
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CashAccountViewModel cashAccountViewModel, int Id)   
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                CashAccountJsonModel cashAccount = _mapper.Map <CashAccountViewModel, 
                    CashAccountJsonModel>(cashAccountViewModel);

                cashAccount.BalanceId = Id;
                cashAccount.Id = 0; 

                var result = await _cashAccountRepository.CreateCashAccount(
                    "https://localhost:44382/CashAccount/Create", accessToken, cashAccount);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Balance");
                } 
            }
            return View(cashAccountViewModel);
        }
    }
}