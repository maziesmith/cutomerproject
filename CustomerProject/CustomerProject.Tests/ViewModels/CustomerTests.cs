using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomerProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerProject.Exceptions;

namespace CustomerProject.ViewModels.Tests
{
    [TestClass()]
    public class CustomerTests
    {

        Customer c = new Customer();

        [TestMethod()]
        public void CustomerTest()
        {
            c = new Customer();
        }


        [TestMethod()]
        public void SetNameTest()
        {
            c.SetName("Walther");
   
           // Assert.Fail();
        }
        [TestMethod()]
        [ExpectedException(typeof(InvalidValueException))]
        public void SetNameTest2()
        {
            c.SetName("");

            // Assert.Fail();
        }

        [TestMethod()]
        public void SetPhoneNumberTest()
        {
            c.SetPhoneNumber("14219");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidValueException))]
        public void SetPhoneNumberTest2(){
            c.SetPhoneNumber("aasf");
        }

        [TestMethod()]
        public void SetAddressTest()
        {
            c.SetAddress("97215 Uffenheim");
        }

        [TestMethod()]
        public void SetAgeTest()
        {
            c.SetAge(15);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidValueException))]
        public void SetAgeTest2()
        {
            c.SetAge(-5);
        }
    }
}