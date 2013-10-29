using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Customer is CompanyCustomer)
            {
                return base.CalculateInterest(Math.Max(months - 2, 0));
            }
            else if (this.Customer is IndividualCustomer)
            {
                return base.CalculateInterest(Math.Max(months - 3, 0));
            }
            return base.CalculateInterest(months);
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
