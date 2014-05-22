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
        c.DoIt(2,3);
    }
}



public delegate void Observer(int value);


class Counter
{

    private Observer[] handlers;
    
    public Counter(int capacity) {
        handlers = new Observer[capacity];
    }



    // NUNCA FAZER PROGRAMA��O ORIENTADA � EXCEP��O
    /*
    private void AddHandlerForMethodInfo(MethodInfo m) {
        try
        {
            Observer o = (Observer)Delegate.CreateDelegate(typeof(Observer), m);
            CounterEvent += o;
        }
        catch (ArgumentException e){}
    }
    */

    private void AddHandlerForMethodInfo(MethodInfo m)
    {
        ParameterInfo[] ps = m.GetParameters();
        if(m.ReturnType == typeof(void) && ps.Length == 1 && ps[0].ParameterType == typeof(int))
        {
            Object target = null;

            if (!m.IsStatic)
                target = Activator.CreateInstance(m.DeclaringType);

            // Op��o 1: criar o delegate via reflex�o
            // Observer o = (Observer)Delegate.CreateDelegate(typeof(Observer), target, m);

            // Op��o 2: cria��o EXPL�CITA do delegate para um m�todo an�nimo 
            // (resultante da Lambda) e chamada ao m�todo via reflex�o.
            Observer o = n => m.Invoke(target, new object[] { n });

            CounterEvent += o;
        }
    }



    public void AddObserversFromAssembly(params string [] paths) {
        foreach (string p in paths)
        {
            Assembly a = Assembly.LoadFrom(p);
            foreach (Type t in a.GetTypes()) {
                foreach (MethodInfo m in t.GetMethods())
                {
                    AddHandlerForMethodInfo(m);
                }
            }
        }
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
                if (handlers[i].Equals(value)) // !!! n�o fazer identity comparison
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

    // Notifica o m�todo de callback,
    // por cada itera��o de �from� at� to.
    public void DoIt(int from, int to)
    {
        for (int i = from; i <= to; i++)
        {
            NotifyObservers(i);
        }
    }
}