using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class DepositAccount : Account, IDepositable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterest(decimal months)
        {
            if (this.Balance < 1000 && this.Balance > 0)
            {
                return 0;
            }
            return base.CalculateInterest(months);
        }
    }
}
