using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace DailyReports
{
    public class PortalAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {

            IPrincipal principal = actionContext.ControllerContext.RequestContext.Principal;
           var res = principal.Identity.IsAuthenticated;
           //var rs = principal.Identity.
            return base.IsAuthorized(actionContext);
        }
    }
}