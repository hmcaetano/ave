using System;

public class Ponto
{

    public int _y, _x;

    /*
     * This is the constructor of a class that has been exported.
     * see Ponto.h for the class definition
     */
    public Ponto(int x, int y)
    {
        this._x = x;
        this._y = y;
    }

    public double GetModule()
    {
        return Math.Sqrt((double)_x * _x + _y * _y);
    }

    public double Diff(Ponto p)
    {
        int dx = _x - p._x;
        int dy = _y - p._y;
        return Math.Sqrt((double)dx * dx + dy * dy);
    }


    public void Print()
    {
        Console.WriteLine("SUPER ONE V3.7: (x = {0}, y = {1})\n", _x, _y);
    }

}
