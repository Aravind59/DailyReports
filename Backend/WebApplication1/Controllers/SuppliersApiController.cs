using System;
using System.Collections.Generic;
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
    public class SuppliersApiController : BaseController
    {
        private readonly ISuppliers _suppliersService;
        public SuppliersApiController(ISuppliers suppliers)
        {
            _suppliersService = suppliers;
        }

        
        [HttpGet]
        [HttpOptions]
        [Route("SuppliersApi/GetSuppliers")]
        public JsonResult<MyJsonResult> GetSuppliers(int stationId)
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _suppliersService.GetSuppliers(stationId, LoggedInUser, validationMessages);

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
        [HttpOptions]
        [Route("SuppliersApi/UpsertSupplier")]
        public JsonResult<MyJsonResult> UpsertSupplier(Supplier supplier)
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _suppliersService.UpsertSupplier(supplier, LoggedInUser, validationMessages);

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

        [HttpDelete]
        [HttpOptions]
        [Route("SuppliersApi/DeleteSupplier")]
        public JsonResult<MyJsonResult> DeleteSupplier(int supplierId)
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _suppliersService.DeleteSupplier(supplierId, LoggedInUser, validationMessages);

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