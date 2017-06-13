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

namespace WebAPI_Application.Controllers
{
    public class EmployeeApiController : ApiController
    {
        EmployeeRepository _empRepo;

        public EmployeeApiController()
        {
            _empRepo = new EmployeeRepository();
        }

        public IEnumerable<Employee> Get()
        {
            return _empRepo.Get();
        }

        public Employee Get(int id)
        {
            return _empRepo.Get(id);
        }

        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee emp)
        {
            if (emp == null)
            {
                throw new ProcessException("Record Not Found, It may be removed");
            }
            return Ok(emp);

            /*if (ModelState.IsValid)
            {
                var d = _empRepo.Create(emp);
                return Ok(d);
            }
            else
            {
                //return BadRequest(ModelState);
                return new ResponseMessageResult(Request.CreateErrorResponse(HttpStatusCode.Forbidden, new HttpError(ModelState, true)));
            }*/

        }

        public bool Put(int id, Employee emp)
        {
            return _empRepo.Update(id, emp);
        }

        public bool Delete(int id)
        {
            return _empRepo.Delete(id);
        }
    }
}
