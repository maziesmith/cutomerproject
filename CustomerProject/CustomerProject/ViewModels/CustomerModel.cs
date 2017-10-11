using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerProject.ViewModels
{
    public class CustomerModel : IDModel
    {
        public CustomerModel()
        {
            // empty constructor
        }

        public CustomerModel(Guid ID, String Name, short Age, String Address, long PhoneNumber, String Gender)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
            this.Gender = Gender;
        }

        public String Name { get; set; }
        public short Age { get; set; }
        public String Address { get; set; }
        public long PhoneNumber { get; set; }
        public String Gender { get; set; }
    }
}