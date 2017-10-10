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
            using (var db = new CustomerViewerEntities())
            {
                return db.CustomerDetails.ToList();
            }
        }

        public static void AddCustomer(CustomerDetail entity)
        {
            using (var db = new CustomerViewerEntities())
            {
                db.CustomerDetails.Add(entity);
                db.SaveChanges();
            }
        }

        public static void DeleteCustomer(Guid id)
        {
            using (var db = new CustomerViewerEntities())
            {
                var customerToDelete = new CustomerDetail { id = id };
                db.CustomerDetails.Attach(customerToDelete);
                db.CustomerDetails.Remove(customerToDelete);
                db.SaveChanges();
            }
        }
    }
}