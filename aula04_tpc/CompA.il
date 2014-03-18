.assembly extern mscorlib{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                        
  .ver 2:0:0:0
}

.assembly CompA{
  .ver 1:0:0:0
}
 
.class public auto CompA{
  	
	.method public hidebysig static int32  Calcula(int32 a, int32 b) cil managed{
    .maxstack  2
    .locals init (int32 V_0)
    br.s       FCP
  OMaior:  
    ldarg.0
    ldarg.1
    rem
    stloc.0
    ldarg.1
    starg.s    a
    ldloc.0
    starg.s    b
  FCP:  
    ldarg.1
    brtrue.s   OMaior
    ldarg.0
    ret
	} // end of method CompA::Calcula
}