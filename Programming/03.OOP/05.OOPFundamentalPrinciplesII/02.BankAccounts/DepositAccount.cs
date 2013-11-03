
public class DepositAccount : Account, IWithDrawable
{
    // constructor
    public DepositAccount(string customerName, decimal balance, double interestRate, bool isCompani)
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
    /// Method that with draws money from the account
    /// </summary>
    /// <param name="withDrawMoney"></param>
    public void WithDraw(decimal withDrawMoney)
    {
        if (withDrawMoney <= 0) // or (withDrawMoney < 50) if the minimum with draw is 50 
        {
            System.Console.WriteLine("With draw money must be possitive value!");
        }
        else
        {
            // calculate the new balance
            this.Balance = this.Balance - withDrawMoney;
        }
    }

    /// <summary>
    /// Calculates the Interest of the account
    /// </summary>
    /// <param name="monts">Monts</param>
    /// <returns>Returns the interest or 0 depending on the balance of the account</returns>
    public override double Interest(uint monts)
    {
        if (this.Balance <= 0 || this.Balance >= 1000)
        {
            return monts * this.InterestRate;
        }
        else
        {
            return 0;
        }
    }
}

