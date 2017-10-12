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
            return GetCustomers(String.Empty);
        }

        public static List<Customer> GetCustomers(string nameFilter)
        {
            List<Customer> customers = new List<Customer>();
            using (var db = new CustomerViewerEntities())
            {
                IQueryable<CustomerDetail> dbCustomers = db.CustomerDetails;

                if (!String.IsNullOrEmpty(nameFilter))
                {
                    dbCustomers = dbCustomers.Where(c => c.name.Contains(nameFilter));
                }

                List<CustomerDetail> dbCustomersList = dbCustomers.ToList();

                foreach(CustomerDetail entity in dbCustomersList)
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

        public static List<Customer> SearchCustomers(String searchString)
        {
            // creating fucntion to get customers from db,
            // passing parameter from search input as searchString

            List<Customer> customers = new List<Customer>();
            using (var db = new CustomerViewerEntities())
            {
                List<CustomerDetail> dbCustomers = 
                    db.CustomerDetails
                    .Where(c => c.name.Contains(searchString))
                    .ToList();

                /*foreach (CustomerDetail entity in dbCustomers)
                {
                    if (entity.name == searchString)
                    {
                        customers.Add(CustomerModelMapper.convertEntityToCustomer(entity));
                    }
                }*/
            }
            return customers;
        }
    }
}