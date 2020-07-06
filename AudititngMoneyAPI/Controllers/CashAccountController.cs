using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
//using System.Web.Http;
using AuditingMoney.Entity.Domain;
using AuditingMoneyCore.Interfaces;
using AudititngMoneyAPI.Models.Balance;
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
        public CashAccountController(IBalanceRepository balanceRepository,
            ICashAccountRepository cashAccountRepository)
        {
            _balanceRepository = balanceRepository;
            _cashAccountRepository = cashAccountRepository;
        }

        //[HttpPost]
        //public async Task<IHttpActionResult> Create(CashAccountViewModel model)
        //{

        //    if (!ModelState.IsValid)
        //        return BadRequest("Not a valid data");


        //    return Ok();

        // }
        [HttpPost]
        public async Task<ActionResult<CashAccountViewModel>> PostCash(CashAccountViewModel cash)
        {
            if (cash == null)
            {
                return BadRequest();
            }

        //   await _cashAccountRepository.Create(cash);
           
            return Ok(cash);
        }
    }
}