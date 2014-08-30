using System;
using System.Linq;
using UsingEntityFramework;
using System.Data.Entity;

namespace _02.DAO
{
    public static class DAO
    {
        private static NorthwindEntities context = new NorthwindEntities();
        private static DbSet<Customer> customers = context.Customers;

        public static int InsertCustomer(Customer customer)
        {
            customers.Add(customer);
            int returnCode = context.SaveChanges();
            return returnCode;
        }

        public static int UpdateCustomer(int customerID, Customer newCustomer)
        {
            var customerToUpdate = customers.Find(customerID);
            customerToUpdate.Address = newCustomer.Address;
            customerToUpdate.City = newCustomer.City;
            customerToUpdate.CompanyName = newCustomer.CompanyName;
            customerToUpdate.ContactName = newCustomer.ContactName;
            customerToUpdate.ContactTitle = newCustomer.ContactTitle;
            customerToUpdate.Country = newCustomer.Country;
            customerToUpdate.Fax = newCustomer.Fax;
            customerToUpdate.Phone = newCustomer.Phone;
            customerToUpdate.PostalCode = newCustomer.PostalCode;
            customerToUpdate.Region = newCustomer.Region;
            int returnCode = context.SaveChanges();

            return returnCode;
        }
        public static int DeleteCustomer(int customerID)
        {
            var customerToRemove = customers.Find(customerID);
            customers.Remove(customerToRemove);
            int returnCode = context.SaveChanges();
            return returnCode;
        }
    }
}
