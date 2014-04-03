using System;

public class PontoRef
{

    public int _y, _x;
    public PontoRef(int x, int y)
    {
        this._x = x;
        this._y = y;
    }


    public void Print()
    {
        Console.WriteLine("(x = {0}, y = {1})\n", _x, _y);
    }

}


public struct PontoVal
{

    public int _y, _x;
    public PontoVal(int x, int y)
    {
        this._x = x;
        this._y = y;
    }


    public void Print()
    {
        Console.WriteLine("(x = {0}, y = {1})\n", _x, _y);
    }
    /*
    public override bool Equals(Object o) {
        if (o == null)
            return false;

        // if (o.GetType() != this.GetType()) return false; // Menos eficiente
        if (o.GetType() != typeof(PontoVal)) 
            return false;

        PontoVal other = (PontoVal)o;

        Console.WriteLine("PontoVal::Equals invoked!!!!!");

        return this._x == other._x && this._y == other._y;
    }
     * */
}
