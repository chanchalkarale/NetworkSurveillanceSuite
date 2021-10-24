using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetworkSurveillanceSuite.EntityFramework.Interfaces.Services
{
    public interface ILoginService
    {
        public Task<int> GetTestData();
    }
}
