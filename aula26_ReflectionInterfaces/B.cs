using System;

public class B : Observer{

    public void Invoke(int value) {
        Console.WriteLine("ConsoleHandler = " + value);
    }

}