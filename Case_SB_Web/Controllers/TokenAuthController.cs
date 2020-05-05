using Case_SB_Web.Repository;
using Newtonsoft.Json;
using System.Web.Http;

namespace Case_SB_Web.Controllers
{
    public class TokenAuthController : ApiController
    {
        [Authorize(Roles = "Manager, Admin")]
        [HttpGet]
        [Route("getProducts")]
        public IHttpActionResult GetProducts()
        {
            using (ProductRepository _products = new ProductRepository())
            {
                return Ok(JsonConvert.SerializeObject(_products.GetProducts()));
            }
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        [Route("getDescriptedProducts")]
        public IHttpActionResult GetProductsWithDescription()
        {
            using (ProductRepository _products = new ProductRepository())
            {
                return Ok(JsonConvert.SerializeObject(_products.GetProductsWithDescriptions()));
            }
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        [Route("getFirstProduct")]
        public IHttpActionResult GetFirstProduct()
        {
            using (ProductRepository _products = new ProductRepository())
            {
                return Ok(JsonConvert.SerializeObject(_products.GetFirstProduct()));
            }
        }
    }
}
