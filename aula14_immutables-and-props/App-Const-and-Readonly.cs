using System;


class Student { 
}

class App{

    const string MY_SCHOOL = "ISEL"; // Implicitamente um membro estático = classe

    // Erro de Compilação
    // const Student DEFAULT_STUDENT = new Student(); // avaliado em Tempo de Execução => não pode ser Const

    readonly Student DEFAULT_STUDENT = new Student(); 

    static void Main()
    {
        Console.WriteLine(App.MY_SCHOOL);
    }
}