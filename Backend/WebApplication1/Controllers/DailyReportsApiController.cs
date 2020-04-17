using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DailyReports.Contracts.Interfaces;
using DailyReports.Contracts.Models;
using DailyReports.Helpers;
using DailyReports.Models;


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
        public JsonResult<MyJsonResult> GetDailyReports()
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _dailyReports.GetDailyReports(DateTime.Today);

                MyJsonResult myJsonResult;
                if (UiHelper.CheckForValidationMessages(validationMessages, out myJsonResult))
                {
                    return Json(new MyJsonResult { Success = false, ApiResponseMessages = myJsonResult.ApiResponseMessages }, UiHelper.JsonSerializerNullValueIncludeSettings);
                }

                return Json(new MyJsonResult { Data = result, Success = true }, UiHelper.JsonSerializerNullValueIncludeSettings);
            }
            catch (Exception exception)
            {
                return Json(new MyJsonResult(exception.Message), UiHelper.JsonSerializerNullValueIncludeSettings);
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