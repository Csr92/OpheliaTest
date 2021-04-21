using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Dao
{
    public class BillDao
    {

        public Bill Add(Bill bill)
        {
            try
            {
                var list = new Bill();
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Bills.Add(bill);
                    db.SaveChanges();
                    bill = db.Bills.SingleOrDefault(c => c.Id == bill.Id);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public List<Bill> GetAll()
        {
            try
            {
                var list = new List<Bill>();
                var finalList = new List<Bill>();
                var clientDao = new ClientDao();
                var companyDao = new CompanyDao();
                var billDetailsDao = new BillDetailsDao();
                
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Configuration.ProxyCreationEnabled = false;
                    db.Bills.AsNoTracking().FirstOrDefault();
                    list = db.Bills.ToList();
                    foreach (var item in list)
                    {
                        item.Client = clientDao.GetById(item.IdClient);
                        item.Company = companyDao.GetById(item.IdCompany);
                        var a = billDetailsDao.GetByBill(item.Id);
                        item.BillDetails = a;
                        finalList.Add(item);
                    }
                }
              
                return finalList;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Bill GetById(int id)
        {
            try
            {
                var obj = new Bill();
                using (OpheliaContext db = new OpheliaContext())
                {
                    obj = db.Bills.SingleOrDefault(c => c.Id == id);
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Bill Edit(Bill bill)
        {
            try
            {
                var response = new Bill();
                using (OpheliaContext db = new OpheliaContext())
                {
                    var result = db.Bills.SingleOrDefault(b => b.Id == bill.Id);
                    if (result != null)
                    {
                        result = bill;
                        db.SaveChanges();
                    }
                    response = db.Bills.SingleOrDefault(b => b.Id == bill.Id);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public bool Delete(Bill bill)
        {
            try
            {
                var response = false;
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Bills.Remove(bill);
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