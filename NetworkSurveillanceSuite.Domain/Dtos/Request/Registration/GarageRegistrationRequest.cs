using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.Domain.Dtos.Request.Registration
{
    public class GarageRegistrationRequest
    {
        public string GarageName { get; set; }

        public string OwnerName { get; set; } 

        public int OwnerAge { get; set; }

        public string Location_latitude { get; set; }

        public string Locaation_longitude { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int DeleteFlag { get; set; }

        public int UserRegistrationId { get; set; }

        
    }
}
