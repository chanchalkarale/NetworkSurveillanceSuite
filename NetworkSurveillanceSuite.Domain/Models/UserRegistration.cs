using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkSurveillanceSuite.Domain.Models
{
    public class UserRegistration:Entity
    {
        public string ClientName { get; set; }
        public string EmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int DeleteFlag { get; set; } 
        public int AdminFlag { get; set; }
    }
}
