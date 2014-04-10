using System;

struct Point
{
    public Point(int x, int y)
        : this()
    {
        X = x;
        Y = y;
    }

    public int X
    {
        get;
        set;
    }

    public int Y
    {
        get;
        set;
    }

    double Module
    {
        get
        {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

}


class Polygon {

    Point[] pts;

    public Polygon(int size)
    {
        pts = new Point[size];
    }

    /*
    public Point getPoint(int idx) {
        return pts[idx];
    }
     */

    public Point this[int idx]{
        get {
            if (idx < 0 || idx > pts.Length)
                throw new ArgumentException("Index must be a positive value lower than " + pts.Length);

            return pts[idx];
        }
    }
}



class App{

    static void Main(){
        Polygon p = new Polygon(5);
        Point p0 = p[8];
       
    }
}