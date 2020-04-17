using DailyReports.Contracts.Models;
using DailyReports.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace DailyReports.Models
{
    public class MyJsonResult
    {
        public MyJsonResult(ModelStateDictionary modelState)
        {
            Success = false;

            ApiResponseMessages = new List<ApiResponseMessage>();
            foreach (var modelStateKey in modelState.Keys)
            {
                foreach (ModelError error in modelState[modelStateKey].Errors)
                {
                    ApiResponseMessages.Add(new ApiResponseMessage
                    {
                        FieldName = modelStateKey,
                        Message = error.ErrorMessage,
                        MessageTypeEnum = MessageTypeEnum.Error
                    });
                }
            }

        }

        public MyJsonResult(string message)
        {
            Success = false;
            ApiResponseMessages = new List<ApiResponseMessage>
            {
                new ApiResponseMessage
                {
                    Message = message,
                    MessageTypeEnum = MessageTypeEnum.Error
                }
            };
        }

        public MyJsonResult()
        {
            Success = true;
            ApiResponseMessages = new List<ApiResponseMessage>();
        }

        public List<ApiResponseMessage> ApiResponseMessages { get; set; }

        public string Result
        {
            get;
            set;
        }

        public bool Success
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }
    }
}