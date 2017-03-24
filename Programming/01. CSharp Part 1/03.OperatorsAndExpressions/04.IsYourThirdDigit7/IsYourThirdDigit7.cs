// Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;
class IsYourThirdDigit7
{
    static void Main()
    {
        // декларираме променлива от тип int, която ще проверяваме
        int someDigit = 1732;

        // делим числото на 100 зада се получи ново число, чиято цифра на единиците ни интересува ( третата цифра от първоначално въведеното число)
        // след което взимаме остатъка от делението на 10 и го проверяваме дали е 7
        if( ((someDigit / 100) % 10) == 7 )
        {
            // ако е вярно => третата цифра на someDigit е 7
            Console.WriteLine(someDigit + " -> " + true);
        }
        // ако не вярно => третата цифра на someDigit е различна от 7
        else
        {
            Console.WriteLine(someDigit + " -> " + false);
        }
    }
}

