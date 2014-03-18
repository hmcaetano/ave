.assembly extern mscorlib{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                        
  .ver 2:0:0:0
}

.assembly CompB{
  .ver 1:0:0:0
}
 
.class public auto CompB{
  	
	.method public hidebysig static int32  Calcula(int32 m, int32 n) cil managed{
	  .maxstack  8
    ldarg.1
    ldarg.0
    bgt.s      OMaior
    ldarg.1
    ldc.i4.0
    bgt.s      FCP
    ldarg.0
    ret
  FCP:  
    ldarg.1
    ldarg.0
    ldarg.1
    rem
    call       int32 CompB::Calcula(int32, int32)
    ret
  OMaior:  
    ldarg.1
    ldarg.0
    call       int32 CompB::Calcula(int32, int32)
    ret
	} // end of method CompB::Calcula
}