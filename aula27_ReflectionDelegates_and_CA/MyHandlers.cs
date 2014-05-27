using System;
using System.Windows.Forms;

public class C
{

    [ObserverHandler]
    public static void MboxHandler(int value)
    {
        MessageBox.Show("Item = " + value);
    }

}

public class B
{

    [ObserverHandler]
    public static void ConsoleHandler(int value)
    {
        Console.WriteLine("ConsoleHandler = " + value);
    }

}

public class A
{

    int occurences;

    public A() { this.occurences = 1; }

    public A(int n) { this.occurences = n; }

    public void FeedbackBeep(int value)
    {
        for (int i = 0; i < occurences; i++)
        {
            Console.Beep();
            Console.Write(" Hello : " + value);
        }
        Console.WriteLine();
    }

}
