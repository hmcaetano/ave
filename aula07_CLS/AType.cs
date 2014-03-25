
// Estou a dizer ao compilador que quero gerar um componente reutilizável e que cumpre o CLS.
// ==> O compilador verifica se estão a ser cumpridas as regras do CL


[assembly: System.CLSCompliant(true)]
[type: System.CLSCompliant(true)]
public class A{
  public void m(){
  }
  public void M() { 

  }
  static void Main() { 
  }
}