using System;

public class A
{
    int occurences;

    public A() { this.occurences = 1; }

    public A(int n) { this.occurences = n; }

    public ObsRes FeedbackBeep(Object v)
    {
        ObsArg value = (ObsArg)v;
        for (int i = 0; i < occurences; i++)
        {
            Console.Beep();
            Console.Write(" Hello : " + value.arg);
        }
        Console.WriteLine();
        return new ObsRes(value.arg, "Beep");
    }

}
