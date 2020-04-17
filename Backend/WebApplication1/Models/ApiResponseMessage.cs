using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DailyReports.Contracts.Models;

namespace DailyReports.Models
{
    public class ApiResponseMessage
    {
        public MessageTypeEnum MessageTypeEnum { get; set; }
        public string FieldName { get; set; }
        public string Message { get; set; }
    }


}