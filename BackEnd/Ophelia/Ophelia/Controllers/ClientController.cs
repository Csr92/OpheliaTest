using Business;
using Entities;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    [RoutePrefix("api/Client")]

    public class ClientController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Client> GetAll()
        {
            return new ClientB().GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public Client GetById(int id)
        {
            return new ClientB().GetById(id);
        }

        [HttpPost]
        [Route("Add")]
        public Client Add([FromBody] Client client)
        {
            return new ClientB().Add(client);
        }

        [HttpPut]
        [Route("Edit")]
        public Client Edit([FromBody] Client client)
        {
            return new ClientB().Edit(client);
        }

        // DELETE: api/Client/5
        public void Delete(int id)
        {
        }
    }
}