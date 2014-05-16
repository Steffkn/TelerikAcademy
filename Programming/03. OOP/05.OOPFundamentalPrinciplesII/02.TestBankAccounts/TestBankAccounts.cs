// A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts.
// Customers could be individuals or companies.
// All accounts have customer, balance and interest rate (monthly based). 
// Deposit accounts are allowed to deposit and with draw money. 
// Loan and mortgage accounts can only deposit money.
// All accounts can calculate their interest amount for a given period (in months). 
// In the common case its is calculated as follows: number_of_months * interest_rate.
// Loan accounts have no interest for the first 3 months if are held by individuals and for the first 2 months if are held by a company.
// Deposit accounts have no interest if their balance is positive and less than 1000.
// Mortgage accounts have 1/2 interest for the first 12 months for companies and no interest for the first 6 months for individuals.
   
//* Your task is to write a program to model the bank system by classes and interfaces. 
// You should identify the classes, interfaces, base classes and abstract actions and 
// implement the calculation of the interest functionality through overridden methods.

// NOTE: i dont really know anything about banking and all, but this is how i understood the task :)
using System;
class TestBankAccounts
{
    static void Main()
    {
        // make few accounts of type DepositAccount LoanAccount MortgageAccount
        DepositAccount depositStefan = new DepositAccount("Stefan", 1999, 2.3, false);
        DepositAccount depositMartin = new DepositAccount("Martin", 50, 1, true);

        LoanAccount loanTosho = new LoanAccount("Tosho", 1234, 2, false);
        LoanAccount loanGosho = new LoanAccount("Gosho", 4321, 2.3, true);

        MortgageAccount mortgageStoqn = new MortgageAccount("Stoqn", 50, 1.0, false);
        MortgageAccount mortgageVelizara = new MortgageAccount("Velizara EOOD", 100000, 4, true);

        // calculate all the interests....
        Console.WriteLine("Account interests");
        Console.WriteLine("Deposit accounts");
        Console.WriteLine(depositStefan.Interest(10));
        Console.WriteLine(depositMartin.Interest(2));

        Console.WriteLine("Loan accounts");
        Console.WriteLine(loanTosho.Interest(5));
        Console.WriteLine(loanGosho.Interest(2));

        Console.WriteLine("Mortgage accounts");
        Console.WriteLine(mortgageStoqn.Interest(1));
        Console.WriteLine(mortgageVelizara.Interest(12));
    }
}
