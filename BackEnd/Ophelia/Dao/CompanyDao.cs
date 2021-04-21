using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace Dao
{
    public class CompanyDao
    {
        public Company Add(Company Company)
        {
            try
            {
                var list = new Company();
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Companies.Add(Company);
                    db.SaveChanges();
                    Company = db.Companies.SingleOrDefault(c => c.Nit == Company.Nit);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }
        public List<Company> GetAll()
        {
            try
            {
                var list = new List<Company>();
                using (OpheliaContext db = new OpheliaContext())
                {
                    list = db.Companies.ToList();
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Company GetById(int id)
        {
            try
            {
                var Company = new Company();
                using (OpheliaContext db = new OpheliaContext())
                {
                    Company = db.Companies.SingleOrDefault(c => c.Id == id);
                }
                return Company;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public Company Edit(Company Company)
        {
            try
            {
                var response = new Company();
                using (OpheliaContext db = new OpheliaContext())
                {
                    var result = db.Companies.SingleOrDefault(b => b.Id == Company.Id);
                    if (result != null)
                    {
                        result = Company;
                        db.SaveChanges();
                    }
                    response = db.Companies.SingleOrDefault(b => b.Id == Company.Id);
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat("Error ", this.GetType().Name, MethodBase.GetCurrentMethod(), ex.Message));
            }
        }

        public bool Delete(Company Company)
        {
            try
            {
                var response = false;
                using (OpheliaContext db = new OpheliaContext())
                {
                    db.Companies.Remove(Company);
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