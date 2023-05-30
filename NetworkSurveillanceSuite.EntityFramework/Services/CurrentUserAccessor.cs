using Microsoft.AspNetCore.Http;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework.Services
{
    public class CurrentUserAccessor : ICurrentUserAccessor
    {
        #region Properties

        public string UserId { get; }
        public string ClientName { get; }
        public string UserName { get; }
        public string License { get; }
        public string PeSession { get; }
        public string Role { get; } 

        #endregion

        #region Constants

       // private const string ClaimTypeName = "name";

        #endregion

        #region Constructor

        public CurrentUserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            if (httpContextAccessor.HttpContext != null)
            { 
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                var clientName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name);
                var userName = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Actor);
                var license = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.SerialNumber);
                var pesession = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.PostalCode);
                var role = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role); 

                
                ClientName = clientName?.Value;
                UserId = userId?.Value;
                UserName = userName?.Value;
                License = license?.Value;
                PeSession = pesession?.Value;
                Role = role?.Value; 
            }
        }

        #endregion
    }
}
