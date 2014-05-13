using System;
using System.Windows.Forms;
using System.Collections.Generic;

public delegate void A();

class Program
{
    static void Main()
    {
        Func<String> h1 = () => "Ola ISEL";
        Func<double> h2 = () => Math.PI;
        Func<double> h3 = () => Math.Sqrt(2);
        Func<String> h4 = () => "Ola Cheguei";

        MultiDelegator md = new MultiDelegator();
        md.AddHandler(h1);
        md.AddHandler(h2);
        md.AddHandler(h3);
        md.AddHandler(h4);
        md.DispatchAndPrint(typeof(Func<String>));
        md.DispatchAndPrint(typeof(Func<double>));
        md.RemoveHandler(h3);
        md.DispatchAndPrint(typeof(Func<double>));
    }

    void Test(Func<String> h1, Func<String> h2)
    {
        h1 += h2;
    }
}


class MultiDelegator
{
    private Dictionary<Type, Delegate> handlers = new Dictionary<Type, Delegate>();

    public void AddHandler(Delegate h)
    {
        Delegate aux;

        if (handlers.ContainsKey(h.GetType()))
        {
            if (handlers.TryGetValue(h.GetType(), out aux))
            {
                aux = Delegate.Combine(aux, h);

                // aux += h;

                handlers.Remove(h.GetType());
                handlers.Add(h.GetType(), aux);
            }
        }
        else
            handlers.Add(h.GetType(), h);
    }

    public void RemoveHandler(Delegate h)
    {
        Delegate aux, res;

        if (handlers.TryGetValue(h.GetType(), out aux))
        {
            res = Delegate.Remove(aux, h);
            handlers.Remove(h.GetType());
            handlers.Add(h.GetType(), res);
        }
    }


    public void DispatchAndPrint(Type t)
    {
        Delegate aux;

        if (handlers.TryGetValue(t, out aux))
        {
            foreach (Delegate a in aux.GetInvocationList())
            {
                Console.WriteLine(a.DynamicInvoke());
            }
        }
    }

}