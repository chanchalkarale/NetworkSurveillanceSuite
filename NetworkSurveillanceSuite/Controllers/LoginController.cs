using Microsoft.AspNetCore.Mvc;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Login;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Registration;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetworkSurveillanceSuite.Controllers
{
    public class LoginController : BaseController
    {
        private readonly ILoginService _loginService;
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public LoginController(ILoginService loginService, ICurrentUserAccessor currentUserAccessor) : base(currentUserAccessor)
        {
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            _currentUserAccessor= currentUserAccessor ?? throw new ArgumentNullException(nameof(currentUserAccessor));
        }
        public IActionResult Index()
        {
            return View();
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
                var userId = await _loginService.Login(loginRequest, this.HttpContext);
                if (userId > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Register()
        {
            return View("~/Views/Registration/UserRegistration.cshtml");

        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegistrationRequest userRegistrationRequest)
        {
            var userId=await _loginService.UserRegistration(userRegistrationRequest);
            if(userId>0)
            { 
                return View("~/Views/Registration/GarageRegistration.cshtml");
            }
            return View("~/Views/Registration/UserRegistration.cshtml");

        }
    }
}
