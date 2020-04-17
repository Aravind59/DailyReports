using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using DailyReports.Contracts.Interfaces;
using DailyReports.Contracts.Models;
using DailyReports.Helpers;
using DailyReports.Models;

namespace DailyReports.Controllers
{
    public class StationsApiController : BaseController
    {
        private readonly IStationsService _stationsService;
        public StationsApiController(IStationsService stationsService)
        {
            _stationsService = stationsService;
        }

        [HttpGet]
        [HttpOptions]
        [Route("StationsApi/GetStationsList")]
        public JsonResult<MyJsonResult>  GetStationsList()
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _stationsService.GetStationsList(LoggedInUser, validationMessages);

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
    }
}