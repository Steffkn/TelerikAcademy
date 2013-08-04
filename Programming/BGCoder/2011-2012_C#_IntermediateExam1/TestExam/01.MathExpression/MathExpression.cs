using System;
class MathExpression
{
    static void Main()
    {
        decimal N = decimal.Parse(Console.ReadLine());
        decimal M = decimal.Parse(Console.ReadLine());
        decimal P = decimal.Parse(Console.ReadLine());
        decimal answer;
        answer = ((N * N + (1 / (M * P)) + 1337)
            / (decimal)(N - 128.523123123M * P)) +
            (decimal)Math.Sin((int)(M % 180));

        Console.WriteLine("{0:0.000000}", answer);
    }
}