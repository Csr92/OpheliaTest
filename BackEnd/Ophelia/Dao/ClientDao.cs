using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dao
{
    public class ClientDao
    {
        public Client Add(Client client)
        {
            try
            {
                var list = new Client();
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    client = db.Clients.SingleOrDefault(c => c.DocNumber == client.DocNumber);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
        public List<Client> GetAll()
        {
            try
            {
                var list = new List<Client>();
                using (OpheliaContext db = new OpheliaContext())
                {
                    list = db.Clients.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Client GetById(int id)
        {
            try
            {
                var client = new Client();
                using (OpheliaContext db = new OpheliaContext())
                {
                    client = db.Clients.SingleOrDefault(c => c.Id == id);
                }
                return client;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Client Edit(Client client)
        {
            try
            {
                var response = new Client();
                using (OpheliaContext db = new OpheliaContext())
                {
                    var result = db.Clients.SingleOrDefault(b => b.Id == client.Id);
                    if (result != null)
                    {
                        result = client;
                        db.SaveChanges();
                    }
                    response = db.Clients.SingleOrDefault(b => b.Id == client.Id);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public bool Delete(Client client)
        {
            try
            {
                var response = false;
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Clients.Remove(client);
                    db.SaveChanges();
                    response = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
    }
}