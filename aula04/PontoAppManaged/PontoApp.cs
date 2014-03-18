using System;

public class App {

    static void M1() {
        Ponto p = new Ponto(5, 7);
        p.Print();
        Console.WriteLine("p._x = {0}\n", p._x);
    }


    static void M2()
    {
        Console.WriteLine("ola ISEL");
    }


    static void Main() {
        M2();
        M2();
        M1();
    }

}