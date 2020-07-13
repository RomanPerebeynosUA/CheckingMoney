using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyAPI.Models.JsonModels;
using AuditingMoneyCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuditingMoneyAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly IMapper _mapper;
        private readonly IKindOfCurrencyRepository _kindOfCurrencyRepository;

        public  BalanceController(IBalanceRepository balanceRepository,
           IMapper mapper, IKindOfCurrencyRepository kindOfCurrencyRepository)
        {
            _balanceRepository = balanceRepository;
            _mapper = mapper;
            _kindOfCurrencyRepository = kindOfCurrencyRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user_id =  GetUser_ID();
            if (!_balanceRepository.ExistsByUserId(user_id))
            {
                return null;
            }
            else
            {
                var balances =  await _balanceRepository.GetListItems(user_id);
                return new JsonResult(balances); 
            }
        }
        [HttpPost]
        public async Task<ActionResult<BalanceJsonModel>> Create(BalanceJsonModel balanceJson)
        {
            if (balanceJson == null) 
            {
                return BadRequest();
            }
           var kindOfCurrency = await  _kindOfCurrencyRepository.GetItemByName(balanceJson.Name);

           var balance = _mapper.Map<BalanceJsonModel, Balance>(balanceJson);
           balance.UserId = GetUser_ID();
            balance.DateCreated = DateTime.Now;
           await _balanceRepository.Create(balance);

            await _balanceRepository.CreateComunication(
               await _balanceRepository.GetItemByDateCreated(balance.DateCreated), kindOfCurrency);

          return Ok();
        }

        private string GetUser_ID()
        {
            var user_id = User.Claims.FirstOrDefault(e => e.Type ==
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .Value.ToString();
            return user_id;
        }

    }
}