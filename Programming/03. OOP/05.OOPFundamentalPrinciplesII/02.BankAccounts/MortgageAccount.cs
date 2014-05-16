//Loan accounts have no interest for the first 3 months if are held by individuals 
//and for the first 2 months if are held by a company.

public class MortgageAccount : Account
{
    public MortgageAccount(string customerName, decimal balance, double interestRate, bool isCompani)
        : base(customerName, balance, interestRate, isCompani)
    {

    }

    /// <summary>
    /// Overrite the method deposit
    /// </summary>
    /// <param name="depositMoney">The amount of money the customer wants to deposit</param>
    public override void Deposit(decimal depositMoney)
    {
        // id the user enters negative or zero number
        if (depositMoney <= 0) // or (depositMoney < 50) if the minimum deposit is 50 
        {
            System.Console.WriteLine("Deposit money must be possitive value!");
        }
        else
        {
            // calculate the new balance
            this.Balance = this.Balance + depositMoney;
        }
    }

    /// <summary>
    /// Calculates the Interest of the account
    /// </summary>
    /// <param name="monts">Monts</param>
    /// <returns>Returns the interest or 0 depending on the account's owner and the monts that have passed</returns>
    public override double Interest(uint monts)
    {
        if (IsCompany && monts <= 12)
        {
            return (monts * this.InterestRate) / 2;
        }
        else if (!IsCompany && monts <= 6)
        {
            return 0;
        }
        else
        {
            return monts * this.InterestRate;
        }

    }
}
