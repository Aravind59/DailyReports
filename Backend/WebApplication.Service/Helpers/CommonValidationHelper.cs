using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyReports.Contracts.Models;

namespace DailyReports.Service.Helpers
{
   public static class CommonValidationHelper
    {
        public static bool ValidateLoggedInUser(LoggedInUser loggedInUser, List<ValidationMessage> validationMessages)
        {
            if (loggedInUser == null)
            {
                loggedInUser = new LoggedInUser();
            }

            if (loggedInUser.UserId == null)
            {
                //LoggingManager.Debug(string.Format(LoggingManagerAppConstants.LoggingManagerInfoValue, "validate LoggedInUserId", "Common Validation Helper") + "LoggedIn User Id :" + loggedInContext.LoggedInUserId);

                validationMessages.Add(new ValidationMessage
                {
                    ValidationMessageType = MessageTypeEnum.Error,
                    ValidationMessaage = "This user account is not exist"
                });
            }

            //if (loggedInUser.Role == null)
            //{
            //    //LoggingManager.Debug(string.Format(LoggingManagerAppConstants.LoggingManagerInfoValue, "validate CompanyId", "Common Validation Helper") + "Company Id : " + loggedInContext.CompanyGuid);

            //    validationMessages.Add(new ValidationMessage
            //    {
            //        ValidationMessageType = MessageTypeEnum.Error,
            //        ValidationMessaage = ValidationMessages.NotEmptyCompanyId
            //    });
            //}

            return validationMessages.Count <= 0;
        }
    }
}
