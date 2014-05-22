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



class Counter
{

    private Observer[] handlers;
    
    public Counter(int capacity) {
        handlers = new Observer[capacity];
    }

    private void AddHandlerForMethodInfo(MethodInfo m)
    {
        ParameterInfo[] ps = m.GetParameters();
        // if(m.ReturnType == typeof(void) && ps.Length == 1 && ps[0].ParameterType == typeof(int))
        if (typeof(ObsRes).IsAssignableFrom(m.ReturnType)  // COvariante = o tipo de retorno do Handler pode ser derivado do tipo de retorno do Delegate
            && ps.Length == 1
            && ps[0].ParameterType.IsAssignableFrom(typeof(ObsArg))) // CONTRAvariante = o tipo de parametro do Handler pode ser base do tipo de parametro do Delegate
        {
            Object target = null;

            if (!m.IsStatic)
                target = Activator.CreateInstance(m.DeclaringType);

            Observer o = (Observer)Delegate.CreateDelegate(typeof(Observer), target, m);
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
            if (h != null)
            {
                ObsRes r = h.Invoke(new ObsArg(n)); // <=> h(n);
                Console.WriteLine(r.msg);
            }
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