using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI_Application.Models;

namespace WebAPI_Application.Controllers
{
    public class DeptEmpApiController : ApiController
    {
        ApplicationEntities ctx;

        public DeptEmpApiController()
        {
            ctx = new ApplicationEntities();
        }

        //This is Option 1 for passing complex data/object

        //public IHttpActionResult Post([FromUri]Department dept,[FromBody]Employee emp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ctx.Department.Add(dept);
        //        ctx.Employee.Add(emp);
        //        int res = ctx.SaveChanges();
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return new ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ModelState, true)));
        //    }
        //}

        //This is Option 2 for passing complex data/object
        public IHttpActionResult Post(DeptEmp d)
        {
            if (ModelState.IsValid)
            {
                ctx.Department.Add(d.Dept);
                ctx.Employee.Add(d.Emp);
                int res = ctx.SaveChanges();
                return Ok(res);
            }
            else
            {
                return new ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.BadRequest, new HttpError(ModelState, true)));
            }
        }
    }
}
