class B
{
    public B() { }
    public B(int n) { }
}

class A { 
    public A(){}
    public A(int n) { }
    public A(String s, int b) { }
	
	public String toString() {

        return "Eu sou um A";
    }

}

public class App {


    public static void main(String [] args) {
        A a = new A();
        new B(7);
		
		System.out.println(a);
    }

}