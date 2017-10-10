using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.ViewModels
{
    public class Customer
    {
        public Customer(Guid ID, String Name, short Age, String Address, long PhoneNumber, String Gender)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
        }

        public String Name { get; private set; }
        public short Age { get; private set; }
        public String Address { get; private set; }
        public long PhoneNumber { get; private set; }
        public String Gender { get; private set; }
        public Guid ID { get; private set; }
    }
}