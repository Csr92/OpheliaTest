using Dao;
using Entities;
using System.Collections.Generic;
namespace Business
{
    public class BillB
    {
        public Bill Add(Bill Bill)
        {
            return new BillDao().Add(Bill);
        }

        public List<Bill> GetAll()
        {
            return new BillDao().GetAll();
        }

        public Bill GetById(int id)
        {
            return new BillDao().GetById(id);
        }

        public Bill Edit(Bill Bill)
        {
            return new BillDao().Edit(Bill);
        }

        public bool Delete(Bill Bill)
        {
            return new BillDao().Delete(Bill);
        }
    }
}