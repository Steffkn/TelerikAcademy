
public class Worker : Human
{
    private uint weekSalary;
    private uint workHoursPerDay;

    public uint WeekSalary
    {
        get { return weekSalary; }
        set { weekSalary = value; }
    }

    public uint WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set { workHoursPerDay = value; }
    }

    public Worker(string firstName, string lastName, uint weekSalary, uint workHoursPerDay) : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public decimal MoneyPerHour()
    {
        return (decimal)(weekSalary / 7) / WorkHoursPerDay;
    }
}
