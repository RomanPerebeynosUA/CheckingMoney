﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AuditingMoneyClient.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http;
using System.Net.Http.Headers;
using AuditingMoneyClient.Models.JsonModels;
using Newtonsoft.Json;
using AuditingMoneyClient.Core.Interfaces;
using AuditingMoneyClient.Models.Balance;
using AutoMapper;

namespace AuditingMoneyClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IBalanceRepository _balanceRepository;


        public HomeController(
            IMapper mapper,
            ILogger<HomeController> logger, 
            IBalanceRepository balanceRepository)        
        {
            _mapper = mapper;
            _logger = logger;
            _balanceRepository = balanceRepository;
        }

        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult Logout()
        {
            return SignOut("Cookie", "oidc");
        }

        [Authorize]
        public IActionResult Secret()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
