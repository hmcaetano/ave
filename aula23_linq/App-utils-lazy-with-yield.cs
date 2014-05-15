using System;
using System.Collections.Generic;

public delegate int Comparison<in T>(T o1, T o2);

static class Collections
{

    public static T First<T>(this IEnumerable<T> elems)
    {
        IEnumerator<T> iter = elems.GetEnumerator();
        iter.MoveNext();
        return iter.Current;
    }

    public static IEnumerable<T> Distinct<T>(this IEnumerable<T> elems)
    {
        List<T> read = new List<T>();
        foreach(T elem in elems){
            if (!read.Contains(elem)) {
                read.Add(elem);
                yield return elem;
            }
        }
    }

    public static IEnumerable<T> Skip<T>(this IEnumerable<T> elems, int n)
    {
        foreach (T elem in elems) {
            if (n == 0)
                yield return elem;
            else
                n--;
        }
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> elems, Func<T, bool> f) {
        foreach (T item in elems)
        {
            if (f(item))
                yield return item;
        }
    }

    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> elems, Func<T, R> f)
    {
        foreach (T item in elems)
        {
            yield return f(item);
        }
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
            new Student(344, "Elias Baptista"), 
            new Student(78, "Gil Afonso"), 
            new Student(123, "Maria Solnado"), 
            new Student(78, "Gil Barnabe"), 
            new Student(78, "Gil Fernandes"), 
            new Student(204, "Zé Saraiva") };


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

        /*
        String std = a.Filter(s => { Console.WriteLine("Filtering"); return s.nr > 200; })
            .Select(s => {Console.WriteLine("Selecting"); return s + ", ";})
            .First();
        */

        IEnumerable<String> firstName = a.Select(s => s.name.Split(new char[] { ' ' })[0]);

        IEnumerable<String> firstNameNoRepeat =  firstName.Distinct();
        
        IEnumerable<String> firstNameExceptFirstTwo =  firstNameNoRepeat.Skip(2);
            
        // IEnumerable<int> stats = cacl(firstNameNoRepeat);

        String name = firstNameExceptFirstTwo.First();

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