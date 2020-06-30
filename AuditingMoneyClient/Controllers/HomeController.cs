using System;
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

namespace AuditingMoneyClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IAPIResponse _responseToAPI;
        private readonly IEntityDeseralizeJson<BalanceJsonModel> _deseralizeBalanceJson;
        private readonly IConvertBalance _convert;

        public HomeController(
            ILogger<HomeController> logger, 
            IAPIResponse responseToAPI,
            IEntityDeseralizeJson<BalanceJsonModel> deseralizeBalanceJson,
            IConvertBalance convert)
        {
            _logger = logger;
            _responseToAPI = responseToAPI;
            _deseralizeBalanceJson = deseralizeBalanceJson;
            _convert = convert;
        }

        public async Task<IActionResult> Index()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            var content = await _responseToAPI.ConnectToAPI("https://localhost:44382/Balance/Get", accessToken);
              
            if (content == null)
            {
                return RedirectToAction("Logout", "Home");
            }
            else
            {
                return View(_convert.ConverListTo(_deseralizeBalanceJson.DeseralizeList(content)));
            }
           
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
