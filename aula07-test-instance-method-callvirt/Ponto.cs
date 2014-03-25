using System;


public class Ponto
{

    public int _y, _x;
    public static int nrOfPoints;

    public static int GetTotalPoints() {
        return nrOfPoints;
    }

    /*
     * This is the constructor of a class that has been exported.
     * see Ponto.h for the class definition
     */
    public Ponto(int x, int y)
    {
        this._x = x;
        this._y = y;
        Ponto.nrOfPoints++;
    }

    public double GetModule()
    {
        return Math.Sqrt((double)_x * _x + _y * _y);
    }

    public void Print()
    {
        // Console.WriteLine("SUPER ONE V3.7: (x = {0}, y = {1})\n", _x, _y);
        Console.WriteLine("SUPER ONE V3.7: ");
    }

}
