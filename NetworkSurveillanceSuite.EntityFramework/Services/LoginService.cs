using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Login;
using NetworkSurveillanceSuite.Domain.Dtos.Request.Registration;
using NetworkSurveillanceSuite.Domain.Models;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSurveillanceSuite.EntityFramework.Services
{
    public class LoginService : ILoginService
    {
        #region Field
        private readonly NetworkSurveillanceSuiteContext _dbcontext;

        #endregion

        #region Constructor
        public LoginService(NetworkSurveillanceSuiteContext dbcontext)
        {
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        #endregion

        public async Task<int> GetTestData()
        {
            var offlineRegResult = 0;
            try
            {
                 offlineRegResult = await _dbcontext.OnlineLocalTables.Select(s => s.OnlineLocalStatus).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            { 
            
            }
            return offlineRegResult;
        }

        public async Task<int> Login(LoginRequest loginRequest,HttpContext httpContext)
        {
             
            var userRegistrationDetails=await _dbcontext.UserRegistrations.Where(d=>d.UserName==loginRequest.Username &&
            d.Password==loginRequest.Password).FirstOrDefaultAsync();
            ClaimsIdentity identity = new ClaimsIdentity(
                           this.GetUserClaims(userRegistrationDetails),
                           CookieAuthenticationDefaults.AuthenticationScheme
                       );
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return userRegistrationDetails.Id; 
        }

        public async Task<int> UserRegistration(UserRegistrationRequest userRegistrationRequest)
        {
            UserRegistration userRegistration = new UserRegistration()
            {
                ClientName = userRegistrationRequest.ClientName,
                EmailId = userRegistrationRequest.EmailId,
                UserName = userRegistrationRequest.UserName,
                Password = userRegistrationRequest.Password,
                InsertDate = DateTime.Now,
                AdminFlag = 0,
                DeleteFlag = 0
            };

            var userId = await _dbcontext.UserRegistrations.AddAsync(userRegistration);
            await _dbcontext.SaveChangesAsync();
            ClaimsIdentity identity = new ClaimsIdentity(
                           this.GetUserClaims(userId.Entity),
                           CookieAuthenticationDefaults.AuthenticationScheme
                       );
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);
            return userId.Entity.Id;
        }

        #region Private Methods
        private IEnumerable<Claim> GetUserClaims(UserRegistration user)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() ?? "0"));
            claims.Add(new Claim(ClaimTypes.Name, user.ClientName ?? ""));
            claims.Add(new Claim(ClaimTypes.Email, user.EmailId ?? ""));
            //claims.Add(new Claim(ClaimTypes.Uri, value: user.CompanyLogo ?? ""));
            claims.Add(new Claim(ClaimTypes.Actor, value: user.UserName ?? ""));
            //claims.Add(new Claim(ClaimTypes.SerialNumber, value: user.LicenseKey ?? ""));
            //claims.Add(new Claim(ClaimTypes.PostalCode, peSession));
            claims.Add(new Claim(ClaimTypes.Role, user.AdminFlag==0?"User":"Admin"));
            claims.Add(new Claim(ClaimTypes.Surname, "Company"));
            return claims;
        }
        #endregion
    }
}
