namespace Methods
{
    using System;

    /// <summary>
    /// Methods that should be fixed
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Calculate the are of a triangle
        /// </summary>
        /// <param name="a">Side 'a'</param>
        /// <param name="b">Side 'b'</param>
        /// <param name="c">Side 'c'</param>
        /// <returns>Returns the area of the triangle</returns>
        public static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double s = (a + b + c) / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        public static string NumberToWordPresentation(int number)
        {
            string result = string.Empty;
            switch (number)
            {
                case 0: result = "zero";
                    break;
                case 1: result = "one";
                    break;
                case 2: result = "two";
                    break;
                case 3: result = "three";
                    break;
                case 4: result = "four";
                    break;
                case 5: result = "five";
                    break;
                case 6: result = "six";
                    break;
                case 7: result = "seven";
                    break;
                case 8: result = "eight";
                    break;
                case 9: result = "nine";
                    break;
                default:
                    throw new ArgumentException("Invalid number! The number should be from 0 to 9!");
            }

            return result;
        }

        public static int FindMaxElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException(string.Format("Empty array {0}", elements));
            }

            int maxElement = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        public static void PrintAsPriceNumber(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercentage(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintAsNumberInFormat(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        public static bool IsHorizontal(double y1, double y2)
        {
            if (y1 == y2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsVertical(double x1, double x2)
        {
            if (x1 == x2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToWordPresentation(5));

            Console.WriteLine(FindMaxElement(5, -1, 3, 2, 14, 2, 3));

            PrintAsPriceNumber(1.3);
            PrintAsPercentage(0.75);
            PrintAsNumberInFormat(2.30);

            bool horizontal = false;
            bool vertical = false;

            horizontal = IsHorizontal(-1, 2.5);
            vertical = IsVertical(3, 3);

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student();
            peter.FirstName = "Peter";
            peter.LastName = "Ivanov";
            peter.BirthDay = new DateTime(1992, 03, 17);
            peter.OtherInfo = "From Sofia, born at " + peter.BirthDay.Day + "." + peter.BirthDay.Month + "." + peter.BirthDay.Year;

            Student stella = new Student();
            stella.FirstName = "Stella";
            stella.LastName = "Markova";
            stella.BirthDay = new DateTime(1993, 11, 03);
            stella.OtherInfo = "From Sofia, born at " + stella.BirthDay.Day + "." + stella.BirthDay.Month + "." + stella.BirthDay.Year;

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
