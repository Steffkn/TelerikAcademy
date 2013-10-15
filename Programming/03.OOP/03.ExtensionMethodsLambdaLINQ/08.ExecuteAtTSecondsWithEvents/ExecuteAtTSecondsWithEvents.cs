// Using delegates write a class Timer that has can execute certain method at each t seconds.
// * Read in MSDN about the keyword event in C# and how to publish events.
// Re-implement the above using .NET events and following the best practices.

using System;
using System.Threading;

//Class which publish an event
public class Timer : EventArgs
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
    /// Constructor of the timer class
    /// </summary>
    /// <param name="tickCounter">Amount of ticks that will the method make</param>
    /// <param name="miliseconds">Sleeping period of the method</param>
    /// <param name="name">"The name that will be used to determine which thread is ticking (printing ot the console)"</param>
    public Timer(int tickCounter, int miliseconds, string name)
    {
        this.TickCounter = tickCounter;
        this.Seconds = miliseconds;
        this.Name = name;
    }
    //Declare event
    public event EventHandler RaiseEvent;

    //Method that do something and then raise an event
    public void Start()
    {
        int seconds = this.Seconds;
        int ticks = this.TickCounter;
        while (ticks > 0)
        {
            ticks--;
            Thread.Sleep(seconds);
            OnRaiseCustomEvent();
        }
    }

    /// <summary>
    /// Raise an event
    /// </summary>
    protected virtual void OnRaiseCustomEvent()
    {
        EventHandler customEvent = RaiseEvent;
        if (customEvent != null)
        {
            // make an event
            customEvent(this.Name, null);
        }
    }
}

/// <summary>
/// Handles the events
/// </summary>
public class Handler
{
    public Handler(Timer timer)
    {
        timer.RaiseEvent += HandleCustomEvent;
    }
    /// <summary>
    /// When an event is rised execute this method
    /// </summary>
    /// <param name="sender">Whos send the event</param>
    /// <param name="args">The event</param>
    public static void HandleCustomEvent(object sender, EventArgs args)
    {
        Console.WriteLine("{0} is ticking!", sender);
    }
}

public class ExecuteAtTSecondsWithEvents
{
    static void Main()
    {
        Timer timer = new Timer(5, 2000, "Gosho");
        Handler handler = new Handler(timer);
        //raise an event
        timer.Start();
    }
}