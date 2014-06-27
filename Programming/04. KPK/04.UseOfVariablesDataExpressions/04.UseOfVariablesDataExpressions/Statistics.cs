using System;

class Statistics
{
    static void Main(string[] args)
    {
    }

    public void PrintStatistics(double[] dataArray, int count)
    {
        double maxValue = 0;
        for (int i = 0; i < count; i++)
        {
            if (dataArray[i] > maxValue)
            {
                maxValue = dataArray[i];
            }
        }

        PrintMax(maxValue);

        double minValue = 0;
        for (int i = 0; i < count; i++)
        {
            if (dataArray[i] < minValue)
            {
                minValue = dataArray[i];
            }
        }

        PrintMin(minValue);

        double total = 0;
        for (int i = 0; i < count; i++)
        {
            total += dataArray[i];
        }

        PrintAvg(total / count);
    }

    private void PrintAvg(double p)
    {
        throw new NotImplementedException();
    }

    private void PrintMin(double maxValue)
    {
        throw new NotImplementedException();
    }

    private void PrintMax(double maxValue)
    {
        throw new NotImplementedException();
    }


}
