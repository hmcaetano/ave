using System;
using System.Reflection;


[AttributeUsage(AttributeTargets.Method)]
class MySpecial : Attribute
{
}

class MySpecialAttribute : Attribute 
{
    public readonly string msg;
    public readonly int nr;
    public MySpecialAttribute(string msg, int nr) {
        this.msg = msg;
        this.nr = nr;
        Description = "DEFAULT";
    }

    public string Description { get; set; }
}

[MySpecialAttribute("ola", 5)]
class A
{
    // [MySpecialAttribute] // => Erro de compilação 
    [MySpecialAttribute("isel", 2)]
    public int x = 0;

    [MySpecialAttribute("xtpo", 7, Description = "Super Special!!!")]
    // [MySpecialAttribute("xpty", 9)]
    [@MySpecial]
    public int m() {
        return x;
    }
}

class App
{
    static void Main() 
    {
        foreach (MemberInfo m in typeof(A).GetMembers())
        {
            // object[]  attrs = m.GetCustomAttributes(typeof(MySpecialAttribute), false);
            MySpecialAttribute a = (MySpecialAttribute)Attribute.GetCustomAttribute(m, typeof(MySpecialAttribute));
            if(a != null)
                Console.WriteLine("Member {0}: {1} {2} {3}", m.Name, a.msg, a.nr, a.Description);
        }
    }
}