using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UsingEntityFramework;

namespace _2.DAOTests
{
    [TestClass]
    public class DAOTests
    {
        [TestMethod]
        public void TestInsertCustomer()
        {
            int expected = 1;
            int actual = DAO.DAO.InsertCustomer(new Customer {CustomerID = "5555", ContactName = "Pesho", CompanyName = "Metalurg" });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUpdateCustomer()
        {
            int expected = 1;
            int actual = DAO.DAO.UpdateCustomer("5555", new Customer { ContactName = "PeshoModded", CompanyName = "MetalurgNew" });

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDeleteCustomer()
        {
            int expected = 1;
            int actual = DAO.DAO.DeleteCustomer("5555");

            Assert.AreEqual(expected, actual);
        }
    }
}
