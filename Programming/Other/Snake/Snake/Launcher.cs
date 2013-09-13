using System;
using System.Collections.Generic;
using System.Text;

class Launcher
{
    static void Main(string[] args)
    {
        SetConsoleDefaultSettings();

        DisplayMainMenu();

    }

    static void SetConsoleDefaultSettings()
    {
        Console.Title = "Snake";
        Console.BufferHeight = 40;
        Console.BufferWidth = 80;
        Console.CursorVisible = false;
        Console.SetWindowSize(80, 40);
    }

    static void DisplayMainMenu()
    {
        int selected = 0;
        bool switchToNextMenu = false;

        List<string> mainMenu = new List<string>();
        mainMenu.Add("New game");
        mainMenu.Add("Load game");
        mainMenu.Add("View highscore");
        mainMenu.Add("View instructions");
        mainMenu.Add("Exit game");

        DisplayMenuHeader("S N A K E", 6);
        DisplayMenuContent(mainMenu, selected);

        while (!switchToNextMenu)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.DownArrow)
            {
                selected = SelectDown(selected, mainMenu);
                DisplayMenuHeader("S N A K E", 6);
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                selected = SelectUp(selected, mainMenu);
                DisplayMenuHeader("S N A K E", 6);

            }
            else if (userInput.Key == ConsoleKey.Enter)
            {
                switch (selected)
                {
                    case 0:
                        Console.Clear();
                        DisplayLevelMenu();
                        switchToNextMenu = true;
                        break;
                    case 1:
                        //load game
                        DisplayPlayersList();
                        break;
                    case 2:
                        //view highscore
                        break;
                    case 3:
                        //view instructions
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }

    private static int SelectDown(int selected, List<string> menuList)
    {
        if (selected > menuList.Count - 2)
        {
            selected = -1;
        }
        Console.Clear();
        DisplayMenuContent(menuList, ++selected);
        return selected;
    }

    private static int SelectUp(int selected, List<string> menuList)
    {
        if (selected <= 0)
        {
            selected = menuList.Count;
        }
        Console.Clear();

        DisplayMenuContent(menuList, --selected);

        return selected;
    }

    private static int DisplayLevelMenu()
    {
        bool gameStarted = false;
        int selected = 0;
        Game game = new Game();

        List<string> gameLevels = new List<string>();
        gameLevels.Add("Easy");
        gameLevels.Add("Medium");
        gameLevels.Add("Hard");

        DisplayMenuHeader("Choose difficulty", 6);
        DisplayMenuContent(gameLevels, selected);

        while (!gameStarted)
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.DownArrow)
            {
                selected = SelectDown(selected, gameLevels);
                DisplayMenuHeader("Choose difficulty", 6);
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                selected = SelectUp(selected, gameLevels);
                DisplayMenuHeader("Choose difficulty", 6);
            }
            else if (userInput.Key == ConsoleKey.Enter)
            {
                switch (selected)
                {
                    //easy    
                    case 0:
                        Console.Clear();
                        gameStarted = true;
                        DisplayWindowFrame();
                        game.Play(gameLevels[0]);
                        //return 0;
                        break;

                    //medium    
                    case 1:
                        Console.Clear();
                        gameStarted = true;
                        DisplayWindowFrame();
                        game.Play(gameLevels[1]);
                        //return 1;
                        break;

                    //hard  
                    case 2:
                        Console.Clear();
                        gameStarted = true;
                        DisplayWindowFrame();
                        game.Play(gameLevels[2]);
                        //return 2;
                        break;
                }// switch
            }
        }//while

        return -1;
    }
    private static void DisplayMenuHeader(string header, int row)
    {
        int startIndex = (Console.WindowWidth - header.Length) / 2;
        Console.SetCursorPosition(startIndex, row);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(header);
        Console.ResetColor();
        Console.SetCursorPosition(startIndex - 1, row + 1);
        Console.WriteLine(new String('_', header.Length + 2));

    }

    private static void DisplayPlayersList()
    {
        Game game = new Game();
        List<string> playersList = new List<string>();
        bool loaded = false;
        int selected = 0;
        string[] players = game.GetPlayers("save");

        foreach (var player in players)
        {
            playersList.Add(player);
        }

        if (players != null && players.Length > 0)
        {
            Console.Clear();
            DisplayMenuHeader("Select player", 6);
            DisplayMenuContent(playersList, 0);

            while (!loaded)
            {
                ConsoleKeyInfo userInput = Console.ReadKey();

                if (userInput.Key == ConsoleKey.DownArrow)
                {
                    selected = SelectDown(selected, playersList);
                    DisplayMenuHeader("Select player", 6);
                }
                else if (userInput.Key == ConsoleKey.UpArrow)
                {
                    selected = SelectUp(selected, playersList);
                    DisplayMenuHeader("Select player", 6);
                }
                else if (userInput.Key == ConsoleKey.Enter)
                {
                    game.Load(playersList[selected]);
                    Console.Clear();
                    DisplayWindowFrame();
                    game.Play("Hard");
                    break;
                }
            }
        }
    }

    private static void DisplayMenuContent(List<string> menuContent, int selected)
    {
        int middle = Console.WindowWidth / 2;
        int topPosition = 8;

        for (int i = 0; i < menuContent.Count; i++)
        {
            if (i == selected)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(middle - 7, topPosition += 3);
                Console.WriteLine(menuContent[selected]);
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(middle - 7, topPosition += 3);
                Console.WriteLine(menuContent[i]);
            }

        }// if the last used color is red ??
        Console.ResetColor();
    }

    static void DisplayWindowFrame()
    {
        Console.SetCursorPosition(0, 2);
        Console.Write(new string('-', Console.WindowWidth));
    }

}