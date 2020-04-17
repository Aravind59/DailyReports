using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReports.Contracts.Models
{
   public class LoggedInUser
    {
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Role { get; set; }
        public int? StationId { get; set; }
    }
}
