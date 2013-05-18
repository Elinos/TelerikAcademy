using System;

class RecordOfEmployees
{
    static void Main()
    {
        string firstName;
        string familyName;
        byte age;
        char gender;
        int idNumber;
        int employeeNumber;

        // Info for employee 
        firstName = "Doncho";
        familyName = "Stefanov";
        age = 27;
        gender = 'm'; // use 'm' or 'f'
        idNumber = 183739892;
        employeeNumber = 27565432;

        Console.WriteLine("This is the data for employee No. {0}", employeeNumber);
        Console.WriteLine("First name: {0}", firstName);
        Console.WriteLine("Family name: {0}", familyName);
        Console.WriteLine("Age: {0}", age);
        if (gender == 'm')
        {
            Console.WriteLine("Gender: Male");
        }
        else
        {
            Console.WriteLine("Gender: Female");
        }
        Console.WriteLine("ID Number: {0}", idNumber);
    }
}

