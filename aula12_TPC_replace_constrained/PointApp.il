
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern Point
{
  .ver 0:0:0:0
}
.assembly PointApp
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module PointApp.exe
// MVID: {7168B77A-2810-4F59-B9B0-1E06758CDE3C}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0000000001E90000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit App
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       75 (0x4b)
    .maxstack  3
    .locals init (valuetype [Point]Point V_0)
    IL_0000:  nop
    IL_0001:  ldloca.s   V_0
    IL_0003:  ldc.i4.7
    IL_0004:  ldc.i4.3
    IL_0005:  call       instance void [Point]Point::.ctor(int32,
                                                           int32)
    IL_000a:  nop
    IL_000b:  ldloca.s   V_0
    IL_000d:  call       instance void [Point]Point::Print()
    IL_0012:  nop
    IL_0013:  ldloc.0
    
    IL_001b:  call   instance string [Point]Point::ToString()
    IL_0020:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0025:  nop
    IL_0026:  ldloc.0
    IL_0027:  box        [Point]Point
    IL_002c:  call       instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_0031:  call       void [mscorlib]System.Console::WriteLine(object)
    IL_0036:  nop
    IL_0037:  ldloca.s   V_0
    IL_0039:  constrained. [Point]Point
    IL_003f:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0044:  call       void [mscorlib]System.Console::WriteLine(int32)
    IL_0049:  nop
    IL_004a:  ret
  } // end of method App::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method App::.ctor

} // end of class App


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\Pg5 ave - 2013-2014 - 2º sem\aulas\aula12_TPC_replace_constrained\PointApp.res
