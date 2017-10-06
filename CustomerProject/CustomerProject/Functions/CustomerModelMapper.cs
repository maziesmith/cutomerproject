using CustomerProject.DAL;
using CustomerProject.ViewModels;

namespace CustomerProject.Functions
{
    public class CustomerModelMapper
    {
        public Customer convertEntityToCustomer(CustomerDetail entity)
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
    }
}