//Write a boolean expression that checks for given integer if it can be divided 
//(without remainder) by 7 and 5 in the same time.

using System;

class DivideBy5And7
{
    static void Main()
    {
        //  ако числото се дели едновременно на 5 и на 7 без остатък, тогава това число се дели и на 35 (5*7)

        int someNumber = 1120;
        // ако числото се дели и на 5 и 7
        if( someNumber % 35 == 0 )
        {
            Console.WriteLine("{0} divides by 5 and 7 without remainder!", someNumber);
        }
        // ако числото се дели само на 5
        // ако се стигне до тази проверка, въведеното число може да се дели само на едно от двете числа или на нито едно
        else if( someNumber % 5 == 0 )
        {
            Console.WriteLine("{0} only divides by 5 without remainder!", someNumber);
        }
        // ако числото се дели само на 7:
        else if( someNumber % 7 == 0 )
        {
            Console.WriteLine("{0} only divides by 7 without remainder!", someNumber);
        }
        // ако числото не се дели на 5 или 7 се изпълнява следния код:
        else
        {
            Console.WriteLine("{0} does not divide by 5 nor 7 without remainder!", someNumber);
        }
    }
}

