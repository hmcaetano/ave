using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
class Transactional : Attribute
{
}


[AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
class MyAttribute : Attribute
{
}

[My("Ola")]
[My(MyValue = 5)]
[My(_any = "isel")]
class A
{

    [Transactional]
    void Xpto()
    {
    }
}

class Program
{
    static void Main()
    {

    }

}