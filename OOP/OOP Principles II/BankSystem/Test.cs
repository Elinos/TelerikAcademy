using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankSystem
{
    class Test
    {
        static void Main(string[] args)
        {
            Bank fib = new Bank("First Investment Bank");
            IndividualCustomer pesho = new IndividualCustomer("Pesho");
            DepositAccount depositAccount = new DepositAccount(pesho, 2M, 0.05m);
            fib.AddCustomer(pesho);
            fib.AddAccount(depositAccount);

            depositAccount.Deposit(1000M);

            Console.WriteLine("Current blanace: " + depositAccount.Balance);

            Console.WriteLine("Interest amount: " + depositAccount.CalculateInterest(23));

            depositAccount.Withdraw(153.03M);
            Console.WriteLine("Current blanace: " + depositAccount.Balance);
        }
    }
}
