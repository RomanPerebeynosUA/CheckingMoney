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
    public class CashAccountController : ControllerBase
    {
     
        private readonly IBalanceRepository _balanceRepository;
        private readonly ICashAccountRepository _cashAccountRepository;
        private readonly IMapper _mapper;

        public CashAccountController(
            ICashAccountRepository cashAccountRepository, 
            IMapper mapper, IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
            _cashAccountRepository = cashAccountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {         
            if (!_cashAccountRepository.ExistsByBalanceId(id))
            {
                return null;
            }         
            else
            {
                //  var cashAccounts = await _cashAccountRepository.GetListItems(id);
                var cashAccounts = _cashAccountRepository.GetCashAccountsForView(id);
                return new JsonResult(cashAccounts);
            }
        }
        [HttpGet]
        public IActionResult GetAccountHistory(int id)
        {
            if (!_cashAccountRepository.Exists(id))
            {
                return null;
            }
            else
            {
                var history = _cashAccountRepository.GetCashAccountHistory(id);
                return new JsonResult(history);
            }
        }
        [HttpGet]
        public IActionResult GetNames(int id)
        {
            if (!_cashAccountRepository.Exists(id))
            {
                return null;
            }
            else
            {
                var cashAccounts = _cashAccountRepository.GetCashAccountNames(id);
                return new JsonResult(cashAccounts);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CashAccountJsonModel>> Create(CashAccountJsonModel cashJson)
        {
            if (cashJson == null)
            {     
                return BadRequest();            
            }
            
            var cash = _mapper.Map<CashAccountJsonModel, CashAccount>(cashJson);
            var balance =  await _balanceRepository.GetItem(cashJson.BalanceId);
            cash.Balance = balance;
            await _cashAccountRepository.Create(cash);
           
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult<CashAccountJsonModel>> Update(CashAccountJsonModel cashAccountJson)
        {
            if (cashAccountJson == null)
            {
                return BadRequest();
            }
            if (!_cashAccountRepository.Exists(cashAccountJson.Id))
            {
                return NotFound();
            }
            var cashAccount = _mapper.Map<CashAccountJsonModel, CashAccount>(cashAccountJson);
            await _cashAccountRepository.Update(cashAccount);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            CashAccount cashAccount = await _cashAccountRepository.GetItem(id);
            if (cashAccount == null)
            {
                return NotFound();
            }
            await _cashAccountRepository.Remove(cashAccount);
            return Ok();
        }
    }
}