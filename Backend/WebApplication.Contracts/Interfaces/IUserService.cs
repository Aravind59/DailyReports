using System.Collections.Generic;
using DailyReports.Contracts.Models;

namespace DailyReports.Contracts.Interfaces
{
   public interface IUserService
   {
       UserDetails GetUserDetails(string userName, string password);

       int? RegisterUser(UserRegistration registration, LoggedInUser loggedInUser, List<ValidationMessage> validationMessages);
   }
}
