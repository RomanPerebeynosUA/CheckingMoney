using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
//using System.Web.Http;
using AuditingMoney.Entity.Domain;
using AuditingMoneyAPI.Models.JsonModels;
using AuditingMoneyCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace AuditingMoneyAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KindOfCurrencyController : ControllerBase
    {
        private IKindOfCurrencyRepository _kindOfCurrencyRepository;

        public KindOfCurrencyController(IKindOfCurrencyRepository kindOfCurrencyRepository)
        {
            _kindOfCurrencyRepository = kindOfCurrencyRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (_kindOfCurrencyRepository.GetListItems() == null)
            {
                return null;
            }
            else
            {
                var kindOfCurrencies = await _kindOfCurrencyRepository.GetListItems();
                return new JsonResult(kindOfCurrencies);
            }
        }
    }
}