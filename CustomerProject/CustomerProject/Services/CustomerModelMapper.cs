using CustomerProject.DAL;
using CustomerProject.ViewModels;
using System;

namespace CustomerProject.Functions
{
    public class CustomerModelMapper
    {
        public static CustomerModel convertEntityToCustomer(CustomerDetail entity)
        {
            CustomerModel c = new CustomerModel
            (
                entity.id,
                entity.name,
                entity.age,
                entity.address,
                entity.telephone_no,
                entity.gender
            );

            return c;
        }

        public static CustomerDetail convertCustomerToEntity(CustomerModel c)
        {
            CustomerDetail entity = new CustomerDetail
            {
                id = c.ID,
                address = c.Address,
                age = c.Age,
                gender = c.Gender,
                name = c.Name,
                telephone_no = c.PhoneNumber
            };

            return entity;
        }
    }
}