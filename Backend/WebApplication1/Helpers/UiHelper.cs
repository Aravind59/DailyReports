using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DailyReports.Contracts.Models;
using DailyReports.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DailyReports.Helpers
{
    public static class UiHelper
    {
        public static JsonSerializerSettings JsonSerializerNullValueIncludeSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Include
        };

        public static bool CheckForValidationMessages(List<ValidationMessage> validationMessages, out MyJsonResult myApiResult)
        {
            myApiResult = new MyJsonResult()
            {
                Success = false
            };
            if (validationMessages.Any())
            {
                foreach (ValidationMessage validationMessage in validationMessages)
                {
                    myApiResult.ApiResponseMessages.Add(new ApiResponseMessage
                    {
                        FieldName = validationMessage.Field,
                        Message = validationMessage.ValidationMessaage,
                        MessageTypeEnum = validationMessage.ValidationMessageType
                    });
                }
                return true;
            }
            return false;
        }
    }
}