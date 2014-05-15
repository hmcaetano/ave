using System;
using System.Collections;
using System.Collections.Generic;

public struct Student
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

public class LazyFilterEnum<T> : IEnumerator<T>
{
    private IEnumerator<T> elems;
    private Func<T, bool> predicate;

    public LazyFilterEnum(IEnumerable<T> elems, Func<T, bool> f)
    {
        this.elems = elems.GetEnumerator();
        predicate = f;
    }
    public bool MoveNext()
    {
        while (elems.MoveNext())
            if (predicate(elems.Current))
                return true;
        return false;
    }

    public void Reset()
    {
        elems.Reset();
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public T Current
    {
        get
        {
            return elems.Current;
 
        }
    }

    public void Dispose()
    {
        elems.Dispose();
    }
}

public class LazySelectEnum<T, R> : IEnumerator<R>
{
    private IEnumerator<T> elems;
    private Func<T,R> func;

    public LazySelectEnum(IEnumerable<T> elems, Func<T, R> f)
    {
        this.elems = elems.GetEnumerator();
        func = f;
    }
    public bool MoveNext()
    {
        return elems.MoveNext();
    }

    public void Reset()
    {
        elems.Reset();
    }

    object IEnumerator.Current
    {
        get { return Current; }
    }

    public R Current
    {
        get
        {
            return func(elems.Current);

        }
    }

    public void Dispose()
    {
        elems.Dispose();
    }
}


public class LazyFilter<T> : IEnumerable<T>
{
    private readonly IEnumerable<T> src;
    private readonly Func<T, bool> f;

    public LazyFilter(IEnumerable<T> elems, Func<T, bool> f)
    {
        src = elems;
        this.f = f;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new LazyFilterEnum<T>(src, f);
    }
}

public class LazySelect<T, R> : IEnumerable<R>
{
    private readonly IEnumerable<T> src;
    private readonly Func<T, R> f;

    public LazySelect(IEnumerable<T> elems, Func<T, R> f)
    {
        src = elems;
        this.f = f;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<R> GetEnumerator()
    {
        return new LazySelectEnum<T, R>(src, f);
    }
}

static class Collections
{

    public static T First<T>(this IEnumerable<T> elems)
    {
        IEnumerator<T> iter = elems.GetEnumerator();
        iter.MoveNext();
        return iter.Current;
    }

    public static IEnumerable<T> Filter<T>(this IEnumerable<T> elems, Func<T, bool> f)
    {
        return new LazyFilter<T>(elems, f);
    }

    public static IEnumerable<R> Select<T, R>(this IEnumerable<T> elems, Func<T, R> f)
    {
        return new LazySelect<T, R>(elems, f);
    }
    public static void Foreach<T>(this IEnumerable<T> elems, Action<T> f)
    {
        foreach (T item in elems)
        {
            f(item);
        }
    }
}

class Program
{
    static void Main()
    {
        List<Student> a = new List<Student> { 
        new Student(344, "Elias"), 
        new Student(123, "Maria"), 
        new Student(78, "Gil"), 
        new Student(204, "Zé") };

        String std = a.Filter(s => { Console.WriteLine("Filtering"); return s.nr < 200; })
            .Select(s => { Console.WriteLine("Selecting"); return s + ", "; })
            .First();

        Console.WriteLine(std);
    }
}