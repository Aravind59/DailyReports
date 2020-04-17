using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using DailyReports.Contracts.Models;
using Microsoft.ApplicationInsights.Web;

namespace DailyReports.Controllers
{
    public abstract class BaseController : ApiController
    {
        public int UserId
        {
            get
            {

                var userClaims = Request.GetRequestContext().Principal as ClaimsPrincipal;
                if (userClaims == null || !userClaims.HasClaim(i => i.Type == "UserId"))
                    return default(int);

                return Convert.ToInt32(userClaims.FindFirst(i => i.Type == "UserId").Value);
            }
        }

        public LoggedInUser LoggedInUser
        {
            get
            {
                return new LoggedInUser
                {
                    UserId = UserId
                };
            }
            set
            {

            }
        }
    }
}