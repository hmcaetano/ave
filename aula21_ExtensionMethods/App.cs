using System;
using System.Collections.Generic;

public delegate int Comparison<in T>(T o1, T o2);

// abstract sealed class Collections
static class Collections
{
    public static List<T> Sorted<T>(this List<T> elems, Comparison<T> cmp)
    {
        for (int i = 1; i < elems.Count; i++)
            for (int j = i; j > 0 &&
                     // cmp(elems[j - 1], elems[j]) > 0; j--)
                     cmp.Invoke(elems[j - 1], elems[j]) > 0; j--)
            {
                T t = elems[j - 1];
                elems[j - 1] = elems[j];
                elems[j] = t;
            }
        return elems;
    }

    public static List<T> Filter<T>(this List<T> elems, Func<T, bool> f) {
        List<T> res = new List<T>();
        foreach (T item in elems)
        {
            if (f(item))
                res.Add(item);
        }
        return res;
    }

    public static void Foreach<T>(this IEnumerable<T> elems, Action<T> f)
    {
        foreach (T item in elems)
        {
            f(item);
        }
    }
}

class App
{
    static void Main()
    {
        List<Student> a = new List<Student> { 
            new Student(344, "Elias"), 
            new Student(123, "Maria"), 
            new Student(78, "Gil"), 
            new Student(204, "Zé") };


        /*
        List<Student> r = Collections.Filter(a, s => s.nr > 200);
        Collections.Sort(r, (s1, s2) => s1.nr - s2.nr);
        Collections.Foreach(r, s => Console.Write(s + ", "));
        */

        // 2nd version => Chain method calls
        /*
        Collections.Foreach(
            Collections.Sort(
                Collections.Filter(a, s => s.nr > 200), 
                (s1, s2) => s1.nr - s2.nr), 
                s => Console.Write(s + ", "));
         */
        
        a.Filter(s => s.nr > 200)
            .Sorted((s1, s2) => s1.nr - s2.nr)
            .Foreach(s => Console.Write(s + ", "));

    }
}


struct Student
{
    public readonly int nr;
    public readonly String name;

    public Student(int nr, String name)
    {
        this.nr = nr;
        this.name = name;
    }

    public override String ToString()
    {
        return nr + " " + name;
    }

    public static Student Parse(String line)
    {
        int nr = int.Parse(line.Substring(0, 5));
        String name = line.Substring(6);
        return new Student(nr, name);
    }
}