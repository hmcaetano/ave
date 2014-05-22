using System;
using System.Reflection;
using System.Windows.Forms;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Counter c = new Counter(5);
        c.AddObserversFromAssembly("B.dll", "C.dll", "A.dll");
        c.DoIt(2, 3);
    }
}


class Counter
{

    private Observer[] handlers;

    public Counter(int capacity)
    {
        handlers = new Observer[capacity];
    }

    class ObserverWrapper: Observer{
        MethodInfo m;
        Object target;

        public ObserverWrapper(Object target, MethodInfo m){
            this.m = m;
            this.target = target;
        }
        public void Invoke(int n){
            m.Invoke(target, new object[]{n});
        }
    }

    private void AddHandlerForMethodInfo(Type targetType)
    {
            Observer target = (Observer)Activator.CreateInstance(targetType);

            // Observer o = new ObserverWrapper(target, m); //n => m.Invoke(target, new object[] { n });

            AddObserver(target);
    }



    public void AddObserversFromAssembly(params string[] paths)
    {
        foreach (string p in paths)
        {
            Assembly a = Assembly.LoadFrom(p);
            foreach (Type t in a.GetTypes())
            {
                if (typeof(Observer).IsAssignableFrom(t))
                {
                    /*
                    MethodInfo m = t.GetMethod("Invoke");
                    AddHandlerForMethodInfo(m);
                    */
                    AddHandlerForMethodInfo(t);
                }
            }
        }
    }

    public void AddObserver(Observer value)
    {
        for (int i = 0; i < handlers.Length; i++)
            if (handlers[i] == null)
            {
                handlers[i] = value;
                return;
            }
        throw new InvalidOperationException("Capacity full!");
    }
    public void RemoveObserver(Observer value)
    {
        for (int i = 0; i < handlers.Length; i++)
            if (handlers[i].Equals(value)) // !!! não fazer identity comparison
            {
                handlers[i] = null;
                break;
            }
    }

    public void NotifyObservers(int n)
    {
        foreach (Observer h in handlers)
            if (h != null)
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