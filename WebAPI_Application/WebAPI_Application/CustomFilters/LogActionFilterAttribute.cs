using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI_Application.CustomFilters
{
    public class LogActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
           
        }

    }
}