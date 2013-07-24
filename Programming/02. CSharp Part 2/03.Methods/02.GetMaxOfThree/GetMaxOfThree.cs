// Write a method GetMax() with two parameters that returns the bigger of two integers.
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;
class GetMaxOfThree
{
    static void Main()
    {
        Console.WriteLine("Enter three integers: ");
        int firstInt = int.Parse(Console.ReadLine());
        int secondInt = int.Parse(Console.ReadLine());
        int thirdInt = int.Parse(Console.ReadLine());

        // calling the function in it selft
        Console.WriteLine("The biggest of these three is {0}",
            GetMax(
                    GetMax(firstInt, secondInt),    // this line will find the biggest from first and second integer
                    thirdInt)
                    ); // this function will compare the result from the inner function with the third integer

    }

    public static int GetMax(int a, int b)
    {
        return a > b ? a : b;
    }
}

