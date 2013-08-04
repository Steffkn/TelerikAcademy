// * Implement the "Falling Rocks" game in the text console. 
// A small dwarf stays at the bottom of the screen and can move left and right (by the arrows keys). 
// A number of rocks of different sizes and forms constantly fall down and you need to avoid a crash.

// Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed with appropriate density. 
// The dwarf is (O). Ensure a constant game speed by Thread.Sleep(150).
// Implement collision detection and scoring system.

// rocks ^ @ * & + % $ # ! . ; - 
// the idea is that we have a grid that will represent the game field and every number in this grid represents a different item of the game
// for example: 0 means "nothing" and in the PrintGame() 0 will be replaced with " " (space) on the console
// 1 will be the dwarf - "(0)" on the console
// numbers from 2 to 10 will represent different kind of rocks and so on
using System;
using System.Threading;

// TODO: there are stills some bugs to be fixed .. 
class FallingRocks
{
    const int HEIGHT = 25;  // game/window height
    const int WIDTH = 40;   // game/window widht
    static int[,] GRID = new int[HEIGHT, WIDTH];    // grid for the game
    static int[] DWARF = new int[WIDTH];            // vector for the dwarf
    static int[] STATUSBAR = new int[WIDTH];        // status bar for the lives and score
    static int DWARFPOSITION = WIDTH / 2;           // current position of the dwarf
    static int DIFFICULTY;   // 1-10 (10 hardest)
    static int LIVES;       // number of lives the dwarf have
    static int SCORE;       // holds the score
   
    static void Main()
    {

        InitGame();
        Run();
    }

    // this is the game engine
    private static void Run()
    {
        // declaring variable for the input
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

        // never ending loop for the game to run 
        while( true )
        {
            // game is sleeping 200ms
            Thread.Sleep(200);

            // clearing the console
            Console.Clear();

            // var for the game status (playing / new game/ end of the game)
            int gameStatus = MoveGrid();    // taking the game status

            // 0 is end of the game
            if( gameStatus == 0 )
            {
                // exiting the game
                return;
            }
            // 2 is new game
            else if( gameStatus == 2 )
            {
                // calling the new game method
                NewGame();
            }
            // printing the game frame on the console
            PrintGame();

            // if key is pressed
            if( Console.KeyAvailable )
            {
                // taking the pressed key
                keyInfo = Console.ReadKey(true);
                // checking which key was pressed
                switch( keyInfo.Key )
                {
                    // if the key is A/LeftArrow we make move to the left
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        MoveDwarf(-1);
                        break;
                    // if the key is D/RightArrow we make move to the right
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        MoveDwarf(1);
                        break;

                    // if P is pressed the game will pause
                    case ConsoleKey.P:
                        // TODO: pause
                        break;
                    default:
                        break;
                }
            }
        }
    }

    // settings and difficulty determination
    private static void InitGame()
    {
        // settings for the console screen
        Console.WindowHeight = HEIGHT +1;
        Console.WindowWidth = WIDTH;
        // bugs apear when i set the buffer's height and width
        //Console.BufferHeight = Console.WindowHeight;
        //Console.BufferWidth = Console.WindowWidth;
        Console.Title = "Falling Rocks!";
        // setting the difficulty
        Console.Write("Enter difficulty level (1-10): ");
        while( !int.TryParse(Console.ReadLine(), out DIFFICULTY) && ( DIFFICULTY < 1 && DIFFICULTY > 10 ) )
        {
            Console.WriteLine("Invalid level! (1-10)");
            Console.Write("Enter difficulty level (1-10): ");
        }
        NewGame();
    }

    // starting new game, resiting the score and refreshing the lives
    private static void NewGame()
    {
        for( int i = 0; i < GRID.GetLength(0); i++ )
        {
            for( int j = 0; j < GRID.GetLength(1); j++ )
            {
                // erasing everything in the GRID
                GRID[i, j] = 0;
            }
        }
        // giving lives and resetting the score
        LIVES = 10;
        SCORE = 0;
        // starting position of the dwarf is in the middle
        DWARFPOSITION = WIDTH / 2;
        // adding the dwarf to its vector
        AddDwarf(DWARFPOSITION);

        // starting labels: 3..2..1..GO!!
        Console.ForegroundColor = ConsoleColor.Green;
        for( int i = 3; i >= 0; i-- )
        {
            Console.Clear();
            for( int j = 0; j < HEIGHT / 2; j++ ) { Console.WriteLine(); }

            if( i == 0 ) { Console.WriteLine("\t\tGO!!"); }
            else { Console.WriteLine("\t\t{0}", i); }
            Thread.Sleep(1000);
        }
    }

    // this method moves the Dwarf in his vector
    private static void MoveDwarf(int direction)
    {
        // checking if the dwarf isn't next to the borders of the game (left/right) 
        // when we press direction that will other ways trow him out side the game
        if( ( direction > 0 && DWARFPOSITION < WIDTH - 3 ) || ( direction < 0 && DWARFPOSITION > 0 ) )
        {
            // old position will be erased
            DWARF[DWARFPOSITION] = 0;
            // moving the dwarf depending of the direction (1 or -1)
            // 1 is right
            // -1 is left
            DWARFPOSITION += direction;
            // new position of the dwarf
            DWARF[DWARFPOSITION] = 1;
        }
    }

    // this method adds the dwarf at the bottom of the grid at a given position
    private static void AddDwarf(int position)
    {
        DWARFPOSITION = position;
        GRID[HEIGHT - 1, DWARFPOSITION] = 1;
    }

