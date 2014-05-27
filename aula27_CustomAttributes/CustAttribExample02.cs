using System;
using System.Runtime.InteropServices;

// [Flags]
// [class: Flags]
// [FlagsAtribute]
// [Serializable]
[Flags, Serializable] // Equivalente às duas linhas acima.
enum Actions{
	None = 0x01,
	Read = 0x02, 
	Write = 0x04,
	ReadWrite = Read | Write,
	Delete = 0x08, 
	Query = 0x10
}

class Sample {
   [DllImport("user32.dll")]
   public static extern int  MessageBoxA(int p, string m, string h, int t);
   
    public static void Main()  {
      Actions ac = Actions.Write | Actions.Query;
      Console.WriteLine(ac);

      MessageBoxA(0, "Hello World!",  "DLLImport Sample", 0);
      
      System.Windows.Forms.MessageBox.Show("Hello World!",  "Windows Forms Sample");      
   }
}
