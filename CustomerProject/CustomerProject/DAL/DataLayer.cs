using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.DAL
{
    public class DataLayer
    {
        public static List<CustomerDetail> GetCustomers()
        {
            try
            {
                using (var db = new CustomerViewerEntities())
                {
                    return db.CustomerDetails.ToList();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.InnerException);
                return new List<CustomerDetail>();
            }
        }

        public static bool AddCustomer(CustomerDetail entity)
        {
            try
            {
                using (var db = new CustomerViewerEntities())
                {
                    db.CustomerDetails.Add(entity);
                    db.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.InnerException);
                return false;
            }
        }
    }
}