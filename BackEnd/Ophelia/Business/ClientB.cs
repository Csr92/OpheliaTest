using Dao;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class ClientB
    {
        public Client Add(Client client)
        {
            return new ClientDao().Add(client);
        }

        public List<Client> GetAll()
        {
            return new ClientDao().GetAll();
        }

        public Client GetById(int id)
        {
            return new ClientDao().GetById(id);
        }

        public Client Edit(Client client)
        {
            return new ClientDao().Edit(client);
        }

        public bool Delete(Client client)
        {
            return new ClientDao().Delete(client);
        }
    }
}