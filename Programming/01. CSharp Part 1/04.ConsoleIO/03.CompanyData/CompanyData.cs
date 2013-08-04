// A company has name, address, phone number, fax number, web site and manager. 
// The manager has first name, last name, age and a phone number. 
// Write a program that reads the information about a company and its manager and prints them on the console.

using System;

class CompanyData
{
    static void Main()
    {
        Console.Write("Company name:");
        string companyName = Console.ReadLine();

        Console.Write("Company address:");
        string companyAddress = Console.ReadLine();

        Console.Write("Company phone number:");
        string companyPhone = Console.ReadLine();
        long companyPhoneNumb = long.Parse(companyPhone);

        Console.Write("Company fax:");
        string companyFax = Console.ReadLine();
        long companyFaxNumb = long.Parse(companyFax);

        Console.Write("Company web site:");
        string companyWeb = Console.ReadLine();

        Console.WriteLine("Company Info:");
        Console.WriteLine("Company manager: ");
        Console.Write("\tfirst name: ");
        string manFirstName = Console.ReadLine();
        Console.Write("\tlast name: ");
        string manLastName = Console.ReadLine();
        Console.Write("\tage: ");
        string manAge = Console.ReadLine();
        sbyte managerAge = sbyte.Parse(manAge);
        Console.Write("\tphone number: ");
        string manPhoneNumb = Console.ReadLine();
        long managerPhoneNumb = long.Parse(manPhoneNumb);

        Console.WriteLine("Company name: " + companyName);
        Console.WriteLine("Address: " + companyAddress);
        Console.WriteLine("Phone number: " + companyPhone);
        Console.WriteLine("Fax: " + companyFaxNumb);
        Console.WriteLine("Web site: " + companyWeb + Environment.NewLine);
        Console.WriteLine("Manager: {0} {1}", manFirstName, manLastName);
        Console.WriteLine("Age: " + managerAge);
        Console.WriteLine("Phone number: " + managerPhoneNumb);

    }
}