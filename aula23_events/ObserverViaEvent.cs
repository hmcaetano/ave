using System;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter();
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
	int maxHandlers;
	int currHandlers;
	
	public Counter(int handlers){
		maxHandlers = handlers;
	}
    /*
    private Observer obs;

    public void AddObserver(Observer o)
    {
        obs += o; // obs = (Observer) Delegate.Combine(obs, o);
    }

    public void RemoveObserver(Observer o)
    {
        obs -= o; // obs = (Observer) Delegate.Remove(obs, o);
    }
    */

	
    // substitui as linhas de cima.
    public event Observer CounterEvent;

	public Observer operator +=(this Observer, Observer o){
		if(currHandlers >= maxHandlers)
			throw new UnsupportedOperationException();
		++currHandlers;
		return Counter += o;
	}
	
	public Observer operator -=(this Observer, Observer o){
		if(currHandlers <= 0)
			throw new UnsupportedOperationException();
		--currHandlers;
		return Counter -= o;
	}
	
    public void NotifyObservers(int n)
    {
        //if any callbacks are specified, call them
        /*
        foreach (Observer o in obs.GetInvocationList())
        {
            o(n); // <=> o.Invoke(n);
        }
        */
        CounterEvent(n);
    }

    // Notifica o método de callback Feedback do objecto o,
    // por cada iteração de from a to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}