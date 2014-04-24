using System;

class A<Tx, Ty> {

    public void m<Tm>(Tm z) { 
        z.   
    }

    public void f<Tf>(Tx x, Tf r)
    {
        Tf obj = (Tf) Activator.CreateInstance(typeof(Tf));
    }

}

class B : A<String, Student> { 

}

class C : A<String, Student>
{

}


class Student { 
}

class Account { 
}

class Program{
	static void Main(){
        A<string, Student> a1 = new A<string, Student>();
        // A a2 = new A<string, Student>(); // Erro de compilação.

        a1.f<Student>("isel", new Student());
        a1.f("isel", new Student()); // O Tf é inferido a partir do 2º argumento
	}
}