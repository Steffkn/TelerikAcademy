
namespace _2.AstrologicalDigits
{
    using System;

    class Program
    {
        static void Main()
        {
            string number = Console.ReadLine();
            double N = 0;
            int digit = 0;

            while (true)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (int.TryParse(number[i].ToString(), out digit))
                    {
                        N += digit;
                    }
                }

                if (N < 10)
                {
                    break;
                }

                number = N.ToString();
                N = 0;
            }

            Console.WriteLine(N);
        }
    }
}
