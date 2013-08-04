// Write a program that reads the coefficients a, b and c of a quadratic 
// equation ax2+bx+c=0 and solves it (prints its real roots).

using System;
class SolvingQuadraticEquation
{
    static void Main()
    {

        double a;
        double b;
        double c;
        Console.WriteLine("Enter a,b,c of the equation a*x*x + b*x + c = 0");
        Console.Write("a = ");
        // checking if the input is a digit
        if( double.TryParse(Console.ReadLine(), out a) )
        {

            Console.Write("b = ");
            if( double.TryParse(Console.ReadLine(), out b) )
            {
                Console.Write("c = ");
                if( double.TryParse(Console.ReadLine(), out c) )
                {
                    // determinanta
                    double D = b * b - 4 * a * c;
                    if( D < 0 )
                    {
                        // if D is less than 0, we dont have real roots
                        Console.WriteLine("There aren't any real roots");
                    }
                    else if( D == 0 )
                    {
                        // if D = 0, thre is 1 real root
                        Console.WriteLine("There is only one double root x = {0}", -b / ( 2 * a ));
                    }
                    else
                    {
                        // if D is greater than 0, there are two real roots that we can find
                        D = Math.Sqrt(D);
                        Console.WriteLine("x1 = {0}", (double)( -b + D ) / ( 2 * a ));
                        Console.WriteLine("x2 = {0}", (double)( -b - D ) / ( 2 * a ));
                    }
                }
                else
                {
                    // if c is no a valid number we will see this line at the console
                    Console.WriteLine("Invalid input for \"c\"! (Numbers only)");
                }
            }
            else
            {
                // if b is no a valid number we will see this line at the console
                Console.WriteLine("Invalid input for \"b\"! (Numbers only)");
            }
        }
        else
        {
            // if a is no a valid number we will see this line at the console
            Console.WriteLine("Invalid input for \"a\"! (Numbers only)");
        }

    }

}
