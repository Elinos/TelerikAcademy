using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class Bank
    {
        private readonly List<Account> accounts = new List<Account>();
        private readonly List<Customer> customers = new List<Customer>();

        public string Name { get; private set; }

        public Bank(string name)
        {
            this.Name = name;
        }

        public void AddAccount(params Account[] accounts)
        {
            foreach (var account in accounts)
                this.accounts.Add(account);
        }

        public void RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
        }

        public void AddCustomer(params Customer[] customers)
        {
            foreach (var customer in customers)
                this.customers.Add(customer);
        }

        public void RemoveCustomer(Customer customer)
        {
            this.customers.Remove(customer);
        }
    }
}
