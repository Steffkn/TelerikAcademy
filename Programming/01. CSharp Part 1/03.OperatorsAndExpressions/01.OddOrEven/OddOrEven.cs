// Write an expression that checks if given integer is odd or even.

using System;
class OddOrEven
{
    static void Main()
    {
        // декларираме си едно число (в случая 5 нечетно)
        int oddNumber = 5;

        // проверяваме дали числото не е нула!
        if( oddNumber == 0 )
        {
            Console.WriteLine("{0} is not odd nor even!", oddNumber);
        }
        // проверяваме дали числото се дели на 2 с остатък!
        else if( oddNumber % 2 != 0 )
        {
            Console.WriteLine("{0} is odd", oddNumber);
        }
        // ако горните 2 условия не са истина => числото е четно
        else
        {
            Console.WriteLine("{0} is even", oddNumber);
        }
    }
}

