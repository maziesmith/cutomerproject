using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.ViewModels
{
    public class Customer
    {
        public Customer(String Name, int Age, String Address, long PhoneNumber, String Gender)
        {
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
        }

        public String Name { get; set; }
        public int Age { get; set; }
        public String Address { get; set; }
        public long PhoneNumber { get; set; }
        public String Gender { get; set; }

    }
}