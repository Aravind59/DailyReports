using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReports.Contracts.Models
{
   public class UserRegistration
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string StationName { get; set; }
        public string StationCode { get; set; }
        public bool IsAdmin { get; set; }

    }
}
