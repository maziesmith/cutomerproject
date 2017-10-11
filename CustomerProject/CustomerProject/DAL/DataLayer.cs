using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CustomerProject.ViewModels;
using CustomerProject.Functions;

namespace CustomerProject.DAL
{
    public class DataLayer
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using (var db = new CustomerViewerEntities())
            {
                List<CustomerDetail> dbCustomers = db.CustomerDetails.ToList();

                foreach(CustomerDetail entity in dbCustomers)
                {
                    customers.Add(CustomerModelMapper.convertEntityToCustomer(entity));
                }
            }

            return customers;
        }

        public static void AddCustomer(Customer customer)
        {
            using (var db = new CustomerViewerEntities())
            {
                customer.ID = Guid.NewGuid();
                db.CustomerDetails.Add(CustomerModelMapper.convertCustomerToEntity(customer));
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