using System;

class Ball
{
    public Ball(Ball ball)
    {
        this.width = ball.width;
        this.height = ball.height;
        this.depth = ball.depth;
    }
    public Ball(int width, int height, int depth)
    {
        this.width = width;
        this.height = height;
        this.depth = depth;
    }
    public int width { get; set; }
    public int height { get; set; }
    public int depth { get; set; }
}

class Program
{
    private static int width, height, depth;
    private static string[, ,] cuboid;
    private static Ball cubeBall;

    static void Main()
    {
        ReadInpu();
        CommandTheBall();
    }

    private static void CommandTheBall()
    {
        while (true)
        {
            string currentSell = cuboid[cubeBall.width, cubeBall.height, cubeBall.depth];

            string[] commands = currentSell.Split(' ');

            switch (commands[0])
            {
                case "S":
                    BallSlides(commands[1]);
                    break;
                case "B":
                    PrintMessage();
                    return;
                case "T":
                    cubeBall.width = int.Parse(commands[1]);
                    cubeBall.depth = int.Parse(commands[2]);
                    break;
                case "E":
                    if (cubeBall.height == height - 1)
                    {
                        PrintMessage();
                        return;
                    }
                    else
                    {
                        cubeBall.height++;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid command!");

            }

        }
    }

    private static void BallSlides(string direction)
    {
        Ball newBall = new Ball(cubeBall);
        for (int index = 0; index < direction.Length; index++)
        {
            if (direction[index] == 'L')
            {
                newBall.width--;
            }
            else if (direction[index] == 'R')
            {
                newBall.width++;
            }
            else if (direction[index] == 'F')
            {
                newBall.depth--;
            }
            else if (direction[index] == 'B')
            {
                newBall.depth++;
            }
            else
            {
                throw new ArgumentException("Invalid direction!");
            }
            if (index == direction.Length - 1)
            {
                newBall.height++;
            }
        }

        if (isPossible(newBall))
        {
            cubeBall = new Ball(newBall);
        }
        else
        {
            PrintMessage();
            Environment.Exit(0);
        }
    }

    private static void PrintMessage()
    {
        string currentSell = cuboid[cubeBall.width, cubeBall.height, cubeBall.depth];

        if (currentSell == "B" || cubeBall.height != height - 1)
        {
            Console.WriteLine("No");
        }
        else
        {
            Console.WriteLine("Yes");
        }
        Console.WriteLine("{0} {1} {2}", cubeBall.width, cubeBall.height, cubeBall.depth);
        return;
    }

    static bool isPossible(Ball ball)
    {
        if (ball.width >= 0 && ball.height >= 0 && ball.depth >= 0 &&
            ball.width < width && ball.height < height && ball.depth < depth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private static void ReadInpu()
    {
        string[] dimensions = Console.ReadLine().Split(' ');
        width = int.Parse(dimensions[0]);
        height = int.Parse(dimensions[1]);
        depth = int.Parse(dimensions[2]);

        cuboid = new string[width, height, depth];

        for (int h = 0; h < height; h++)
        {
            string[] line = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
            for (int d = 0; d < depth; d++)
            {
                string[] cubeContent = line[d].Split(new char[] { ')', '(' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    cuboid[w, h, d] = cubeContent[w];
                }
            }
        }

        string[] startingPoint = Console.ReadLine().Split(' ');
        int ballWidht = int.Parse(startingPoint[0]);
        int ballDepth = int.Parse(startingPoint[1]);

        cubeBall = new Ball(ballWidht, 0, ballDepth);
    }
}

