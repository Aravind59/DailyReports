using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DailyReports.Repositories
{
   public class DailyreportsRepository : BaseRepository
    {
        public List<Contracts.Models.DailyReports> GetDailyReports(DateTime date)
        {
           
            using (IDbConnection conn = OpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Date", date);
              return conn.Query<Contracts.Models.DailyReports>("USP_GetDailyReports", parameters, commandType: CommandType.StoredProcedure).ToList();

            }

        }

        public void AddReport(Contracts.Models.DailyReports report)
        {
            using (IDbConnection conn = OpenConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", report.Id);
                parameters.Add("@SupplierId", report.SupplierId);
                parameters.Add("@Quantity", report.Quantity);
                parameters.Add("@Percentage", report.Percentage);
                parameters.Add("@Price", report.Price);
                conn.Query<Contracts.Models.DailyReports>("Usp_AddDailyReport", parameters, commandType: CommandType.StoredProcedure);

            }

        }
    }
}