    // Method that adds the status bar to the top of the grid
    private static void AddStatusBar()
    {
        for( int j = 0; j < 10; j++ )
        {

            if( j < LIVES )
            {
                // for every life that the dwarf has the sell with index j will be equal to 20
                GRID[0, j] = 20;    // 20 means 1 life for the PrintGame()
            }
            else
            {
                // this will erase the used lives (after the dwarf gets hit by a rock)
                GRID[0, j] = 0;
            }
        }
        // at GRID[0,20] will be added the score
        GRID[0, 20] = 30;       // 30 means score for the PrintGame()
    }

    // Method that add rocks to the game
    // Depending of the difficulty this method adds 1,2 or 3 rocks on a row. There is a "chance" that a row can be empty (no rocks added)
    private static void AddRocks()
    {
        Random rnd = new Random();
        // we generate a random number. If that number is less than the difficulty then a rock is added
        if( rnd.Next(0, 10) <= DIFFICULTY )
        {
            // adding a random rock (from 2 to 10) in the second row of GRID at a random position
            GRID[1, rnd.Next(0, WIDTH)] = rnd.Next(2, 10);
        }
        // if the difficulty is bigger than 8, new random number is generated. If that new number is less than the difficulty additional rock is added to the game
        if( DIFFICULTY >= 8 && rnd.Next(0, 10) <= DIFFICULTY )
        {
            // adding a random rock (from 2 to 10) in the second row of GRID at a random position
            GRID[1, rnd.Next(0, WIDTH)] = rnd.Next(2, 10);
        }
        // if the difficulty is 10 (hardest) additional rock is added to GRID
        if( DIFFICULTY == 10 )
        {
            // adding a random rock (from 2 to 10) in the second row of GRID at a random position
            GRID[1, rnd.Next(0, WIDTH)] = rnd.Next(2, 10);
        }

    }

    // Method that moves the grid 1 position bellow, starting from the bottom to top
    private static int MoveGrid()
    {
        for( int i = GRID.GetLength(0) - 1; i > 1; i-- )
        {
            for( int j = 0; j < GRID.GetLength(1); j++ )
            {
                // if the cells above the dwarf are not 0 and its time to move that sell 1 row under (hitting the dwarf)
                if( GRID[i, j] == 1 && ( GRID[i - 1, j] != 0 || GRID[i - 1, j + 1] != 0 || GRID[i - 1, j + 2] != 0 ) )
                {
                    // extracting 1 from dwarf's lives
                    LIVES -= 1;
                    // if there are no lives left
                    if( LIVES == 0 )
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        // printing "Game Over" and the score
                        Console.WriteLine("\n\n\n\n\n\t\tGame Over!");
                        Console.WriteLine("\t\tSCORE: {0}", SCORE);

                        // asking if we want to play again
                        Console.WriteLine("One more time? Y/N");

                        // if the user press anything else than Y (yes)
                        if( Console.ReadKey().Key != ConsoleKey.Y )
                        {
                            // return 0 means "end of game"
                            return 0;
                        }
                        else
                        {
                            // return 2 means starting of a new game 
                            return 2;
                        }
                    }

                }


                // the sell j at row i-1 is equal to the sell at row i
                GRID[i, j] = GRID[i - 1, j];
                // making the "old" sell equal to 0
                GRID[i - 1, j] = 0;

                // if a rock reach the end (missing the dwarf), 10 is added to the score
                if( ( i == GRID.GetLength(0) - 1 ) && ( GRID[GRID.GetLength(0) - 1, j] != 0 && GRID[GRID.GetLength(0) - 1, j] != 1 ) )
                {
                    // this is more like bonus the the score becouse if the score equals the number of the rocks that miss the dwarf
                    // for bigger time period the score will be different (rocks are not falling constantly in time)
                    SCORE += 10;
                }
            }
        }
        // with this the score will be more time depending (the more the dwarf survive, the bigger the score will be)
        // also the bigger the difficulty is, the bigger the score will be 
        SCORE += DIFFICULTY;

        // adding rock to the grid
        AddRocks();

        // adding the dwarf at his position
        AddDwarf(DWARFPOSITION);
        // adding the status bar with the lives remaining and the curent score
        AddStatusBar();
        // return 1 means that everithing is OK and the game continues
        return 1;
    }

    // this method prinds the game on the console
    // using the GRID as a map, every number in that GRID means different thing (player, rock, score, lives)
    private static void PrintGame()
    {
        // checking the grid
        for( int i = 0; i < GRID.GetLength(0); i++ )
        {
            for( int j = 0; j < GRID.GetLength(1); j++ )
            {
                // this will print specific symbol on the console for different numbers in GRID[i, j]
                switch( GRID[i, j] )
                {
                    case 0:
                        Console.Write(" ");
                        break;
                    case 1:
                        // this is the dwarf
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("(0)");
                        j += 2;
                        break;
                    // from 2 to 10 we have rocks
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("@");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("#");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("$");
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("%");
                        break;
                    case 6:
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("^");
                        break;
                    case 7:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("&");
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("*");
                        break;
                    case 9:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(";");
                        break;
                    case 10:
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("-");
                        break;
                    // print the life as L at top left of the screen
                    case 20:
                        Console.ForegroundColor = ConsoleColor.White;
                        //Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.Write("L");
                        break;

                    // print the score at the top of the screen
                    case 30:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(SCORE);
                        break;
                    default:
                        Console.Write(" ");
                        break;
                }
            }
            Console.WriteLine();
        }
    }

}

