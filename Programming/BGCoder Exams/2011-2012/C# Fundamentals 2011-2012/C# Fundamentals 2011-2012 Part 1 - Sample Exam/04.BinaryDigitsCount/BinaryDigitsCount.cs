using System;
class BinaryDigitsCount
{
    static void Main()
    {
        byte B = byte.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        uint[] sequence = new uint[N];

        for (int i = 0; i < N; i++)
        {
            sequence[i] = uint.Parse(Console.ReadLine());
        }

        for (int i = 0; i < N; i++)
        {
            int counter = 0;
            byte bit;
            while (sequence[i] != 0)
            {
                bit = (byte)(sequence[i] & 1);
                sequence[i] = sequence[i] >> 1;
                if (bit == B)
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}