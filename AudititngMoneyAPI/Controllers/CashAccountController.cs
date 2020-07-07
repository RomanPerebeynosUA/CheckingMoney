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

namespace AudititngMoneyAPI.Controllers
{
   
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CashAccountController : ControllerBase
    {
     
        private readonly IBalanceRepository _balanceRepository;
        private readonly ICashAccountRepository _cashAccountRepository;
        private readonly IMapper _mapper;
        public CashAccountController(IBalanceRepository balanceRepository,
            ICashAccountRepository cashAccountRepository, IMapper mapper)
        {
            _balanceRepository = balanceRepository;
            _cashAccountRepository = cashAccountRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CashAccountJsonModel>> PostCash(CashAccountJsonModel cashJson)
        {
            if (cashJson == null)
            {
                return BadRequest();
            }
          // var cash = _mapper.Map<CashAccount>(cashJson);

     //     await _cashAccountRepository.Create(cash);
           
            return Ok(cashJson);
        }
    }
}