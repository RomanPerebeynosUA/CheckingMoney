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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingMoneyClient.Controllers
{
    public class IncomeController : Controller
    {
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IMapper _mapper;
        private static int CashAccount_Id; 

        public IncomeController(IMapper mapper, 
            IIncomeRepository incomeRepository,
            IIncomeCategoryRepository incomeCategoryRepository
            )
        {
            _incomeCategoryRepository = incomeCategoryRepository;
            _incomeRepository = incomeRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int Id)
        {
            if( Id == 0) Id = CashAccount_Id;
            else CashAccount_Id = Id;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var content = await _incomeRepository.GetIncome(
                "https://localhost:44382/Income/Get?id=" + Id.ToString(), accessToken);
            List<IncomeViewModel> incomeViewModels = new List<IncomeViewModel>();
            if (content == null)
            {         
                return View(incomeViewModels);
            }
            else
            {
                var incomes = _incomeRepository.DeseralizeIncomes(content);

               incomeViewModels = _mapper.Map<List<IncomeJsonModel>,
                    List<IncomeViewModel>>(incomes);

                return View(incomeViewModels);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _incomeCategoryRepository.GetIncCategory
                ("https://localhost:44382/IncomeCategory/Get", accessToken);

            var incomeViewModel = new IncomeViewModel();
            if (content == "Unauthorized")
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var incomeCategories = _incomeCategoryRepository.
                    DeseralizeIncCategories
                    (content);

                incomeViewModel.Categories =
                    from NameOfCategory in incomeCategories
                    select new SelectListItem
                    { Text = NameOfCategory.Name, Value = NameOfCategory.Name.ToString() };
                return View(incomeViewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(IncomeViewModel incomeViewModel)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                IncomeJsonModel income = _mapper.Map<IncomeViewModel,
                    IncomeJsonModel>(incomeViewModel);

                income.CashAccount_Id = CashAccount_Id;
                var result = await _incomeRepository.CreateIncome(
                    "https://localhost:44382/Income/Create", accessToken, income);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Income", income.CashAccount_Id);
                }
            }
            return View(incomeViewModel);
        }
    }
}