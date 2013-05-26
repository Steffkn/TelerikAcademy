// Which of the following values 
// can be assigned to a variable of type float 
// and which to a variable of type double: 
// 34.567839023, 12.345, 8923.1234857, 3456.091?

using System;

class FloatOrDouble
{
    static void Main()
    {
        // въвеждане на подходящи типове за дадените числа
        double firstValue = 34.567839023;
        float secondValue = 12.345f;
        double thirdValue = 8923.1234857;
        float fourthValue = 3456.091f;

        // изчеждане на екрана на променливите
        Console.WriteLine(firstValue);
        Console.WriteLine(secondValue);
        Console.WriteLine(thirdValue);
        Console.WriteLine(fourthValue);
    }
}

