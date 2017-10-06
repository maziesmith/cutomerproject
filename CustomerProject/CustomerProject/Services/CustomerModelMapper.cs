using CustomerProject.DAL;
using CustomerProject.ViewModels;
using System;

namespace CustomerProject.Functions
{
    public class CustomerModelMapper
    {
        public static Customer convertEntityToCustomer(CustomerDetail entity)
        {
            Customer c = new Customer
            (
                entity.name,
                entity.age,
                entity.address,
                entity.telephone_no,
                entity.gender
            );

            return c;
        }

        public static CustomerDetail convertCustomerToEntity(Customer c)
        {
            CustomerDetail entity = new CustomerDetail
            {
                id = Guid.NewGuid(),
                address = c.Address,
                age = (short)c.Age,
                gender = c.Gender,
                name = c.Name,
                telephone_no = c.PhoneNumber
            };

            return entity;
        }
    }
}