using System;

namespace ShipDamage
{
    class Program
    {
        static void Main()
        {
            // SX1, SY1, SX2, SY2, H, CX1, CY1, CX2, CY2, CX3, and CY3. 
            int shipX1 = Convert.ToInt32(Console.ReadLine());
            int shipY1 = Convert.ToInt32(Console.ReadLine());
            int shipX2 = Convert.ToInt32(Console.ReadLine());
            int shipY2 = Convert.ToInt32(Console.ReadLine());

            int H = Convert.ToInt32(Console.ReadLine());

            int cannonX1 = Convert.ToInt32(Console.ReadLine());
            int cannonY1 = Convert.ToInt32(Console.ReadLine());

            int cannonX2 = Convert.ToInt32(Console.ReadLine());
            int cannonY2 = Convert.ToInt32(Console.ReadLine());

            int cannonX3 = Convert.ToInt32(Console.ReadLine());
            int cannonY3 = Convert.ToInt32(Console.ReadLine());

            int dmg = 0;

            cannonY1 = H - cannonY1 + H;
            cannonY2 = H - cannonY2 + H;
            cannonY3 = H - cannonY3 + H;

            int shipTopLeftY = shipY1 > shipY2 ? shipY1 : shipY2;
            int shipTopLeftX = shipX1 > shipX2 ? shipX2 : shipX1;
            int shipBotRightY = shipY1 > shipY2 ? shipY2 : shipY1;
            int shipBotRightX = shipX1 > shipX2 ? shipX1 : shipX2;

            int cY = cannonY1;
            int cX = cannonX1;


            if (shipTopLeftY > cY && shipBotRightY < cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 100;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 50;
                }
            }
            else if (shipTopLeftY == cY || shipBotRightY == cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 50;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 25;
                }
            }

            cY = cannonY2;
            cX = cannonX2;
            if (shipTopLeftY > cY && shipBotRightY < cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 100;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 50;
                }
            }
            else if (shipTopLeftY == cY || shipBotRightY == cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 50;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 25;
                }
            }

            cY = cannonY3;
            cX = cannonX3;
            if (shipTopLeftY > cY && shipBotRightY < cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 100;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 50;
                }
            }
            else if (shipTopLeftY == cY || shipBotRightY == cY)
            {
                if (shipTopLeftX < cX && shipBotRightX > cX)
                {
                    dmg += 50;
                }
                else if (shipTopLeftX == cX || shipBotRightX == cX)
                {
                    dmg += 25;
                }
            }

            Console.WriteLine("{0}%", dmg);
        }
    }
}
