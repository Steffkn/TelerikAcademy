//Write a method that adds two polynomials. 
//Represent them as arrays of their coefficients as in the example below:
//        x*x + 5 = 1x*x + 0x + 5 -> [5] [0] [1]

using System;
class AddTwoPolynomials
{
    static void Main()
    {
        Console.WriteLine("Enter two polynoms and the operation between them \n(example of a polynom: 2*x*x*x + 11*x*x - 11*x*x - 4*x - x*x*x + x  - 15)");
        Console.Write("Enter first polynom: ");
        string firstPolynom = Console.ReadLine();
        Console.Write("Enter second polynom: ");
        string secondPolynom = Console.ReadLine();

        int[] result = AddPolynomials(firstPolynom, secondPolynom, +1);
        // loop trough all the elements in the array result and print them on the console.
        for (int index = result.Length - 1; index >= 0; index--)
        {
            if (result[index] != 0)
            {
                Console.Write(" {0}", result[index]);
                for (int countX = 0; countX < index; countX++)
                {
                    Console.Write("*x");
                }
            }
        }
    }

    /// <summary>
    /// Method that makes the magic! Adds substracts or multyply two polynomials.
    /// </summary>
    /// <param name="firstPoly">String of the first polynom.</param>
    /// <param name="secondPoly">String of the second polynom.</param>
    /// <param name="sing">The sign determines the operation (+ - *)</param>
    /// <returns></returns>
    public static int[] AddPolynomials(string firstPoly, string secondPoly, int sing)
    {
        // take the polynomials as int arrays
        int[] firstPolyValues = ExtractIntegers(firstPoly);
        int[] secondPolyValues = ExtractIntegers(secondPoly);

        int[] result;

        // if the sing is equal to 0 we have devision
        if (sing == 0)
        {
            // the result array may have maximum firstPolyValues.Length * secondPolyValues.Length elements
            result = new int[firstPolyValues.Length * secondPolyValues.Length];

            for (int index = 0; index < firstPolyValues.Length; index++)
            {
                for (int i = 0; i < secondPolyValues.Length; i++)
                {
                    // multyply every element from the second poly with the elements of the first poly
                    result[index + i] += firstPolyValues[index] * secondPolyValues[i];
                }
            }
        }
        else
        {
            // else the sigh is + or -; it doesnt matter here
            // the result array takes the lenght of the array with max lenght
            result = new int[(firstPolyValues.Length > secondPolyValues.Length) ? 
                firstPolyValues.Length : secondPolyValues.Length];
            // loop trough the elements and add/sum them to the result *1 or * ( - 1)
            for (int index = 0; index < result.Length; index++)
            {
                result[index] = firstPolyValues[index] + secondPolyValues[index] * sing;
            }
        }
        // return the result
        return result;
    }

    /// <summary>
    /// Method that converts a string of a polynom into array of integers.
    /// </summary>
    /// <param name="polynomial">String with the polynom.</param>
    /// <returns>Returns an array of integers, holding every number of the polinom in ints place.</returns>
    public static int[] ExtractIntegers(string polynomial)
    {
        // converting the string in lower case; just in case
        polynomial = polynomial.ToLower();
        // the polynoms could not be with more than 20 parts
        int[] polyValues = new int[20];
        // vleaning the string from spaces and stars
        polynomial = polynomial.Replace(" ", "");
        polynomial = polynomial.Replace("*", "");
        // replasing -x with -1x ; there is no star because we have already cleaned them from the string!
        // replasing x with 1x
        // this will help for the calculations and will define the look of the polynomial string
        polynomial = polynomial.Replace("-x", "-1x");
        polynomial = polynomial.Replace("+x", "+1x");

        // adding some spaces to the string; this will help for the next step!
        polynomial = polynomial.Replace("x", " x ");

        // separating the string by spaces
        string[] separate = polynomial.Split(' ');

        // now we have everything in its own sell; numbers(with signs), x's
        int counter = 0;
        // loop trough all the elements
        for (int index = separate.Length - 1; index >= 0; index--)
        {
            // temp holds the number
            int temp;
            if (int.TryParse(separate[index], out temp))
            {
                // if its not a zero
                if (temp != 0)
                {
                    // put temp's value at polyValues[counter]
                    polyValues[counter] += temp;
                    // and reset the counter
                    counter = 0;
                }
            }
                // if the read element is a "x" add 1 to the counter
            else if (separate[index].Equals("x"))
            {
                counter++;
            }
        }
        // return the array;
        return polyValues;
    }
}

