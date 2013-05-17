using System;

class BankAccount
{
    static void Main()
    {
        string firstName;
        string middleName;
        string lastName;
        double accountBalance;
        string bankName;
        string iban;
        string bicCode;
        long firstCreditCardNumber;
        long secondCreditCardNumber;
        long thirdCreditCardNumber;

        firstName = "Ivan";
        middleName = "Pehlivanov";
        lastName = "Gochev";
        accountBalance = 35467.45;
        bankName = "DSK Bank";
        iban = "BG27STSA93000019730665";
        bicCode = "STSABGSF";
        firstCreditCardNumber = 3567294524569856L;
        secondCreditCardNumber = 9824173427458724L;
        thirdCreditCardNumber = 1456982584562356L;

        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("|Account details of Mr. /Ms. {0} {1} {2} |", firstName, middleName, lastName);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Bank Name: {0}", bankName);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("IBAN: {0}", iban);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("BIC Code: {0}", bicCode);
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Credit Cards Numbers:");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("{0}\n{1}\n{2}", firstCreditCardNumber.ToString("#### #### #### ####"), secondCreditCardNumber.ToString("#### #### #### ####"), thirdCreditCardNumber.ToString("#### #### #### ####"));
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("Balance: {0} EUR", accountBalance);
        Console.WriteLine("-----------------------------------------------------");


    }
}

