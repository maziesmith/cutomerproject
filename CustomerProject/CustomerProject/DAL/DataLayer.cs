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
        public static List<CustomerModel> GetCustomers()
        {
            return GetCustomers(String.Empty);
        }

        public static List<CustomerModel> GetCustomers(string searchFilter)
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            using (var db = new CustomerViewerEntities())
            {
                IQueryable<CustomerDetail> dbCustomers = db.CustomerDetails;

                if (!string.IsNullOrEmpty(searchFilter))
                {
                    dbCustomers = dbCustomers.Where(c => c.name.Contains(searchFilter));
                }

                List<CustomerDetail> dbCustomerList = dbCustomers.ToList();

                foreach(CustomerDetail entity in dbCustomerList)
                {
                    customers.Add(CustomerModelMapper.convertEntityToCustomer(entity));
                }
            }

            return customers;
        }

        public static CustomerModel GetCustomer(Guid id)
        {
            using (var db = new CustomerViewerEntities())
            {
                CustomerDetail dbCustomer = db.CustomerDetails.FirstOrDefault(c => c.id == id);
                return CustomerModelMapper.convertEntityToCustomer(dbCustomer);
            }
        }

        public static void AddCustomer(CustomerModel customer)
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

        public static void EditCustomer(CustomerModel editedCustomer)
        {
            using (var db = new CustomerViewerEntities())
            {
                var dbEditedCustomer = CustomerModelMapper.convertCustomerToEntity(editedCustomer);
                db.CustomerDetails.Attach(dbEditedCustomer);
                db.Entry(dbEditedCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}