// Write an expression that checks for given point (x, y) 
// if it is within the circle K( (1,1), 3) 
// and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

class PointInCircle
{
    static void Main()
    {
        // кръг с център (1;1) и радиус 3
        int CircleX = 1;
        int CircleY = 1;
        int CircleRadius = 3;

        // четириъгълник с точка (1;-1) (top left)
        // височина = 2 и дължина = 6
        int RectangleX = 1;
        int RectangleY = -1;
        int RecHeight = 2;
        int RecWidth = 6;

        // point (2;2)
        int PointX = 2;
        int PointY = 2;

        // променливи с който да отчетем дали точката е в кръгът и четириъгълника
        bool InCircle;
        bool InRectangle;

        // използваме питагорова теорема (без коренуване зада се спести процесорно време) 
        // кръгът е с център (1;1) и радиус 3 => х*х + у*у трябва да бъде по малко от 3*3 
        if( CircleX * CircleX + CircleY * CircleY < 9 )
        {
            Console.WriteLine("The point ({0};{1}) is within the circle at ({2};{3}) with radius {4}!", PointX, PointY, CircleX, CircleY, CircleRadius);
            InCircle = true;
        }
        else
        {
            Console.WriteLine("The point ({0};{1}) is NOT within the circle at ({2};{3}) with radius {4}!", PointX, PointY, CircleX, CircleY, CircleRadius);
            InCircle = false;
        }

        // приравняваме към (0;0) и сравняваме. Ако е вътре InRectangle става true
        if( ( ( PointX - RectangleX ) <= RecWidth ) && ( ( PointY - RectangleY ) <= RecHeight ) )
        {
            Console.WriteLine("The point ({0};{1}) is in the rectangle at ({2};{3}) with height = {4} and width = {5} !", PointX, PointY, RectangleX, RectangleY, RecHeight, RecWidth);
            InRectangle = true;
        }
        else
        {
            Console.WriteLine("The point ({0};{1}) is NOT in the rectangle at ({2};{3}) with height = {4} and width = {5} !", PointX, PointY, RectangleX, RectangleY, RecHeight, RecWidth);
            InRectangle = false;
        }

        // Обобщение
        if( InCircle && !InRectangle )
        {
            Console.WriteLine("The point ({0};{1}) is the one we are searching for!", PointX, PointY);
        }
        else
        {
            Console.WriteLine("The point ({0};{1}) is NOT the one we are searching for!", PointX, PointY);
        }
    }
}
