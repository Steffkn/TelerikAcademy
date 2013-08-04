// Write a program that calculates the greatest common divisor (GCD) of given two numbers.
// Use the Euclidean algorithm (find it in Internet).

using System;

class GreatestCommonDivisor
{
    static void Main()
    {
        int A = 0, B = 0;
        bool flag;
        do
        {
            // input with checking for correct values
            Console.WriteLine("Calculating the greatest common divisor of A and B");
            Console.WriteLine("Enter A");
            string line = Console.ReadLine();
            flag = int.TryParse(line, out A);
            if( flag )
            {
                A = int.Parse(line);
                if( A == 0 )
                {
                    Console.WriteLine("A cant be zero!");
                    flag = false;
                }
                else
                {
                    // entering B
                    Console.WriteLine("Enter B");
                    line = Console.ReadLine();
                    flag = int.TryParse(line, out B);
                    if( flag )
                    {
                        B = int.Parse(line);
                        if( B == 0 )
                        {
                            Console.WriteLine("B cant be zero!");
                            flag = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect value!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorect value!");
            }
        } while( flag == false );

        int remainder;
        int tempA;  // saving the real A and B
        int tempB;

        tempA = A;
        tempB = B;
        do
        {
            remainder = tempA % tempB;
            if( remainder == 0 )
            {
                remainder = tempB;
                break;
            }
            else
            {
                tempA = tempB;
                tempB = remainder;
                if( ( tempA % tempB ) <= 0 )
                {
                    break;
                }
            }
        } while( true );
        Console.WriteLine("The greatest common divisor of {0} and {1} is {2}", A, B, remainder);
    }
}

