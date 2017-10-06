namespace CustomerProject
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CustomerTableModel
    {
        public int id { get; set; }
        public String Name { get; set; }
        public short Age { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public bool Gender { get; set; }

    }

}