using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyReports.Contracts.Models;

namespace DailyReports.Repositories.Helpers
{
   public class SqlValidationHelper
    {
        public static void ValidateGetAllSqlExceptions(List<ValidationMessage> validationMessages, SqlException sqlException, string message)
        {

            if (sqlException.Number < 50000)
            {
                validationMessages.Add(new ValidationMessage
                {
                    ValidationMessageType = MessageTypeEnum.Error,
                    ValidationMessaage = message

                });
            }
            else
            {
                //validationMessages.Add(new ValidationMessage
                //{
                //    ValidationMessageType = MessageTypeEnum.Error,
                //    ValidationMessaage = GetPropValue(sqlException.Message)
                //});
            }
        }

        //private static string GetPropValue(string propName)
        //{

        //    object src = new LangText();
        //    return src.GetType().GetProperty(propName)?.GetValue(src, null).ToString();
        //}
    }
}
