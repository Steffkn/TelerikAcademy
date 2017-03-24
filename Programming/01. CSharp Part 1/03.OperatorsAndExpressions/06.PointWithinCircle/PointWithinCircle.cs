//Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;
class PointWithinCircle
{
    static void Main()
    {
        // декларираме променливи с кординати на дадена точка
        double pointX = 2;
        double pointY = 4;

        // използваме питагорова теорема (без коренуване зада се спести процесорно време) 
        // кръгът е с център (0;0) и радиус 5 => х*х + у*у трябва да бъде по малко от 5*5 
        if( pointX * pointX + pointY * pointY < 25 )
        {
            Console.WriteLine("The point ({0};{1}) is within a circle K(O, 5)!", pointX, pointY);
        }
        else
        {
            Console.WriteLine("The point ({0};{1}) is NOT within a circle K(O, 5)!", pointX, pointY);
        }
    }
}

