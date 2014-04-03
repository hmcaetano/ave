using System;

public struct Point
{
    int x;
    int y;
    public Point(int cx, int cy)
    {
        x = cx; y = cy;
    }
    public override String ToString()
    {
        return String.Format("({0},{1})", x, y);
    }
    public void Print()
    {
        Console.WriteLine(this.ToString());
    }
}

