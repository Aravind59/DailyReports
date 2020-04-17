using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DailyReports.Contracts.Models;
using DailyReports.Repositories.Helpers;
using Dapper;

namespace DailyReports.Repositories
{
   public class UserRepository : BaseRepository
    {
        public UserDetails GetUserDetails(string userName, string password)
        {
            using (IDbConnection conn = OpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserName", userName);
                return conn.Query<UserDetails>("USP_GetUserDetails", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }
        }

        public int? AddUser(UserDetails userDetails, List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    byte[] encData_byte;
                    encData_byte = System.Text.Encoding.UTF8.GetBytes(userDetails.Password);
                    string encodedData = Convert.ToBase64String(encData_byte);
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", userDetails.Id);
                    parameters.Add("@UserName", userDetails.Username);
                    parameters.Add("@Email", userDetails.Email);
                    parameters.Add("@Password", encodedData);
                    parameters.Add("@IsActive", userDetails.IsActive);
                    parameters.Add("@IsAdmin", userDetails.IsAdmin);
                    return conn.Query<int?>("USP_UpsertUser", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to create the user, please contact Admin");
                return null;
            }

        }
    }
}
