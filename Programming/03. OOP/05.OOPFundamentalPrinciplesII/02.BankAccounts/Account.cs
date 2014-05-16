
public abstract class Account : IDepositable
{
    // fields
    private string customer;
    private decimal balance;
    private double interestRate;
    private bool isCompany;

    // properties
    public bool IsCompany
    {
        get { return isCompany; }
        set { isCompany = value; }
    }

    public string Customer
    {
        get { return customer; }
        set { customer = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public double InterestRate
    {
        get { return interestRate; }
        set { interestRate = value; }
    }

    /// <summary>
    /// Constructor that takes all the needed information for the customer
    /// </summary>
    /// <param name="customer">Name of the customer</param>
    /// <param name="balance">Customers balanes</param>
    /// <param name="interestRate">Interest rate</param>
    /// <param name="isCompany">True if is a compani, false if is individual</param>
    public Account(string customer, decimal balance, double interestRate, bool isCompany)
    {
        this.Customer = customer;
        this.Balance = balance;
        this.InterestRate = interestRate;
        this.IsCompany = isCompany;
    }

    /// <summary>
    /// Abstract method for deposit in the bank. All accounts can do this.
    /// </summary>
    /// <param name="depositMoney"></param>
    public abstract void Deposit(decimal depositMoney);

    /// <summary>
    /// Abstract method that is used to calculate the Interest of the account
    /// </summary>
    /// <param name="monts">Monts</param>
    /// <returns>Returns the Interest of the user (depents on the account type and if it is a compani or individual customer)</returns>
    public abstract double Interest(uint monts);
}

