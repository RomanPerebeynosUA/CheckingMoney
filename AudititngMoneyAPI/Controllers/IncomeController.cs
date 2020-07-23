using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using AuditingMoney.Entity.Domain.IncomeEntity;
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
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;
        private readonly IMapper _mapper;
        private readonly IIncomeRepository _incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository,
           IMapper mapper, IIncomeCategoryRepository incomeCategoryRepository)
        {
            _incomeRepository = incomeRepository;
            _mapper = mapper;
            _incomeCategoryRepository = incomeCategoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!_incomeRepository.ExistsByCashAccountId(id))
            {
                return null;
            }
            else
            {
                var incomes = await _incomeRepository.GetListItems(id);
                return new JsonResult(incomes);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(IncomeJsonModel incomeJson)
        {
            if (incomeJson == null)
            {
                return BadRequest();
            }

            var incomeCategory = await _incomeCategoryRepository.GetItemByName(incomeJson.Category);

            var income = _mapper.Map<IncomeJsonModel, Income>(incomeJson);

            await _incomeRepository.Create(income);

            await _incomeRepository.CreateComunication(
               await _incomeRepository.GetItemByDate(income.Date), incomeCategory);

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(IncomeJsonModel incomeJson)
        {
            if (incomeJson == null)
            {
                return BadRequest();
            }
            if (!_incomeRepository.Exists(incomeJson.Id))
            {
                return NotFound();
            }
            var income = _mapper.Map<IncomeJsonModel, Income>(incomeJson);
            await _incomeRepository.Update(income);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Income income = await _incomeRepository.GetItem(id);
            if (income == null)
            {
                return NotFound();
            }
            await _incomeRepository.Remove(income);
            return Ok();
        }
    }
}