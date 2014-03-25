
public class App {

    public static void main(String [] args) {
        Ponto p1 = new Ponto(3, 4);
        Ponto p2 = new Ponto(3, 4);

        System.out.println(p2.GetTotalPoints());
    }
}


class Ponto
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
        return Math.sqrt((double)_x * _x + _y * _y);
    }

    public void Print()
    {
        System.out.println(String.format("SUPER ONE V3.7: (x = %d, y = %d)\n", _x, _y));
    }

}
