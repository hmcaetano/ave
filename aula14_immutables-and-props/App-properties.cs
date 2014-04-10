using System;


class Student {
    private int _age;

    public int Age {

        get { return _age; }

        set {
            if (value < 0)
                throw new ArgumentException("Age cannot be a negative value");
            _age = value;
        }

    }   
}

struct Point {
    public Point(int x, int y) :this(){
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

    double Module {
        get {
            return Math.Sqrt(X * X + Y * Y);
        }
    }

}

class App{

    static void Main(){

        Student s = new Student();
        s.Age = 18;
        s.Age = -7;
    }
}