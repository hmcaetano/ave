using System;

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
