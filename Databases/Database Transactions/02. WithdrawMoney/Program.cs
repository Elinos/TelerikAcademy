using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ATMModel;

namespace _02.WithdrawMoney
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal cash = 200;
            ATMEntities context = new ATMEntities();
            TransactionScope tran = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead });

            using (tran)
            {
                var account = context.CardAccounts.Where(x => x.Id == 1).First();
                if (CheckCardPIN(account.CardPIN) && CheckCardNumber(account.CardNumber) && account.CardCash >= cash)
                {
                    account.CardCash -= cash;
                    context.TranscationsHistories.Add(
                        new TranscationsHistory()
                    {
                        CardNumber = account.CardNumber,
                        TranscationDate = DateTime.Now,
                        Amount = account.CardCash
                    });

                    context.SaveChanges();
                    tran.Complete();
                }
            }
        }

        public static bool CheckCardPIN(string pin)
        {
            int num;
            if (int.TryParse(pin, out num))
            {
                if (num < 1000 || num > 9999)
                {
                    return false;
                }

                int pow = 1;

                for (int i = 0; i < 3; i++)
                {
                    int digit = (num / pow) % 10;
                    for (int j = i + 1; j < 4; j++)
                    {
                        pow *= 10;
                        if (digit == (num / pow) % 10)
                        {
                            return false;
                        }
                    }

                    pow /= (int)Math.Pow(10, 4 - i - 2);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckCardNumber(string cardNumber)
        {
            int num;
            if (int.TryParse(cardNumber, out num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
