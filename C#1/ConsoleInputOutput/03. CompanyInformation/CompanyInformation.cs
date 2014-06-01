using System;

class CompanyInformation
{
    static void Main()
    {
        string[] labels = { "company name",
                            "address",
                            "phone number",
                            "fax number",
                            "website",
                            "manager first name",
                            "manager last name",
                            "manager age",
                            "manager phone number"};
        string[] data = new String[9];

        for (int i = 0; i < 9; i++)
        {
            Console.Write("Enter {0}: ", labels[i]);
            data[i] = Console.ReadLine();
        }
        Console.WriteLine("\nCompany Information: ");
        for (int i = 0; i < 9; i++)
        {
            char[] cLabel = labels[i].ToCharArray();
            cLabel[0] = char.ToUpper(cLabel[0]);
            Console.WriteLine(new string(cLabel) + ": " + data[i]);
        }
    }
}
