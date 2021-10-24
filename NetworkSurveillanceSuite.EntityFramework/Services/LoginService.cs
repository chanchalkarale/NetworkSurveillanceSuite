using Microsoft.EntityFrameworkCore;
using NetworkSurveillanceSuite.EntityFramework.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
