
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly task
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module task.exe
// MVID: {4A214C54-F966-4745-B63E-E357332E0086}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x00AB0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Program
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  Main() cil managed
  {
    .entrypoint
    // Code size       188 (0xbc)
    .maxstack  3
    .locals init (string V_0,
             class [mscorlib]System.Random V_1,
             int32 V_2,
             int32 V_3,
             string V_4,
             int32 V_5,
             bool V_6)
    IL_0000:  nop
    IL_0001:  call       void [mscorlib]System.Console::Clear()
    IL_0006:  nop
    IL_0007:  ldstr      bytearray (2F 04 20 00 13 20 20 00 38 04 3D 04 42 04 35 04   // /. ..  .8.=.B.5.
                                    3B 04 3B 04 35 04 3A 04 42 04 43 04 30 04 3B 04   // ;.;.5.:.B.C.0.;.
                                    4C 04 3D 04 4B 04 39 04 20 00 3A 04 30 04 3B 04   // L.=.K.9. .:.0.;.
                                    4C 04 3A 04 43 04 3B 04 4F 04 42 04 3E 04 40 04   // L.:.C.;.O.B.>.@.
                                    21 00 )                                           // !.
    IL_000c:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_0011:  nop
    IL_0012:  ldstr      bytearray (1A 04 30 04 3A 04 20 00 42 04 35 04 31 04 4F 04   // ..0.:. .B.5.1.O.
                                    20 00 37 04 3E 04 32 04 43 04 42 04 3F 00 )       //  .7.>.2.C.B.?.
    IL_0017:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_001c:  nop
    IL_001d:  call       string [mscorlib]System.Console::ReadLine()
    IL_0022:  stloc.0
    IL_0023:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_0028:  stloc.1
    IL_0029:  ldloc.1
    IL_002a:  ldc.i4.1
    IL_002b:  ldc.i4.s   11
    IL_002d:  callvirt   instance int32 [mscorlib]System.Random::Next(int32,
                                                                      int32)
    IL_0032:  stloc.2
    IL_0033:  ldloc.1
    IL_0034:  ldc.i4.1
    IL_0035:  ldc.i4.s   11
    IL_0037:  callvirt   instance int32 [mscorlib]System.Random::Next(int32,
                                                                      int32)
    IL_003c:  stloc.3
    IL_003d:  ldstr      bytearray (21 04 3A 04 3E 04 3B 04 4C 04 3A 04 3E 04 20 00   // !.:.>.;.L.:.>. .
                                    31 04 43 04 34 04 35 04 42 04 20 00 7B 00 30 00   // 1.C.4.5.B. .{.0.
                                    7D 00 20 00 2D 00 20 00 7B 00 31 00 7D 00 )       // }. .+. .{.1.}.
    IL_0042:  ldloc.2
    IL_0043:  box        [mscorlib]System.Int32
    IL_0048:  ldloc.3
    IL_0049:  box        [mscorlib]System.Int32
    IL_004e:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                  object,
                                                                  object)
    IL_0053:  nop
    IL_0054:  call       string [mscorlib]System.Console::ReadLine()
    IL_0059:  stloc.s    V_4
    .try
    {
      IL_005b:  nop
      IL_005c:  ldloc.s    V_4
      IL_005e:  call       int32 [mscorlib]System.Int32::Parse(string)
      IL_0063:  stloc.s    V_5
      IL_0065:  ldloc.s    V_5
      IL_0067:  ldloc.2
      IL_0068:  ldloc.3
      IL_0069:  sub
      IL_006a:  ceq
      IL_006c:  ldc.i4.0
      IL_006d:  ceq
      IL_006f:  stloc.s    V_6
      IL_0071:  ldloc.s    V_6
      IL_0073:  brtrue.s   IL_0085

      IL_0075:  nop
      IL_0076:  ldstr      bytearray (12 04 35 04 40 04 3D 04 3E 04 2C 00 20 00 7B 00   // ..5.@.=.>.,. .{.
                                      30 00 7D 00 21 00 )                               // 0.}.!.
      IL_007b:  ldloc.0
      IL_007c:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_0081:  nop
      IL_0082:  nop
      IL_0083:  br.s       IL_0093

      IL_0085:  nop
      IL_0086:  ldstr      bytearray (7B 00 30 00 7D 00 2C 00 20 00 42 04 4B 04 20 00   // {.0.}.,. .B.K. .
                                      3D 04 35 04 20 00 3F 04 40 04 30 04 32 04 2E 00 ) // =.5. .?.@.0.2...
      IL_008b:  ldloc.0
      IL_008c:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_0091:  nop
      IL_0092:  nop
      IL_0093:  nop
      IL_0094:  leave.s    IL_00ba

    }  // end .try
    catch [mscorlib]System.FormatException 
    {
      IL_0096:  pop
      IL_0097:  nop
      IL_0098:  ldstr      "{0}: Bad Format"
      IL_009d:  ldloc.s    V_4
      IL_009f:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_00a4:  nop
      IL_00a5:  nop
      IL_00a6:  leave.s    IL_00ba

    }  // end handler
    catch [mscorlib]System.OverflowException 
    {
      IL_00a8:  pop
      IL_00a9:  nop
      IL_00aa:  ldstr      "{0}: Overflow"
      IL_00af:  ldloc.s    V_4
      IL_00b1:  call       void [mscorlib]System.Console::WriteLine(string,
                                                                    object)
      IL_00b6:  nop
      IL_00b7:  nop
      IL_00b8:  leave.s    IL_00ba

    }  // end handler
    IL_00ba:  nop
    IL_00bb:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file ILCode.res
