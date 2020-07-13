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
        public  BalanceController(IBalanceRepository balanceRepository,
           IMapper mapper)
        {
            _balanceRepository = balanceRepository;
            _mapper = mapper;
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
        public async Task<ActionResult<BalanceJsonModel>> Create(BalanceJsonModel balnceJson)
        {
            if (balnceJson == null) 
            {
                return BadRequest();
            }

           var balance = _mapper.Map<BalanceJsonModel, Balance>(balnceJson);
           balance.UserId = GetUser_ID();
           await _balanceRepository.Create(balance);

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