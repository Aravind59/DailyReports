using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyReports.Repositories
{
   public abstract class BaseRepository
    {
        protected static IDbConnection OpenConnection()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DailyReportsConnectionString"].ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
