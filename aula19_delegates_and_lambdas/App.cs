using System;
using System.Collections.Generic;

/*
 * 1st version => specify behavior through a Functional Interface -- 
 * interface containing just one method.
 */
interface Comparator<T>
{
    int Compare(T o1, T o2);
}

/*
 * 2nd version => specify behavior through a delegate.
 */
public delegate int Comparison<in T>(T o1, T o2);

class Collections
{

    /*
     * 1st version => specify behavior through a Functional Interface -- 
     * interface containing just one method.
     */
    public static void Sort<T>(List<T> elems, Comparator<T> cmp)
    {
        for (int i = 1; i < elems.Count; i++)
            for (int j = i; j > 0 &&
                     cmp.Compare(elems[j - 1], elems[j]) > 0; j--)
            {
                T t = elems[j-1];
                elems[j-1] = elems[j];
                elems[j] = t;
            }
    }

    /*
     * 2nd version => specify behavior through a delegate.
     */
    public static void Sort<T>(List<T> elems, Comparison<T> cmp)
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
    }
}

class App
{
    static void Print<T>(IEnumerable<T> elems) {
        foreach (T elem in elems)
        {
            Console.Write(elem + ", ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        List<Student> a = new List<Student> { 
            new Student(344, "Elias"), 
            new Student(123, "Maria"), 
            new Student(78, "Gil"), 
            new Student(204, "Zé") };

        Print(a);
        
        // Collections.Sort(a, new CmpStdById()); // 1st version 
        // Collections.Sort(a, new Comparison<Student>(App.CompareStdById)); // 2nd version 
        // Collections.Sort(a, App.CompareStdById); // 2nd version -- Method Handle
        Collections.Sort(a, (s1, s2) => s1.nr - s2.nr); // 3rd version -- Lambda Expression
        // Collections.Sort(a, (s1, s2) => s1.name.CompareTo(s2.name)); // 3rd version -- Lambda Expression
        Print(a);

    }

    /*
     * 2nd version =>  specify behavior through a method compliant with the delegate Comparison
     */
    private static int CompareStdById(Student s1, Student s2)
    {
        return s1.nr - s2.nr;
    }

    /*
     * 1st version => specify behavior through the implementation of the Interface Comparator
     */
    class CmpStdById : Comparator<Student> {

        public int Compare(Student s1, Student s2)
        {
            return s1.nr - s2.nr;
        }
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