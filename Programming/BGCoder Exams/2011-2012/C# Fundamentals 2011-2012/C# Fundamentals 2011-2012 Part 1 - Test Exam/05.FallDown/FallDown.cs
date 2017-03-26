using System;
class FallDown
{
    static void Main()
    {
        int n0 = int.Parse(Console.ReadLine());
        int n1 = int.Parse(Console.ReadLine());
        int n2 = int.Parse(Console.ReadLine());
        int n3 = int.Parse(Console.ReadLine());
        int n4 = int.Parse(Console.ReadLine());
        int n5 = int.Parse(Console.ReadLine());
        int n6 = int.Parse(Console.ReadLine());
        int n7 = int.Parse(Console.ReadLine());
        int temp;

        for (int i = 0; i < 8; i++)
        {
            temp = n7;
            n7 |= n6;
            n6 &= temp;

            temp = n6;
            n6 |= n5;
            n5 &= temp;

            temp = n5;
            n5 |= n4;
            n4 &= temp;

            temp = n4;
            n4 |= n3;
            n3 &= temp;

            temp = n3;
            n3 |= n2;
            n2 &= temp;

            temp = n2;
            n2 |= n1;
            n1 &= temp;

            temp = n1;
            n1 |= n0;
            n0 &= temp;


        }

        Console.WriteLine(n0);
        Console.WriteLine(n1);
        Console.WriteLine(n2);
        Console.WriteLine(n3);
        Console.WriteLine(n4);
        Console.WriteLine(n5);
        Console.WriteLine(n6);
        Console.WriteLine(n7);
    }
}