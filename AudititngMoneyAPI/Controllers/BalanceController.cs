using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyCore.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudititngMoneyAPI.Controllers
{
    [Route("identity")]
    //[Authorize]
    public class BalanceController : ControllerBase
    {
       private readonly IBalanceRepository _balanceRepository;
       public  BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }
        public async Task<IActionResult> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            if (!_balanceRepository.Exists("2"))
            {

            }
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}