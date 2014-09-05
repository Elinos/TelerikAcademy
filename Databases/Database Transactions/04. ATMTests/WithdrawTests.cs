using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ATMModel;
using System.Transactions;

namespace _04.ATMTests
{
    [TestClass]
    public class WithdrawTests
    {
        [TestMethod]
        public void WithdrawTo0()
        {
            decimal money = 1000;
            string number = "1111111111";
            string cardPin = "1111";

            using (ATMEntities context = new ATMEntities())
            {
                context.CardAccounts.Add(new CardAccount() { CardCash = money, CardNumber = number, CardPIN = cardPin });
                context.SaveChanges();

                TransactionScope tran = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead });

                using (tran)
                {
                    var account = context.CardAccounts.Where(x => x.CardNumber == number
                        && x.CardPIN == cardPin && x.CardCash == money).First();
                    if (account.CardCash >= money)
                    {
                        account.CardCash -= money;

                        context.SaveChanges();
                        tran.Complete();
                    }

                    context.SaveChanges();
                }

                var actual = (from c in context.CardAccounts
                              where c.CardNumber == number
                              && c.CardPIN == cardPin
                              select c).First();

                Assert.AreEqual(0, actual.CardCash);
            }
        }

        [TestMethod]
        public void WithdrawToLessThan0()
        {
            decimal money = 100;
            string number = "46346";
            string cardPin = "3456";

            using (ATMEntities context = new ATMEntities())
            {
                context.CardAccounts.Add(new CardAccount() { CardCash = money, CardNumber = number, CardPIN = cardPin });
                context.SaveChanges();

                TransactionScope tran = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.RepeatableRead });

                using (tran)
                {
                    var account = context.CardAccounts.Where(x => x.CardNumber == number
                        && x.CardPIN == cardPin && x.CardCash == money).First();
                    if (account.CardCash >= 2 * money)
                    {
                        account.CardCash -= 2 * money;

                        context.SaveChanges();
                        tran.Complete();
                    }

                    context.SaveChanges();
                }

                var acc = context.CardAccounts.Where(x => x.CardNumber == number && x.CardPIN == cardPin).First();
                Assert.AreEqual(money, acc.CardCash);
            }
        }
    }
}