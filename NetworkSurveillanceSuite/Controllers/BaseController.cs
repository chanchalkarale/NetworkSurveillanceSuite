using Microsoft.AspNetCore.Mvc;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using System;

namespace NetworkSurveillanceSuite.Controllers
{
    public class BaseController : Controller
    {
        private readonly ICurrentUserAccessor _currentUserAccessor;

        public BaseController()
        {

        }

        public BaseController(ICurrentUserAccessor currentUserAccessor)
        {
            _currentUserAccessor = currentUserAccessor ?? throw new ArgumentNullException(nameof(currentUserAccessor));
        }
    }
}
