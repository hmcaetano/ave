using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter(2);
        c.CounterEvent += (value => Console.WriteLine("ConsoleHandler = " + value));
        c.CounterEvent += (value => MessageBox.Show("Item = " + value));
        // c.AddObserver(new Observer(new A(2).FeedbackBeep));
        c.DoIt(5, 7);
    }
}

class A {

    int occurences;

    public A(int n){this.occurences = n;}

    public void FeedbackBeep(int value)
    {
        for (int i = 0; i < occurences; i++)
        {
            Console.Beep();
            Console.Write(" Hello : " + value);
        }
        Console.WriteLine();
    }

}


public delegate void Observer(int value);


class Counter
{

    private Observer[] handlers;
    
    public Counter(int capacity) {
        handlers = new Observer[capacity];
    }



    public void AddObserversFromAssembly(string path) { 


    }

    public event Observer CounterEvent {
        add {
            for (int i = 0; i < handlers.Length; i++)
                if (handlers[i] == null) { 
                    handlers[i] = value;
                    return;
                }
            throw new InvalidOperationException("Capacity full!");
        }
        remove
        {
            for (int i = 0; i < handlers.Length; i++)
                if (handlers[i].Equals(value)) // !!! não fazer identity comparison
                {
                    handlers[i] = null;
                    break;
                }
        }
    }

    public void NotifyObservers(int n)
    {
        foreach (Observer h in handlers)
            if(h != null)
                h.Invoke(n); // <=> h(n);
    }

    // Notifica o método de callback,
    // por cada iteração de ´from´ até to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}