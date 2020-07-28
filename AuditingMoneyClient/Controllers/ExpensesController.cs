using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces.Expenses;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingMoneyClient.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesCategoryRepository _expensesCategoryRepository;
        private readonly IExpensesRepository _expensesRepository;
        private readonly IMapper _mapper;
        private static int CashAccount_Id;

        public ExpensesController(IMapper mapper,
            IExpensesRepository expensesRepository,
            IExpensesCategoryRepository expensesCategoryRepository
            )
        {
            _expensesCategoryRepository = expensesCategoryRepository;
            _expensesRepository = expensesRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int Id)
        {
            if (Id == 0) Id = CashAccount_Id;
            else CashAccount_Id = Id;

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var content = await _expensesRepository.GetExpenses(
                "https://localhost:44382/Expenses/Get?id=" + Id.ToString(), accessToken);

            List<ExpensesViewModel> expensesViewModels = new List<ExpensesViewModel>();
            if (content == null)
            {
                return View(expensesViewModels);
            }
            else
            {
                var expenses = _expensesRepository.DeseralizeExpenses(content);

                expensesViewModels = _mapper.Map<List<ExpensesJsonModel>,
                     List<ExpensesViewModel>>(expenses);

                return View(expensesViewModels);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _expensesCategoryRepository.GetExpCategory
                ("https://localhost:44382/ExpensesCategory/Get", accessToken);

            var expensesViewModel = new ExpensesViewModel();

            if (content == "Unauthorized")
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                var expensesCategories = _expensesCategoryRepository.
                    DeseralizeExpCategories(content);

                expensesViewModel.Categories =
                    from NameOfCategory in expensesCategories
                    select new SelectListItem
                    { Text = NameOfCategory.Name, Value = NameOfCategory.Name.ToString() };
                return View(expensesViewModel);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(ExpensesViewModel expensesViewModel)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                ExpensesJsonModel expense = _mapper.Map<ExpensesViewModel,
                    ExpensesJsonModel>(expensesViewModel);

                expense.CashAccount_Id = CashAccount_Id;
                var result = await _expensesRepository.CreateExpens(
                    "https://localhost:44382/Expenses/Create", accessToken, expense);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Expenses");
                }
            }
            return View(expensesViewModel);
        }
    }
}