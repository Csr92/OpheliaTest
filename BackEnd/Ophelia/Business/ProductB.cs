using Dao;
using Entities;
using System.Collections.Generic;

namespace Business
{
    public class ProductB
    {
        public Product Add(Product product)
        {
            return new ProductDao().Add(product);
        }
        public List<Product> GetAll()
        {
            return new ProductDao().GetAll();
        }

        public Product GetById(int id)
        {
            return new ProductDao().GetById(id);
        }

        public Product Edit(Product Product)
        {
            return new ProductDao().Edit(Product);
        }

        public bool Delete(Product Product)
        {
            return new ProductDao().Delete(Product);
        }
    }
}
