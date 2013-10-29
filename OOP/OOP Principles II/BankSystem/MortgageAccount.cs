using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Customer is CompanyCustomer)
            {
                return base.CalculateInterest(Math.Min(months, 12) / 2 + Math.Max(months - 12, 0));
            }
            else if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterest(Math.Max(months - 6, 0));
            }
            return base.CalculateInterest(months);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
