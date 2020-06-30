using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AuditingMoney.Entity.Domain;
using AuditingMoneyCore.Interfaces;
using AudititngMoneyAPI.Models.Balance;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudititngMoneyAPI.Controllers
{
    [System.Web.Http.Authorize]
    public class CashAccountController : ControllerBase
    {
        private readonly HttpClient _client;
        private readonly IBalanceRepository _balanceRepository;
        private readonly ICashAccountRepository _cashAccountRepository;
        public CashAccountController(IBalanceRepository balanceRepository,
            ICashAccountRepository cashAccountRepository)
        {
            _balanceRepository = balanceRepository;
            _cashAccountRepository = cashAccountRepository;
        }

        //[System.Web.Http.HttpPost]
        //public async Task<IHttpActionResult> Create()
        //{
            
        //    if (ModelState.IsValid)
        //    {
                
        //    }
        //    return Ok();
          
        //}
    }
}