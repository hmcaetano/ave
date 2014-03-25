using System;

public class A{
	public static void Init() {
		System.Console.WriteLine("Initializing A");
	}  
	public static void Hello() {
		System.Console.WriteLine("Hello from A");
	}
}

public class Teste {
 	public static void Main() {
		Console.WriteLine("Teste begin...");
		A.Init();
		A.Hello();
	}
	public static void Isel(){}
	public static void Fcp(){}
}
