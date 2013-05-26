// Declare  two integer variables and assign them with 5 and 10 and 
// after that exchange their values.

using System;

class ValuesExchange
{
    static void Main()
    {
        int five = 5;
        int ten = 10;
        int temp;
        temp = five;
        five = ten;
        ten = temp;
        Console.WriteLine("Exchanged values \nfive: {0} \nten: {1} ", five, ten);
    }
}

