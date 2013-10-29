using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    abstract class Account
    {
        public Customer Customer { get; protected set; }
        public decimal Balance { get; protected set; }
        public decimal InterestRate { get; protected set; }

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public virtual decimal CalculateInterest(decimal months)
        {
            return this.Balance * months * this.InterestRate;
        }
    }
}
