using System;

class Program{
	private static void Main(){
		Console.Write("Introduza uma valor inteiro: ");
		String s = Console.ReadLine();
		int n1 = Int32.Parse(s);
    Console.Write("Introduza outro valor inteiro: ");
		s = Console.ReadLine();
		int n2 = Int32.Parse(s);
		Console.WriteLine("===== O resultado de Calcula no tipo CompA = {0}", CompA.Calcula(n1, n2));
		Console.WriteLine("===== O resultado de Calcula no tipo CompB = {0}", CompB.Calcula(n1, n2));
	}
}