using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter();
        c.AddObserver(Program.FeedbackToConsole);
        c.AddObserver(Program.FeedbackToMsgBox);
        c.AddObserver(Program.FeedbackBeep);
        c.DoIt(5, 7);
    }

    private static void FeedbackToConsole(int value)
    {
        Console.WriteLine("ConsoleHandler = " + value);
    }

    private static void FeedbackToMsgBox(int value)
    {
        MessageBox.Show("Item = " + value);
    }

    private static void FeedbackBeep(int value)
    {
        for (int i = 0; i < value; i++)
        {
            Console.Beep();
            Console.Write("Hello ");
        }
        Console.WriteLine();
    }
}

public delegate void Observer(int value);


class Counter
{
    private List<Observer> obs = new List<Observer>();

    public void AddObserver(Observer o)
    {
        obs.Add(o);
    }

    public void RemoveObserver(Observer o)
    {
        obs.Remove(o);
    }

    public void NotifyObservers(int n)
    {
        //if any callbacks are specified, call them
        foreach (Observer o in obs)
        {
            o(n); // <=> o.Invoke(n);
        }
    }

    // Notifica o método de callback Feedback do objecto o,
    // por cada iteração de from a to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}