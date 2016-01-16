using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.IO;

class Game
{
    static int points { get; set; }
    static string playerName { get; set; }
    static string saveDir = @"save";
    static Snake snake;
    static Element food;
    static Element bonus;
    Random random = new Random();

    private void InitializeComponents()
    {
        // if there is no snake - make new one
        // else the load mothod has been called and we have a snake declared
        if (snake == null)
        {
            snake = new Snake();
        }
        food = new Element(random.Next(3, Console.WindowHeight),
            random.Next(0, Console.WindowWidth), '@');
        bonus = new Element(5, 5, ' ');
        DisplayPoints();
    }

    public void Play(string level)
    {
        InitializeComponents();
        int bonusFoodChance = 0;
        int bonusTime = 50;
        bool bonusOn = false;
        int pointsMultiplier = 1;
        int sleepLevel = 1;

        switch (level)
        {
            case "Hard":
                pointsMultiplier = 4;
                sleepLevel = 75;
                break;
            case "Medium":
                pointsMultiplier = 2;
                sleepLevel = 100;
                break;
            case "Easy":
                pointsMultiplier = 1;
                sleepLevel = 125;
                break;
        }

        try
        {
            while (true)
            {
                food.Display();
                snake.Move();
                DisplayPoints();

                GetKeyPressed();

                //SaveGame(snake);
                Element snakeHead = snake.GetSnakeHead();
                List<Element> snakeElements = snake.GetSnakeElements();
                snakeElements.RemoveAt(snakeElements.Count - 1);

                //spawn bonus
                if (bonusOn == false)
                {
                    bonusFoodChance = random.Next(100, 200);
                    if (bonusFoodChance < 105)
                    {
                        bonus = new Element(random.Next(3, Console.WindowHeight),
                             random.Next(0, Console.WindowWidth), '$');
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        bonus.Display();
                        Console.ResetColor();
                        bonusOn = true;
                        bonusTime = 50;
                    }
                }

                bonusTime--;

                //clear bonus
                if (bonusTime == 0)
                {
                    Console.SetCursorPosition(bonus.col, bonus.row);
                    Console.WriteLine(' ');
                    bonus.ChangeCoordinates(0, 0);
                    bonusOn = false;
                }

                //set level
                Thread.Sleep(sleepLevel);

                //check if snake hits itself
                foreach (var snakeElement in snakeElements)
                {
                    if (snakeElement.row == snakeHead.row && snakeElement.col == snakeHead.col)
                    {
                        throw new GameException();
                    }
                }

                //feed
                if (snakeHead.row == food.row && snakeHead.col == food.col)
                {
                    snake.Move();
                    food.ChangeCoordinates(random.Next(3, Console.WindowHeight), random.Next(0, Console.WindowWidth));
                    points += pointsMultiplier;
                }

                //snake gets bonus
                else if (snakeHead.row == bonus.row && snakeHead.col == bonus.col)
                {
                    snake.Move();
                    points += 10 + pointsMultiplier;
                    Console.ResetColor();
                    bonusOn = false;
                }
                //hit the frame
                else if (snakeHead.row == 2 || snakeHead.row > Console.WindowHeight || snakeHead.col > Console.WindowWidth || snakeHead.col < 0)
                {
                    throw new GameException();
                }

                //normal movement.
                else
                {
                    snake.RemoveSnakeTail();
                }
            }
        }
        catch (GameException)
        {
            GameOver();
        }
    }

