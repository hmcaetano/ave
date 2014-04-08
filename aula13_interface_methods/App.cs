using System;

class E : I
{
    void I.m()
    {
        Console.WriteLine("E");
    }
}

class F : E
{
    public virtual void m()
    {
        Console.WriteLine("F");
    }
}

class G : F, I
{
    public override void m()
    {
        Console.WriteLine("G");
    }
}

class H : G
{
    public void m()
    {
        Console.WriteLine("H");
    }
}




interface I
{
    void m();
}

class A : I
{
    public virtual void m()
    {
        Console.WriteLine("A");
    }
}

class B : A
{
    public override sealed void m()
    {
        Console.WriteLine("B");
    }
}

class C : B, I
{
    public new void m()
    {
        Console.WriteLine("C");
    }
}


class Program
{
    static void MyService(I i)
    {
        i.m();
    }


    static void tpc()
    {
        H h = new H();
        I i = h;
        E e = h;
        F f = h;
        G g = h;

        // e.m(); // Erro de compilação
        f.m();
        g.m();
        h.m();
        i.m();
    }


    static void aula13()
    {
        B b = new B();
        E e = new E();

        // b.m();
        // e.m(); // Errp de compilação pq E não define um métofo 'm'

        // MyService(b);
        // MyService(e);

        C c = new C();
        c.m(); // C
        I i = c;
        i.m(); // C
        A a = c;
        a.m(); // callvirt A::m() ==> B
    }

    static void Main()
    {
        // aula13();
        tpc();
    }
}