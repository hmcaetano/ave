using System;


class Student { 
}

class App{

    const string MY_SCHOOL = "ISEL"; // Implicitamente um membro est�tico = classe

    // Erro de Compila��o
    // const Student DEFAULT_STUDENT = new Student(); // avaliado em Tempo de Execu��o => n�o pode ser Const

    readonly Student DEFAULT_STUDENT = new Student(); 

    static void Main()
    {
        Console.WriteLine(App.MY_SCHOOL);
    }
}