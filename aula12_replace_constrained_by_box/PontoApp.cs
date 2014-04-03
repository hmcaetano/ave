using System;


public class App {

    static void Main() {
        PontoVal pv1 = new PontoVal(3, 4);
        PontoVal pv2 = new PontoVal(3, 4);

        Console.WriteLine(pv1.Equals(pv2));

        PontoRef pr1 = new PontoRef(3, 4);
        PontoRef pr2 = new PontoRef(3, 4);
        Console.WriteLine(pr1.Equals(pr2));

    }
}
