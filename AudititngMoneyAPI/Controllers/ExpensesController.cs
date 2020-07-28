using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AuditingMoney.Entity.Domain;
using AuditingMoney.Entity.Domain.ExpensesEntity;
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
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesCategoryRepository  _expensesCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IExpensesRepository _expensesRepository;

        public ExpensesController(IExpensesRepository expensesRepository,
           IMapper mapper, IExpensesCategoryRepository expensesCategoryRepository)
        {
            _expensesRepository = expensesRepository;
            _mapper = mapper;
            _expensesCategoryRepository = expensesCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            if (!_expensesRepository.ExistsByCashAccountId(id))
            {
                return null;
            }
            else
            {
                var expenses = _expensesRepository.GetExpensesForView(id);
                return new JsonResult(expenses);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(ExpensesJsonModel expensesJson)
        {
            if (expensesJson == null)
            {
                return BadRequest();
            }
            var expensesCategory = await _expensesCategoryRepository.GetItemByName(expensesJson.Category);

            var expenses = _mapper.Map<ExpensesJsonModel, Expenses>(expensesJson);
            expenses.Date = DateTime.Now;

            await _expensesRepository.Create(expenses, expensesJson.CashAccount_Id);

            await _expensesRepository.CreateComunication(
               await _expensesRepository.GetItemByDate(expenses.Date), expensesCategory);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(ExpensesJsonModel expensesJson)
        {
            if (expensesJson == null)
            {
                return BadRequest();
            }
            if (!_expensesRepository.Exists(expensesJson.Id))
            {
                return NotFound();
            }
            var expenses = _mapper.Map<ExpensesJsonModel, Expenses>(expensesJson);
            await _expensesRepository.Update(expenses);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Expenses expenses = await _expensesRepository.GetItem(id);
            if (expenses == null)
            {
                return NotFound();
            }
            await _expensesRepository.Remove(expenses);
            return Ok();
        }
    }
}