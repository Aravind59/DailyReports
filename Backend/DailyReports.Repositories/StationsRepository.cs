using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyReports.Contracts.Models;
using DailyReports.Repositories.Helpers;
using Dapper;

namespace DailyReports.Repositories
{
   public class StationsRepository : BaseRepository
    {
        public List<Station> GetStationsList(List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    return conn.Query<Station>("USP_GetStationsList").ToList();

                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to Get stations list please contact Admin");
                return new List<Station>();
            }
            
        }

        public int? AddStation(Station station ,List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", station.Id);
                    parameters.Add("@StationName", station.Name);
                    parameters.Add("@StationCode", station.StationCode);
                    parameters.Add("@Address", station.Address);
                    parameters.Add("@MobileNumber", station.MobileNumber);
                    parameters.Add("@IsActive", station.IsActive);
                    return conn.Query<int?>("Usp_UpsertStation", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();

                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to Get stations list please contact Admin");
                return null;
            }

        }
    }
}
