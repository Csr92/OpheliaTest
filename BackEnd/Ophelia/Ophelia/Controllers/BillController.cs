using Business;
using Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace Ophelia.Controllers
{
    [RoutePrefix("api/Bill")]
    public class BillController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Bill> GetAll()
        {
            return new BillB().GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public Bill GetById(int id)
        {
            return new BillB().GetById(id);
        }

        [HttpPost]
        [Route("Add")]
        public Bill Add([FromBody] Bill Bill)
        {
            return new BillB().Add(Bill);
        }

        [HttpPut]
        [Route("Edit")]
        public Bill Edit([FromBody] Bill Bill)
        {
            return new BillB().Edit(Bill);
        }

        // DELETE: api/Bill/5
        public void Delete(int id)
        {
        }
    }
}