    private static void DisplayPoints()
    {
        Console.SetCursorPosition(70, 0);
        Console.Write("Points: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(points);
        Console.ResetColor();
    }

    static void SaveGame(Snake snake)
    {
        Console.SetCursorPosition(0, 1);
        Console.Write("Enter your name: ");
        playerName = Console.ReadLine();
        playerName = playerName.Replace(" ", string.Empty);

        List<Element> snakeElements = snake.GetSnakeElements();

        string fullFilePath = Path.Combine(saveDir, playerName + ".save");


        if (!File.Exists(fullFilePath))
        {
            Directory.CreateDirectory(saveDir);
            FileStream fs = System.IO.File.Create(fullFilePath);
            File.SetAttributes(fullFilePath, FileAttributes.Normal);
            fs.Flush();
            fs.Close();
        }

        using (StreamWriter writer = new StreamWriter(fullFilePath))
        {
            //TODO: exception handling of corrupted files
            writer.WriteLine("{0} {1} {2}", playerName, points, snake.GetCurrentDirection());
            foreach (var element in snakeElements)
            {
                writer.WriteLine("{0} {1} {2}", element.row, element.col, element.symbol);
            }
        }
    }

    public string[] GetPlayers(string dir)
    {
        string[] files = null;
        try
        {
            files = Directory.GetFiles(dir);
            for (int index = 0; index < files.Length; index++)
            {
                // trim all but the name
                files[index] = files[index].Replace(dir + "\\", string.Empty);
                files[index] = files[index].Replace("." + dir, string.Empty);
            }

        }
        catch (Exception)
        {

        }
        return files;
    }

    static void LoadGame(string name)
    {
        Queue<Element> newSnakeElements = new Queue<Element>();

        string fullFilePath = Path.Combine(saveDir, name + ".save");

        if (File.Exists(fullFilePath))
        {
            using (StreamReader reader = new StreamReader(fullFilePath))
            {
                string[] playerSettings = reader.ReadLine().Split(' ');
                playerName = playerSettings[0];
                points = int.Parse(playerSettings[1]);
                int direction = int.Parse(playerSettings[2]);

                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] element = line.Split(' ');

                    newSnakeElements.Enqueue(new Element(
                        int.Parse(element[0]),
                        int.Parse(element[1]),
                        (char)element[2][0]));

                    line = reader.ReadLine();
                }
                snake = new Snake(newSnakeElements);
                snake.SetCurrentDirection(direction);
            }
        }

    }

    public int Load(string name)
    {
        string[] players = GetPlayers(saveDir);

        if (players != null && players.Length != 0)
        {
            foreach (var file in players)
            {
                if (file.Equals(name))
                {
                    LoadGame(name);
                    ClearRow(1); // if the player is found clear the msg bellow
                    break;
                }
                else
                {
                    ClearRow(1);
                    WriteMSG("Player not found", 1);
                }
            }
            //atleast one save is found
            return 1;
        }
        else
        {
            // no saves in the folder
            return 0;
        }
    }

    private static void GameOver()
    {
        Console.Beep();
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Game Over!");
    }

    private void GetKeyPressed()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            switch (userInput.Key)
            {
                case ConsoleKey.LeftArrow:
                    snake.SetCurrentDirection(0);
                    break;
                case ConsoleKey.RightArrow:
                    snake.SetCurrentDirection(1);
                    break;
                case ConsoleKey.UpArrow:
                    snake.SetCurrentDirection(2);
                    break;
                case ConsoleKey.DownArrow:
                    snake.SetCurrentDirection(3);
                    break;

                case ConsoleKey.S:
                    SaveGame(snake);
                    PauseGame("Game saved! Press 'P' to continue");
                    break;
                case ConsoleKey.P:
                    PauseGame("Game paused! Press 'P' to continue");
                    break;
            }
        }
    }

    private void PauseGame(string message)
    {
        bool pause = true;
        // clear the row
        ClearRow(1);
        WriteMSG(message, 1);

        while (pause)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();
                switch (userInput.Key)
                {
                    case ConsoleKey.P:
                        pause = false;
                        break;
                }
            }
        }
        // clear the row
        ClearRow(1);
    }

    private static void ClearRow(int row)
    {
        // clear the row
        Console.SetCursorPosition(0, row);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.ResetColor();
    }
    private static void WriteMSG(string message, int row)
    {
        Console.SetCursorPosition((Console.WindowWidth - message.Length) / 2, row);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(message);
    }

}