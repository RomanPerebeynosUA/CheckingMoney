using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
//using System.Web.Http;
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
        public CashAccountController(IBalanceRepository balanceRepository,
            ICashAccountRepository cashAccountRepository, IMapper mapper)
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
                var cashAccounts = await _cashAccountRepository.GetListItems(id);

                //List<CashAccountJsonModel> cashAccountJsonModels = _mapper.Map<List<CashAccountJsonModel>,
                //   List<CashAccount>>(cashAccounts);

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
    }
}