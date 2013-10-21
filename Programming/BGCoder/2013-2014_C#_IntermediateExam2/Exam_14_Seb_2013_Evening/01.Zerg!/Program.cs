using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.Zerg_
{
    class Program
    {
        static void Main()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Console.ReadLine());
            //sb.Append("HsstSsstSsst");
            //sb.Append("GruhMyauDjav");

            string fifteen = TransformFromZerglish(sb.ToString());
            //Console.WriteLine(fifteen);

            BigInteger result = ConvertToDec(fifteen);

            Console.WriteLine(result);



        }

        static string TransformFromZerglish(string zergish)
        {
            zergish = zergish.Replace("Rawr", "0");
            zergish = zergish.Replace("Rrrr", "1");
            zergish = zergish.Replace("Hsst", "2");
            zergish = zergish.Replace("Ssst", "3");
            zergish = zergish.Replace("Grrr", "4");
            zergish = zergish.Replace("Rarr", "5");
            zergish = zergish.Replace("Mrrr", "6");
            zergish = zergish.Replace("Psst", "7");
            zergish = zergish.Replace("Uaah", "8");
            zergish = zergish.Replace("Uaha", "9");
            zergish = zergish.Replace("Zzzz", "A");
            zergish = zergish.Replace("Bauu", "B");
            zergish = zergish.Replace("Djav", "C");
            zergish = zergish.Replace("Myau", "D");
            zergish = zergish.Replace("Gruh", "E");

            return zergish;
        }


        static BigInteger ConvertToDec(string number)
        {
            BigInteger result = 0;
            for (int i = 0; i < number.Length; i++)
            {
                switch (number[i])
                {
                    case '0': result = result + 0 * PowerOf15(number.Length - i - 1); break;
                    case '1': result = result + 1 * PowerOf15(number.Length - i - 1); break;
                    case '2': result = result + 2 * PowerOf15(number.Length - i - 1); break;
                    case '3': result = result + 3 * PowerOf15(number.Length - i - 1); break;
                    case '4': result = result + 4 * PowerOf15(number.Length - i - 1); break;
                    case '5': result = result + 5 * PowerOf15(number.Length - i - 1); break;
                    case '6': result = result + 6 * PowerOf15(number.Length - i - 1); break;
                    case '7': result = result + 7 * PowerOf15(number.Length - i - 1); break;
                    case '8': result = result + 8 * PowerOf15(number.Length - i - 1); break;
                    case '9': result = result + 9 * PowerOf15(number.Length - i - 1); break;
                    case 'A': result = result + 10 * PowerOf15(number.Length - i - 1); break;
                    case 'B': result = result + 11 * PowerOf15(number.Length - i - 1); break;
                    case 'C': result = result + 12 * PowerOf15(number.Length - i - 1); break;
                    case 'D': result = result + 13 * PowerOf15(number.Length - i - 1); break;
                    case 'E': result = result + 14 * PowerOf15(number.Length - i - 1); break;
                    default: 
                        // !!!!!!!!!!!!!
                        break;
                }
            }

            return result;
        }

        static BigInteger PowerOf15(int power)
        {
            BigInteger result = 1;

            for (int i = 0; i < power; i++)
            {
                result *= 15;
            }

            return result;
        }

    }
}
