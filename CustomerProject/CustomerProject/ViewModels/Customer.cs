using CustomerProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerProject.ViewModels
{
    public class Customer
    {
        public enum Gender { Female, Male}
        private static readonly Regex PHONENUMBER = new Regex("^[0-9]+$");

        public String Name { get; private set; }
        public short Age { get; private set; }
        public String Address { get; private set; }
        public String PhoneNumber { get; private set; }
        public Gender CustomerGender { get; set; }

        public Customer()
        {
        }

        public Customer(CustomerTableModel ctm)
        {
            SetName(ctm.Name);
            SetAge(ctm.Age);
            SetAddress(ctm.Address);
            SetPhoneNumber(ctm.PhoneNumber);
            if (ctm.Gender)
            {
                this.CustomerGender = Gender.Male;
            }
            else
            {
                this.CustomerGender = Gender.Female;
            }
        }

        public Customer(String Name, short Age, String Address, String PhoneNumber, Gender CustomerGender)
        {
            SetName(Name);
            SetAge(Age);
            SetAddress(Address);
            SetPhoneNumber(PhoneNumber);
            this.CustomerGender = CustomerGender;
        }

 


        public void SetName(String Name)
        {
            if(Name == null || Name.Equals(""))
                throw new InvalidValueException("The Name: "+Name+" is invalid!");

            this.Name = Name;
        }

        public void SetPhoneNumber(String PhoneNumber)
        {
            if (PhoneNumber == null || PhoneNumber.Equals("") || !PHONENUMBER.IsMatch(PhoneNumber))
                throw new InvalidValueException("The PhoneNumber: " + PhoneNumber + " is invalid!");

            this.PhoneNumber = PhoneNumber;
        }

        public void SetAddress(String Address)
        {
           // if (Address == null || Address.Equals(""))
             //   throw new InvalidValueException("The Address: " + Address + " is invalid!");

            this.Address = Address;
        }

        public void SetAge(short Age)
        {
            if (Age < 0)
                throw new InvalidValueException("The age: " + Age + " is invalid!");

            this.Age = Age;
        }
    }
}