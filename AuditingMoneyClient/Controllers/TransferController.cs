using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Core.Interfaces.Transfers;
using AuditingMoneyClient.Models.Balance;
using AuditingMoneyClient.Models.JsonModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuditingMoneyClient.Controllers
{
    public class TransferController : Controller
    {
        private readonly ICashAccountRepository _cashAccountRepository;
        private readonly ITransferRepository  _transferRepository;    
        private readonly IMapper _mapper;

        private static int CashAccount_Id;

        public TransferController(IMapper mapper,
            ICashAccountRepository cashAccountRepository,
            ITransferRepository transferRepository)          
        {
            _mapper = mapper;
            _cashAccountRepository = cashAccountRepository;
            _transferRepository = transferRepository;       
           
        }

        public async Task<IActionResult> Index(int Id)
        {
            if (Id == 0) Id = CashAccount_Id;
            else CashAccount_Id = Id;

            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _transferRepository.Get(
                "https://localhost:44382/Transfer/Get?id=" + Id.ToString(), accessToken);
            
                return View(content); 
        }

        [HttpGet]
        public async Task<IActionResult> Create(int Id)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _cashAccountRepository.GetNames(
             "https://localhost:44382/CashAccount/GetNames?id=" + Id.ToString(), accessToken);

            var transferView = new TransferViewModel();

            if (content == null)
            {
                return RedirectToAction("Index", "CashAccount");
            }
            else
            {

                transferView.Accounts =
                    from NameOfAccount in content
                    select new SelectListItem
                    { Text = NameOfAccount.Name, Value = NameOfAccount.Name.ToString() };

                return View(transferView);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(TransferViewModel transferViewModel)
        {
            if (ModelState.IsValid)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");

                TransferJsonModel transfer = _mapper.Map<TransferViewModel,
                    TransferJsonModel>(transferViewModel);

                var result = await _transferRepository.CreateTransfer(
                    "https://localhost:44382/Income/Create", accessToken, transfer);

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Income");
                }
            }
            return View(transferViewModel);
        }
    }
}