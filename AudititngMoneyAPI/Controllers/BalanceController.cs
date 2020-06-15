using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoney.Entity.Domain.BalanceEntity;
using AuditingMoneyCore.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AudititngMoneyAPI.Controllers
{
    
    [Authorize]
    [Route("identity")]
    public class BalanceController : ControllerBase
    {
       private readonly IBalanceRepository _balanceRepository;
       public  BalanceController(IBalanceRepository balanceRepository)
        {
            _balanceRepository = balanceRepository;
        }
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var user_id = User.Claims.FirstOrDefault(e => e.Type == 
            "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                .Value.ToString();
         
            if (!_balanceRepository.ExistsByUserId(user_id))
            {
                await _balanceRepository.Create(new Balance { Amount = 0, UserId = user_id });
                return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
            }
            else
            {
                var balance =  await _balanceRepository.GetItemByUserId(user_id);
                return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
                // return RedirectToAction(nameof(Index));
            }
        }     
    }
}