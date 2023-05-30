using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.EntityFramework.Interfaces.Services
{
    public interface ICurrentUserAccessor
    {
        string UserId { get; }
        string ClientName { get; }
        string UserName { get; }
        string License { get; }
        string PeSession { get; }
        string Role { get; } 
    }
}
