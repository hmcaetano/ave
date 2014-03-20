using System;

class B
{
    public B() { }
    public B(int n) { }
}

class A { 
    public A(){}
    public A(int n) { }
    public A(String s, int b) { }

    public void Print() {
        Console.WriteLine(this.ToString());
    }

    public override String ToString() {

        return "Eu sou um A";
    }
}

public class App {


    static void PrintObject(Object o) {
        Console.WriteLine(o.ToString());
    }

    static void Main() {
        A obj1 = new A();
        B obj2 = new B(7);
        PrintObject(obj1);
        PrintObject(obj2);
    }

}