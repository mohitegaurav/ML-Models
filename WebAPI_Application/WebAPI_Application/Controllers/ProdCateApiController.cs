using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Application.Models;

namespace WebAPI_Application.Controllers
{
    [RoutePrefix("CPApi")]
    public class ProdCateApiController : ApiController
    {
        [Route("get/{cname}/{filter}/{pname}")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(string cName, string filter, string pName)
        {
            List<Product> prods = new List<Product>();

            var catId = (from c in new Categories() where c.CategoryName == cName select c).FirstOrDefault().CategoryId;

            switch (filter)
            {
                case "OR":
                    prods = (from p in new Products() where p.CategoryId == catId || p.ProductName == pName select p).ToList();
                    break;
                case "AND":
                    prods = (from p in new Products() where p.CategoryId == catId && p.ProductName == pName select p).ToList();
                    break;            
            }

            return Ok(prods);
        }
    }
}
