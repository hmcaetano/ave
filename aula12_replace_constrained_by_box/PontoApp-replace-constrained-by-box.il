
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern Ponto
{
  .ver 0:0:0:0
}
.assembly PontoApp
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module PontoApp.exe
// MVID: {D4736238-DE10-4B21-A995-5A8B386C4003}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00000000003D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit App
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       76 (0x4c)
    .maxstack  8
    .locals init (valuetype [Ponto]PontoVal V_0,
             valuetype [Ponto]PontoVal V_1,
             class [Ponto]PontoRef V_2,
             class [Ponto]PontoRef V_3)
    IL_0000:  nop
    IL_0001:  ldloca.s   V_0
    IL_0003:  ldc.i4.3
    IL_0004:  ldc.i4.4
    IL_0005:  call       instance void [Ponto]PontoVal::.ctor(int32,
                                                              int32)
    IL_000a:  nop
    IL_000b:  ldloca.s   V_1
    IL_000d:  ldc.i4.3
    IL_000e:  ldc.i4.4
    IL_000f:  call       instance void [Ponto]PontoVal::.ctor(int32,
                                                              int32)
    IL_0014:  nop
	
	// Replace constrained by box operation
	
    IL_0015:  ldloc.0 
    IL_0017:  box        [Ponto]PontoVal
    IL_0018:  ldloc.1
    IL_001d:  box        [Ponto]PontoVal
    IL_0023:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0028:  call       void [mscorlib]System.Console::WriteLine(bool)
    IL_002d:  nop
    IL_002e:  ldc.i4.3
    IL_002f:  ldc.i4.4
    IL_0030:  newobj     instance void [Ponto]PontoRef::.ctor(int32,
                                                              int32)
    IL_0035:  stloc.2
    IL_0036:  ldc.i4.3
    IL_0037:  ldc.i4.4
    IL_0038:  newobj     instance void [Ponto]PontoRef::.ctor(int32,
                                                              int32)
    IL_003d:  stloc.3
    IL_003e:  ldloc.2
    IL_003f:  ldloc.3
    IL_0040:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0045:  call       void [mscorlib]System.Console::WriteLine(bool)
    IL_004a:  nop
    IL_004b:  ret
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
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\Pg5 ave - 2013-2014 - 2º sem\aulas\aula12\PontoApp.res
