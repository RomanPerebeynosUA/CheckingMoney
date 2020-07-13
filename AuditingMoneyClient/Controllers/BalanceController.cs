using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingMoneyClient.Controllers
{
    public class BalanceController : Controller
    {
        private readonly IKindOfCurrencyRepository _kindOfCurrencyRepository;
        private readonly IMapper _mapper;
        private readonly IBalanceRepository _balanceRepository;

        
        public BalanceController(IMapper mapper, 
            IBalanceRepository balanceRepository,
            IKindOfCurrencyRepository kindOfCurrencyRepository)
        {
            _mapper = mapper;
            _balanceRepository = balanceRepository;
            _kindOfCurrencyRepository = kindOfCurrencyRepository;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _balanceRepository.GetBalance("https://localhost:44382/Balance/Get", accessToken);

            if (content == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var balast = _balanceRepository.DeseralizeBalances(content);
                List<BalanceViewModel> balanceViewModels = _mapper.
                    Map<List<BalanceJsonModel>, List<BalanceViewModel>>(balast);

                return View(balanceViewModels);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _kindOfCurrencyRepository.
                GetKindOfCurrency("https://localhost:44382/KindOfCurrency/Get", accessToken);
            var balanceViewModel = new BalanceViewModel();
            if (content == null)
            {   
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var kindOfCurrencies = _kindOfCurrencyRepository.DeseralizeKindOfCurrencies(content);
                //List<string> NameOfCurencies = new List<string>();
                //foreach(var c in kindOfCurrencies)
                //{
                //    NameOfCurencies.Add(c.Name);
                //}
                balanceViewModel.Currencies = from NameOfCurency in kindOfCurrencies
                                              select new SelectListItem { Text = NameOfCurency.Name, Value = NameOfCurency.Name.ToString() };

                return View(balanceViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BalanceViewModel balanceViewModel)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                BalanceJsonModel balanceJsonModel = _mapper.Map<BalanceViewModel, BalanceJsonModel>(balanceViewModel);
             
                var result = await _balanceRepository.CreateBalance
                    ("https://localhost:44382/Balance/Create", accessToken, balanceJsonModel);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(balanceViewModel);
        }


    }
}