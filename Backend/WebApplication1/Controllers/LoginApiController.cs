using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using DailyReports.Contracts.Interfaces;
using DailyReports.Contracts.Models;
using DailyReports.Helpers;
using DailyReports.Models;
using Newtonsoft.Json;

namespace DailyReports.Controllers
{
    public class LoginApiController : BaseController
    {
        private readonly IUserService _userService;
        public LoginApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<HttpResponseMessage> Authenticate(string userName, string password)
        {
            try
            {
                Token tok = GetAccessToken(userName, password);
                tok.User = _userService.GetUserDetails(userName, password);
              
                return await Task.Factory.StartNew(() => Request.CreateResponse(System.Net.HttpStatusCode.OK, tok));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        [HttpPost]
        [HttpOptions]
        [AllowAnonymous]
        [Route("LoginApi/RegisterUser")]
        public JsonResult<MyJsonResult> RegisterUser(UserRegistration userRegistration)
        {
            try
            {
                var validationMessages = new List<ValidationMessage>();

                var result = _userService.RegisterUser(userRegistration, LoggedInUser, validationMessages);

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


        private Token GetAccessToken(string userName, string password)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://localhost:60074");
            client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            string body = "grant_type=password&username=" + userName + "&password=" + password;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/token");
            request.Content = new StringContent(body);//CONTENT-TYPE header

            var response = client.SendAsync(request).GetAwaiter().GetResult();
            var jsonContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
           
            return JsonConvert.DeserializeObject<Token>(jsonContent);
        }
        
    }
}