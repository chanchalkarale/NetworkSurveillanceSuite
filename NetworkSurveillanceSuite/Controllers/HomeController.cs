using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Login;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using NetworkSurveillanceSuite.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkSurveillanceSuite.Controllers
{
     
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginService _loginService;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public HomeController(ILogger<HomeController> logger, ILoginService loginService, ICurrentUserAccessor currentUserAccessor):base(currentUserAccessor)
        {
            _logger = logger;
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _currentUserAccessor = currentUserAccessor;
        } 

        public async Task<IActionResult> Index()
        {
            var userid = _currentUserAccessor.UserId;
            int val= await _loginService.GetTestData();
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

        [HttpPost]
        public async Task<IActionResult> Index(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                return View();
            }

            if (!string.IsNullOrWhiteSpace(loginRequest.Username) && !string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
