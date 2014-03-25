
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
.assembly App
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module App.exe
// MVID: {E09111A3-BEF3-434A-8DE1-C66DD32AFE79}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0000000001E00000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit App
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       26 (0x1a)
    .maxstack  2
    .locals init (class [Ponto]Ponto V_0,
             class [Ponto]Ponto V_1)
    IL_0000:  nop
    IL_0001:  ldc.i4.3
    IL_0002:  ldc.i4.4
    IL_0003:  newobj     instance void [Ponto]Ponto::.ctor(int32,
                                                           int32)
    IL_0008:  stloc.0
    IL_0009:  ldnull
    IL_000a:  stloc.1
    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance void [Ponto]Ponto::Print()
    IL_0011:  nop
    IL_0012:  ldloc.1
    IL_0013:  call   instance void [Ponto]Ponto::Print()
    IL_0018:  nop
    IL_0019:  ret
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
// WARNING: Created Win32 resource file C:\MyFolder\ISEL\Pg5 ave - 2013-2014 - 2º sem\aulas\aula08-test-instance-method-callvirt\AppIL.res
