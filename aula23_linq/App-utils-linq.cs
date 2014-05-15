using System;
using System.Collections.Generic;
using System.Linq;

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


        a.Where(s => { Console.WriteLine("Filtering"); return s.nr < 200; })
            .Select(s => { Console.WriteLine("Selecting"); return s + ", "; })
            .Skip(2)
            .ToList()
            .ForEach(Console.Write);

        
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