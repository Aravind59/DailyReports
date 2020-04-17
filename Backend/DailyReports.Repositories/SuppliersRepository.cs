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
   public class SuppliersRepository : BaseRepository
    {
        public List<Supplier> GetSuppliersList(int stationId, List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@StationId", stationId);
                    return conn.Query<Supplier>("USP_GetSuppliers", parameters, commandType:CommandType.StoredProcedure).ToList();

                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to Get stations list please contact Admin");
                return new List<Supplier>();
            }

        }

        public int? AddSupplier(Supplier supplier, List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", supplier.Id);
                    parameters.Add("@StationId", supplier.StationId);
                    parameters.Add("@UserId", supplier.UserId);
                    parameters.Add("@Address", supplier.Address);
                    parameters.Add("@MobileNumber", supplier.MobileNumber);
                    parameters.Add("@LogNumber", supplier.LogNumber);
                    parameters.Add("@FirstName", supplier.FirstName);
                    parameters.Add("@LastName", supplier.LastName);
                    parameters.Add("@IsActive", supplier.IsActive);

                    return conn.Query<int?>("USP_UpsertSupplier", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to Get stations list please contact Admin");
                return null;
            }

        }

        public bool? DeleteSupplier(int suplierId, List<ValidationMessage> validationMessages)
        {
            try
            {
                using (IDbConnection conn = OpenConnection())
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@SuplierId", suplierId);
                    parameters.Add("@IsActive", false);
                    conn.Query<bool?>("USP_DeleteSuplier", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                   return true;
                }
            }
            catch (SqlException sqlException)
            {
                SqlValidationHelper.ValidateGetAllSqlExceptions(validationMessages, sqlException, "Unable to Get stations list please contact Admin");
                return false;
            }

        }
    }
}
