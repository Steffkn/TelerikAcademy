namespace WeAllLoveBits
{
    using System;

    class Program
    {
        static void Main()
        {
            int N = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                int p = Convert.ToInt32(Console.ReadLine()); ;
                string pBin = Convert.ToString(p, 2);
                string pDashBin = pBin.Replace('1', '2');
                pDashBin = pDashBin.Replace('0', '1');
                pDashBin = pDashBin.Replace('2', '0');


                char[] charArray = pBin.ToCharArray();
                Array.Reverse(charArray);

                string pDotBin = new string(charArray);


                int pDash = Convert.ToInt32(pDashBin, 2);
                int pDot = Convert.ToInt32(pDotBin, 2);

                Console.WriteLine((p ^ pDash) & pDot);
            }
        }
    }
}
