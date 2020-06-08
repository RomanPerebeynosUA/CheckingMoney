using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AudititngMoneyAPI.Controllers
{
    public class CashAccountController : Controller
    {
        private readonly IBalanceRepository _balanceRepository;
        private readonly ICashAccountRepository _cashAccountRepository;
        public CashAccountController(IBalanceRepository balanceRepository,
            ICashAccountRepository cashAccountRepository)
        {
            _balanceRepository = balanceRepository;
            _cashAccountRepository = cashAccountRepository;
        }


        public IActionResult Index()
        {
            return View();
        }


    }
}