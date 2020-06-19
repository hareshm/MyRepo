using System;
using System.Collections.Generic;
using System.Xml.Linq;
using CRMApi.Business;
using CRMApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRMApiTests
{
    [TestClass]
    public class USPSUnitTest
    {
        [TestMethod]
        public void TestGetXDoc()
        {
            Address address = new Address()
            {
                Line1 = "955 American Lane",
                City = "Schaumburg",
                State = "IL",
                PostalCode = "60173",
                Country = "US"
            };

            XDocument xDoc = USPS.GetXDoc(address);
            Assert.IsTrue(xDoc != null);
        }

        [TestMethod]
        public void TestValidAddress()
        {
            Address address = new Address()
            {
                Line1 = "955 American Lane",
                City = "Schaumburg",
                State = "IL",
                PostalCode = "60173",
                Country = "US"
            };

            XDocument xDoc = USPS.GetXDoc(address);
            List<Address> uspsAddresses = USPS.ValidateAddress(xDoc);

            Assert.AreEqual(uspsAddresses.Count, 1);
            Assert.IsTrue(uspsAddresses[0].IsValid);

        }

        [TestMethod]
        public void TestInValidAddress()
        {
            Address address = new Address()
            {
                Line1 = "3800 American Lane",
                City = "Schaumburg",
                State = "IL",
                PostalCode = "60173",
                Country = "US"
            };

            XDocument xDoc = USPS.GetXDoc(address);
            List<Address> uspsAddresses = USPS.ValidateAddress(xDoc);

            Assert.AreEqual(uspsAddresses.Count, 1);
            Assert.IsFalse(uspsAddresses[0].IsValid);
        }
    }        
}
