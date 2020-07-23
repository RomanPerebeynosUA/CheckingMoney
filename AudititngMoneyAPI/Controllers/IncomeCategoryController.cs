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
    public class IncomeCategoryController : ControllerBase
    {
        private readonly IIncomeCategoryRepository _incomeCategoryRepository;

        public IncomeCategoryController(IIncomeCategoryRepository incomeCategoryRepository)
        {
            _incomeCategoryRepository = incomeCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var incomeCategories = await _incomeCategoryRepository.GetListItems();

            if (incomeCategories == null)
            {
                return null;
            }
            else
            {
                return new JsonResult(incomeCategories );
            }
        }
    }
}
