using System;
class BitBall
{
    static void Main()
    {
        int[,] teamT = new int[8, 8];
        int[,] teamB = new int[8, 8];
        int scoreT = 0;
        int scoreB = 0;
        for (int i = 0; i < 8; i++)
        {
            int player = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                teamT[i, j] = player & 1;
                player >>= 1;
            }
        }

        for (int i = 0; i < 8; i++)
        {
            int player = int.Parse(Console.ReadLine());
            for (int j = 7; j >= 0; j--)
            {
                teamB[i, j] = player & 1;
                player >>= 1;
            }
        }


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (teamT[i, j] == 1 && teamT[i, j] == teamB[i, j])
                {
                    teamT[i, j] = 0;
                    teamB[i, j] = 0;
                }
            }
        }


        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (teamT[j, i] == 1)
                {
                    for (int x = j; x < 8; x++)
                    {
                        if (teamB[x, i] == 1)
                        {
                            teamB[x, i] = 0;
                            for (int z = x; z >= 0; z--)
                            {
                                if (teamT[z, i] == 1)
                                {
                                    teamT[z, i] = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        //for( int i = 0; i < 8; i++ )
        //{
        //    for( int j = 0; j < 8; j++ )
        //    {
        //        Console.Write("{0} ", teamT[i, j]);
        //    }
        //    Console.WriteLine();
        //}

        //Console.WriteLine();
        //for( int i = 0; i < 8; i++ )
        //{
        //    for( int j = 0; j < 8; j++ )
        //    {
        //        Console.Write("{0} ", teamB[i, j]);
        //    }
        //    Console.WriteLine();
        //}
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (teamB[j, i] == 1)
                {
                    scoreB++;
                    break;
                }

            }
            for (int j = 0; j < 8; j++)
            {
                if (teamT[j, i] == 1)
                {
                    scoreT++;
                    break;
                }

            }
        }
        Console.WriteLine("{0}:{1}", scoreT, scoreB);
        //for( int i = 0; i < 8; i++ )
        //{
        //    for( int j = 0; j < 8; j++ )
        //    {
        //        Console.Write("{0} ", teamB[i, j]);
        //    }
        //    Console.WriteLine();
        //}
    }
}