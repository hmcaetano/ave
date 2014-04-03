using System;

class App
{
    public static void Main()
    {
        Point p = new Point(7, 3);
        p.Print();
        Console.WriteLine(p.ToString()); // Redefinido em Point
        Console.WriteLine(p.GetType()); // box + call
        Console.WriteLine(p.GetHashCode()); // Herdado de Object
    }

}