//Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Threading;

/// <summary>
/// Delegate that has integer and a string parameters and does not return anything
/// </summary>
/// <param name="ticksCount"></param>
/// <param name="name"></param>
public delegate void TimerDelegate(int ticksCount, string name);

class Timer
{
    /// <summary>
    /// Amount of ticks that will be made
    /// </summary>
    public int TickCounter { get; private set; }

    /// <summary>
    /// Amount of seconds that it will take before the next tick
    /// </summary>
    public int Seconds { get; private set; }

    /// <summary>
    /// Name of the caller
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Delegate field
    /// </summary>
    private TimerDelegate timerDelegate;

    /// <summary>
    /// Constructor of the timer class
    /// </summary>
    /// <param name="tickCounter">Amount of ticks that will the method make</param>
    /// <param name="miliseconds">Sleeping period of the method</param>
    /// <param name="timerDelegate">Delegate that will be executed at every tick (after every "miliseconds" miliseconds)</param>
    /// <param name="name">"The name that will be used to determine which thread is ticking (printing ot the console)"</param>
    public Timer(int tickCounter, int miliseconds, TimerDelegate timerDelegate, string name)
    {
        this.TickCounter = tickCounter;
        this.Seconds = miliseconds;
        this.timerDelegate = timerDelegate;
        this.Name = name;
    }

    /// <summary>
    /// Sleeping method that runs the thread
    /// </summary>
    public void Run()
    {
        int ticks = this.TickCounter;
        string name = this.Name;

        while (ticks > 0)
        {
            Thread.Sleep(this.Seconds);
            ticks--;
            this.timerDelegate(ticks, name);
        }
    }
}


class ExecuteAtTSeconds
{
    static void Main()
    {
        // asign new delegate
        TimerDelegate messageDelegate = PrintMessage;

        // make new instance of timer
        Timer oneSecondTimer = new Timer(5, 1000, messageDelegate, "One");
        Timer twoSecondsTimer = new Timer(5, 2000, messageDelegate, "Two");

        // make new tread and start the oneSecondTimer timer
        Thread timerThread = new Thread(new ThreadStart(oneSecondTimer.Run));
        timerThread.Start();

        // make new tread and start the twoSecondTimer timer
        Thread timerThread2 = new Thread(new ThreadStart(twoSecondsTimer.Run));
        timerThread2.Start();
    }

    /// <summary>
    /// Method that will be executed every "interval" of time
    /// </summary>
    /// <param name="ticks">The total number of ticks</param>
    /// <param name="name">"The name that will be used to determine who is printing ot the console"</param>
    public static void PrintMessage(int ticks, string name)
    {
        Console.WriteLine("[{0}:{1}:{2}] - Timer {3} thicks {4}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, name, ticks);
    }
}


