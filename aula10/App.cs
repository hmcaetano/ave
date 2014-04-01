using System;

class Program{

    
    /*
     * Exemplo de coercao
     */
    static void conv4(long n1) {
        checked
        {
            Console.WriteLine("long " + n1);

            byte n2 = (byte)n1; // perda de info/detahe => conversão explicita
            Console.WriteLine("byte " + n2);

            int i3 = n2; // não há perda de info/detalhe => conbversão é implícita

            short s4 = (short)n1;
            Console.WriteLine("short " + s4);
        }
    }


    static void conv5()
    {
        Point p1 = new Point(5, 3);
        Object o = p1; // box

        Point p2 = (Point)o; // unbox

        o = null;
        p2 = (Point)o; // unbox => Dá NullReferenceException

    }

    static void SetValueInUnboxInstance() {
        Point p1 = new Point(5, 3);
        Object o = p1; // box

        /*
         * Compile ERROR: Cannot modify the result of an unboxing conversion 
         */
        // ((Point)o).x = 11;


        ((Point)o).SetX(11); // O objecto referido por o permanece inalterado.

        Console.WriteLine("o after ((Point)o).SetX(11) = " + o);

        ((ISetXPoint)o).SetX(11); 

        Console.WriteLine("o after ((ISetXPoint)o).SetX(11) = " + o);

    }

	static void Main(){
        // conv4(1662056);

        SetValueInUnboxInstance();
	}

}

interface ISetXPoint {
    void SetX(int v);
}

struct Point : ISetXPoint{
    public int x, y;

    public Point(int x, int y) { 
        this.x = x;
        this.y = y;
    }

    public void SetX(int v) {
        this.x = v;
    }

    public override String ToString() {
        return String.Format("({0}, {1})", x, y);
    }
}