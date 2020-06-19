using System;
using CRMApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRMApiTests
{
    [TestClass]
    public class CustomerUnitTest
    {
        [TestMethod]
       public void TestInvalidEmail()
       {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Haresh Mirpuri",
                Email = "Haresh.Mirpuri1gmail.com"
            };
                        
            Assert.IsFalse(customer.IsEmailValid());
            Assert.IsFalse(customer.IsCustomerValid());
       }

        [TestMethod]
        public void TestInvalidName()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "",
                Email = "Haresh.Mirpuri1@gmail.com"
            };

            Assert.IsTrue(customer.IsEmailValid());
            Assert.IsFalse(customer.IsCustomerValid());
        }

        [TestMethod]
        public void TestValidCustomer()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "Haresh Mirpuri",
                Email = "Haresh.Mirpuri1@gmail.com"
            };

            Assert.IsTrue(customer.IsEmailValid());
            Assert.IsTrue(customer.IsCustomerValid());
        }   

  }
}
