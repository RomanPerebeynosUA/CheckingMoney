using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.JsonModels;
using AuditingMoneyCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExpensesCategoryController : ControllerBase
    {
        private readonly IExpensesCategoryRepository _expensesCategoryRepository;

        public ExpensesCategoryController(IExpensesCategoryRepository  expensesCategoryRepository)
        {
            _expensesCategoryRepository = expensesCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expensesCategories = await _expensesCategoryRepository.GetListItems();

            if (expensesCategories == null)
            {
                return null;
            }
            else
            {
                return new JsonResult(expensesCategories);
            }
        }
    }
}