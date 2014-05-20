using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main()
    {
        Probe.Inspect("Probe.exe");
    }
}

class Probe
{
    public static void Inspect(string path) 
    {
        Assembly a = Assembly.LoadFrom(path);
        foreach (Type t in a.GetTypes()) {
            foreach (MethodInfo m in t.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine(t.Name + "::" + m.Name);
                m.getpa
            }
        }
    }

}