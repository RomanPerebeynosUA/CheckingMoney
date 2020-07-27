using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces.Incomes;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyClient.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;

        public IncomeController(IMapper mapper, IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _incomeRepository.GetIncome(
                "https://localhost:44382/CashAccount/Get?id=" + Id.ToString(), accessToken);

            if (content == null)
            {
                return RedirectToAction("Index", "Balance");
            }
            else
            {
                var incomes = _incomeRepository.DeseralizeIncomes(content);

                List<IncomeViewModel> incomeViewModels = _mapper.Map<List<IncomeJsonModel>,
                    List<IncomeViewModel>>(incomes);

                return View(incomeViewModels);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IncomeViewModel incomeViewModels, int Id)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                IncomeJsonModel income = _mapper.Map<IncomeViewModel,
                    IncomeJsonModel>(incomeViewModels);
              //  income.BalanceId = Id;

                var result = await _incomeRepository.CreateIncome(
                    "https://localhost:44382/CashAccount/Create", accessToken, income);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Income");
                }
            }
            return View(incomeViewModels);
        }


    }
}