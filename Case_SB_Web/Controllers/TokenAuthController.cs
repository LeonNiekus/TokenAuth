using Case_SB_Web.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Case_SB_Web.Controllers
{
    public class TokenAuthController : ApiController
    {
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("getProducts")]
        public IHttpActionResult GetResource1()
        {
            using (ProductRepository _products = new ProductRepository())
            {
                return Ok(JsonConvert.SerializeObject(_products.GetProducts()));
            }
        }
    }
}
