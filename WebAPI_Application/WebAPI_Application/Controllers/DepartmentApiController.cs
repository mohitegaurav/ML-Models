using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using WebAPI_Application.Models;
using WebAPI_Application.Repository;
using System.Web.Http.Cors;

namespace WebAPI_Application.Controllers
{
    [EnableCors("*","*","*")]
    public class DepartmentApiController : ApiController
    {
        DepartmentRepository _deptRepo;

        public DepartmentApiController()
        {
            _deptRepo = new DepartmentRepository();
        }

        [ResponseType(typeof(IEnumerable<Department>))]
        public IHttpActionResult Get()
        {
            return Ok(_deptRepo.Get());
        }

        [ResponseType(typeof(Department))]
        public IHttpActionResult Get(int id)
        {
            return Ok(_deptRepo.Get(id));
        }

        [ResponseType(typeof(Department))]
        public IHttpActionResult Post(Department dept)
        {
            if (ModelState.IsValid)
            {
                var d = _deptRepo.Create(dept);
                return Ok(d);
            }
            else
            {
                //return BadRequest(ModelState);
                return new ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.Forbidden, new HttpError(ModelState, true)));
            }

        }
        [ResponseType(typeof(bool))]
        public IHttpActionResult Put(int id, Department dept)
        {
            if (ModelState.IsValid)
            {
                return Ok(_deptRepo.Update(id, dept));
            }
            else
            {
                return BadRequest("Error in Posted Data " + ModelState);
            }

        }
        [ResponseType(typeof(bool))]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_deptRepo.Delete(id));
        }
    }
}
