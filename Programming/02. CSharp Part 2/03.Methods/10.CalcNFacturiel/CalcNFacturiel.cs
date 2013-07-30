using System;
class CalcNFacturiel
{
    static void Main()
    {
        int[] givenArray = new int[2];
        givenArray[0] = 1;
        int[] tempArray;

        Console.WriteLine("Enter N in range [1:100] (the program should work for bigger values too :) )");
        Console.Write("N = ");
        int N = int.Parse(Console.ReadLine());

        for (int i = 1; i <= N; i++)
        {
            tempArray = MulliplyByN(givenArray, i);
            givenArray = tempArray;
        }
        bool firstDigit = false;

        Console.Write("N! = ");
        for (int index = givenArray.Length - 1; index >= 0; index--)
        {
            // clean/dont print the unneeded zeros infront of givenArray
            if (givenArray[index] != 0)
            {
                // untill givenArray[index] = 0, firstDigit will stay false
                firstDigit = true;
            }
            if (firstDigit)
            {
                // print the value from the givenArray[index[ on the console
                Console.Write("{0}", givenArray[index]);
            }
        }
        Console.WriteLine();
    }


    public static int[] MulliplyByN(int[] array, int N)
    {
        int[] helpArray;

        // nested if's that will determin how big will be the helpArray;
        // the point is that the helpArray should have atleast 2 more zeros (empty sells) than array
        if (array[array.Length - 2] != 0 || array[array.Length - 1] != 0)
        {
            if (array[array.Length - 1] != 0)
            {
                helpArray = new int[array.Length + 2];
            }
            else
            {
                helpArray = new int[array.Length + 1];
            }
        }
        // else array[lenght-1] = 0 and array[lengt - 2] = 0;
        else
        {
            helpArray = new int[array.Length];
        }

        // multiply every sell of array with N and write the product in helpArray
        for (int index = 0; index < array.Length; index++)
        {
            helpArray[index] = array[index] * N;
        }

        // add the reminding from the product to the sell left of helpArray[index]
        for (int index = 0; index < helpArray.Length - 1; index++)
        {
            // if the sell has value bigger than 9
            if (helpArray[index] >= 10)
            {
                // add to the sell to the left, the digit that remind after helpArray[index] is devided by 10
                // ex: helpArray[index] = 24
                // helpArray[index + 1] will be equzl to helpArray[index + 1] + 24/10 => helpArray[index + 1] + 2
                // helpArray[index] will be equal to 4
                helpArray[index + 1] += helpArray[index] / 10;
                helpArray[index] %= 10;
            }
        }

        return helpArray;
    }
}

