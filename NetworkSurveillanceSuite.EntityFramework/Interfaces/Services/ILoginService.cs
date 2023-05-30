using Microsoft.AspNetCore.Http;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Login;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Registration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSurveillanceSuite.EntityFramework.Interfaces.Services
{
    public interface ILoginService
    {
        public Task<int> GetTestData();

        Task<int> Login(LoginRequest loginRequest,HttpContext httpContext);

        Task<int> UserRegistration(UserRegistrationRequest userRegistrationRequest);
    }
}
