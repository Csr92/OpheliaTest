using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dao
{
    public class ProductDao
    {
        public Product Add(Product product)
        {
            try
            {
                var list = new Product();
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    product = db.Products.SingleOrDefault(c => c.PName == product.PName);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
        public List<Product> GetAll()
        {
            try
            {
                var list = new List<Product>();
                using (OpheliaContext db = new OpheliaContext())
                {
                    list = db.Products.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Product GetById(int id)
        {
            try
            {
                var obj = new Product();
                using (OpheliaContext db = new OpheliaContext())
                {
                    obj = db.Products.SingleOrDefault(c => c.Id == id);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Product Edit(Product product)
        {
            try
            {
                var response = new Product();
                using (OpheliaContext db = new OpheliaContext())
                {
                    var result = db.Products.SingleOrDefault(b => b.Id == product.Id);
                    if (result != null)
                    {
                        result = product;
                        db.SaveChanges();
                    }
                    response = db.Products.SingleOrDefault(b => b.Id == product.Id);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public bool Delete(Product product)
        {
            try
            {
                var response = false;
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                    response = true;
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
    }
}