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
}

public class App {


    static void Main() {
        A obj1 = new A();
        B obj2 = new B(7);
    }

}