using Business;
using Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Ophelia.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Product> GetAll()
        {
            return new ProductB().GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public Product GetById(int id)
        {
            return new ProductB().GetById(id);
        }

        [HttpPost]
        [Route("Add")]
        public Product Add([FromBody] Product Product)
        {
            return new ProductB().Add(Product);
        }

        [HttpPut]
        [Route("Edit")]
        public Product Edit([FromBody] Product Product)
        {
            return new ProductB().Edit(Product);
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}