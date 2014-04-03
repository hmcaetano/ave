using System;

/*
 * Employee <- Operator 
 * Employee <- Manager <- Boss <- Owner
 */
class Employee
{
    /*
     * Não virtual
     */
    public void Print()
    {
        Console.WriteLine(this.ToString());
    }

    public override bool Equals(Object o){
        if (o == null) return false;
        if (this == o) return true;
        Employee e = o as Employee;
        return e != null;
    }
}

class Operator : Employee
{

    public override String ToString()
    {
        return String.Format("I am a Operator");
    }

}

class Manager : Employee
{

    public new virtual String ToString()
    {
        return String.Format("I am a Manager");
    }

}

class Boss: Manager
{

    public override String ToString()
    {
        return String.Format("I am a Boss");
    }

}

class Owner : Boss
{

    public override String ToString()
    {
        return String.Format("I am a Owner");
    }

}

/*
 * Employee <- Operator 
 * Employee <- Manager <- Boss <- Owner
 */
class Program
{
   static void Main()
   {
       Employee e = new Manager();
       Employee opr = new Operator();
       /*
        e.Print(); // inspect call in disassembly
        e.Equals(opr); // inspect call in disassembly
        */

       Console.WriteLine(e);
       Console.WriteLine((Manager)e);
       Console.WriteLine((Boss)e);
       Console.WriteLine((Owner)e);

       Console.WriteLine(opr);
       Console.WriteLine((Operator) opr);
       Console.WriteLine((Manager)opr);
   }
}