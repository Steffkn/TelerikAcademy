namespace _1.FighterAttack
{
    using System;

    class Program
    {
        static void Main()
        {
            int px1 = Convert.ToInt32(Console.ReadLine());
            int py1 = Convert.ToInt32(Console.ReadLine());
            int px2 = Convert.ToInt32(Console.ReadLine());
            int py2 = Convert.ToInt32(Console.ReadLine());
            int fx = Convert.ToInt32(Console.ReadLine());
            int fy = Convert.ToInt32(Console.ReadLine());
            int D = Convert.ToInt32(Console.ReadLine());

            int pTopLeftX = px1 < px2 ? px1 : px2;
            int pTopLeftY = py1 > py2 ? py1 : py2;

            int pBottomRightX = px1 > px2 ? px1 : px2;
            int pBottomRightY = py1 < py2 ? py1 : py2;

            int hitPointX = fx + D;
            int hitPointY = fy;

            int dmg = 0;

            if (hitPointX >= pTopLeftX && hitPointX <= pBottomRightX)
            {
                if (hitPointY <= pTopLeftY && hitPointY >= pBottomRightY)
                {
                    dmg += 100;
                }
            }

            if (hitPointX + 1 >= pTopLeftX && hitPointX + 1 <= pBottomRightX)
            {
                if (hitPointY <= pTopLeftY && hitPointY >= pBottomRightY)
                {
                    dmg += 75;
                }
            }

            if (hitPointX >= pTopLeftX && hitPointX <= pBottomRightX)
            {
                if (hitPointY + 1 <= pTopLeftY && hitPointY + 1 >= pBottomRightY)
                {
                    dmg += 50;
                }

                if (hitPointY - 1 <= pTopLeftY && hitPointY - 1 >= pBottomRightY)
                {
                    dmg += 50;
                }
            }

            Console.WriteLine("{0}%", dmg);
        }
    }
}
