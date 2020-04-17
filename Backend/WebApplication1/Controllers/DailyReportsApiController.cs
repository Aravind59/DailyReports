using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using DailyReports.Contracts.Interfaces;


namespace DailyReports.Controllers
{
    public class DailyReportsApiController : BaseController
    {
        private readonly IDailyReports _dailyReports;
        public DailyReportsApiController(IDailyReports dailyReports)
        {
            _dailyReports = dailyReports;
        }

        [HttpGet]
        [HttpOptions]
        [Route("DailyReportsApi/GetDailyReports")]
        public async Task<HttpResponseMessage> GetDailyReports()
        {
          
            try
            {
                var result = _dailyReports.GetDailyReports(DateTime.Today);

                return await Task.Factory.StartNew(() => Request.CreateResponse(HttpStatusCode.OK, result));
            }
            catch (Exception ex)
            {
                return await Task.Factory.StartNew(() => Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
          
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddDailyReport(Contracts.Models.DailyReports report)
        {
            if (report == null)
            {
                throw new NullReferenceException();
            }

            try
            {
                 _dailyReports.AddReport(report);

                return await Task.Factory.StartNew(() => Request.CreateResponse(HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return await Task.Factory.StartNew(() => Request.CreateResponse(HttpStatusCode.NotFound, ex.Message));
            }
           
        }

    }
}