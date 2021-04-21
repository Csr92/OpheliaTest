using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dao
{
    public class BillDetailsDao
    {

        public List<BillDetail> GetByBill(int billId)
        {
            try
            {
                var obj = new List<BillDetail>();
                var final = new List<BillDetail>();
                var productDao = new ProductDao();

                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.BillDetails.AsNoTracking().FirstOrDefault();
                    obj = db.BillDetails.Where(c => c.IdBill == billId ).ToList();
                }
                foreach (var item in obj)
                {
                    item.Product = productDao.GetById(item.IdProduct);
                    final.Add(item);
                }        
                return final;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
    }
}
