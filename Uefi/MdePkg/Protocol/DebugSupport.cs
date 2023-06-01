namespace Uefi;
/** @file
  DebugSupport protocol and supporting definitions as defined in the UEFI2.4
  specification.

  The DebugSupport protocol is used by source level debuggers to abstract the
  processor and handle context save and restore operations.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
Portions copyright (c) 2011 - 2013, ARM Ltd. All rights reserved.<BR>
Copyright (c) 2020, Hewlett Packard Enterprise Development LP. All rights reserved.<BR>

SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DEBUG_SUPPORT_H__
// #define __DEBUG_SUPPORT_H__

// #include <IndustryStandard/PeImage.h>

// typedef struct _EFI_DEBUG_SUPPORT_PROTOCOL EFI_DEBUG_SUPPORT_PROTOCOL;

///
/// Debug Support protocol {2755590C-6F3C-42FA-9EA4-A3BA543CDA25}.
///
public static EFI_GUID EFI_DEBUG_SUPPORT_PROTOCOL_GUID = new GUID( 
    0x2755590C, 0x6F3C, 0x42FA, new byte[] {0x9E, 0xA4, 0xA3, 0xBA, 0x54, 0x3C, 0xDA, 0x25 });

///
/// Processor exception to be hooked.
/// All exception types for IA32, X64, Itanium and EBC processors are defined.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_EXCEPTION_TYPE { long Value; public static implicit operator EFI_EXCEPTION_TYPE(long value) => new EFI_EXCEPTION_TYPE() { Value = value }; public static implicit operator long(EFI_EXCEPTION_TYPE value) => value.Value;}

///
///  IA-32 processor exception types.
///
public static ulong EXCEPT_IA32_DIVIDE_ERROR = 0;
public static ulong EXCEPT_IA32_DEBUG = 1;
public static ulong EXCEPT_IA32_NMI = 2;
public static ulong EXCEPT_IA32_BREAKPOINT = 3;
public static ulong EXCEPT_IA32_OVERFLOW = 4;
public static ulong EXCEPT_IA32_BOUND = 5;
public static ulong EXCEPT_IA32_INVALID_OPCODE = 6;
public static ulong EXCEPT_IA32_DOUBLE_FAULT = 8;
public static ulong EXCEPT_IA32_INVALID_TSS = 10;
public static ulong EXCEPT_IA32_SEG_NOT_PRESENT = 11;
public static ulong EXCEPT_IA32_STACK_FAULT = 12;
public static ulong EXCEPT_IA32_GP_FAULT = 13;
public static ulong EXCEPT_IA32_PAGE_FAULT = 14;
public static ulong EXCEPT_IA32_FP_ERROR = 16;
public static ulong EXCEPT_IA32_ALIGNMENT_CHECK = 17;
public static ulong EXCEPT_IA32_MACHINE_CHECK = 18;
public static ulong EXCEPT_IA32_SIMD = 19;

///
/// FXSAVE_STATE.
/// FP / MMX / XMM registers (see fxrstor instruction definition).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FX_SAVE_STATE_IA32 {
 public ushort    Fcw;
 public ushort    Fsw;
 public ushort    Ftw;
 public ushort    Opcode;
 public uint    Eip;
 public ushort    Cs;
 public ushort    Reserved1;
 public uint    DataOffset;
 public ushort    Ds;
 public fixed byte     Reserved2[10];
 public fixed byte     St0Mm0[10], Reserved3[6];
 public fixed byte     St1Mm1[10], Reserved4[6];
 public fixed byte     St2Mm2[10], Reserved5[6];
 public fixed byte     St3Mm3[10], Reserved6[6];
 public fixed byte     St4Mm4[10], Reserved7[6];
 public fixed byte     St5Mm5[10], Reserved8[6];
 public fixed byte     St6Mm6[10], Reserved9[6];
 public fixed byte     St7Mm7[10], Reserved10[6];
 public fixed byte     Xmm0[16];
 public fixed byte     Xmm1[16];
 public fixed byte     Xmm2[16];
 public fixed byte     Xmm3[16];
 public fixed byte     Xmm4[16];
 public fixed byte     Xmm5[16];
 public fixed byte     Xmm6[16];
 public fixed byte     Xmm7[16];
public  bytepublic  public   Reserved11[14 * 16];
}

///
///  IA-32 processor context definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_IA32 {
 public uint                    ExceptionData;
 public EFI_FX_SAVE_STATE_IA32    FxSaveState;
 public uint                    Dr0;
 public uint                    Dr1;
 public uint                    Dr2;
 public uint                    Dr3;
 public uint                    Dr6;
 public uint                    Dr7;
 public uint                    Cr0;
 public uint                    Cr1; /* Reserved */
 public uint                    Cr2;
 public uint                    Cr3;
 public uint                    Cr4;
 public uint                    Eflags;
 public uint                    Ldtr;
 public uint                    Tr;
 public fixed uint                    Gdtr[2];
 public fixed uint                    Idtr[2];
 public uint                    Eip;
 public uint                    Gs;
 public uint                    Fs;
 public uint                    Es;
 public uint                    Ds;
 public uint                    Cs;
 public uint                    Ss;
 public uint                    Edi;
 public uint                    Esi;
 public uint                    Ebp;
 public uint                    Esp;
 public uint                    Ebx;
 public uint                    Edx;
 public uint                    Ecx;
 public uint                    Eax;
}

///
///  x64 processor exception types.
///
public static ulong EXCEPT_X64_DIVIDE_ERROR = 0;
public static ulong EXCEPT_X64_DEBUG = 1;
public static ulong EXCEPT_X64_NMI = 2;
public static ulong EXCEPT_X64_BREAKPOINT = 3;
public static ulong EXCEPT_X64_OVERFLOW = 4;
public static ulong EXCEPT_X64_BOUND = 5;
public static ulong EXCEPT_X64_INVALID_OPCODE = 6;
public static ulong EXCEPT_X64_DOUBLE_FAULT = 8;
public static ulong EXCEPT_X64_INVALID_TSS = 10;
public static ulong EXCEPT_X64_SEG_NOT_PRESENT = 11;
public static ulong EXCEPT_X64_STACK_FAULT = 12;
public static ulong EXCEPT_X64_GP_FAULT = 13;
public static ulong EXCEPT_X64_PAGE_FAULT = 14;
public static ulong EXCEPT_X64_FP_ERROR = 16;
public static ulong EXCEPT_X64_ALIGNMENT_CHECK = 17;
public static ulong EXCEPT_X64_MACHINE_CHECK = 18;
public static ulong EXCEPT_X64_SIMD = 19;

///
/// FXSAVE_STATE.
/// FP / MMX / XMM registers (see fxrstor instruction definition).
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FX_SAVE_STATE_X64 {
 public ushort    Fcw;
 public ushort    Fsw;
 public ushort    Ftw;
 public ushort    Opcode;
 public ulong    Rip;
 public ulong    DataOffset;
 public fixed byte     Reserved1[8];
 public fixed byte     St0Mm0[10], Reserved2[6];
 public fixed byte     St1Mm1[10], Reserved3[6];
 public fixed byte     St2Mm2[10], Reserved4[6];
 public fixed byte     St3Mm3[10], Reserved5[6];
 public fixed byte     St4Mm4[10], Reserved6[6];
 public fixed byte     St5Mm5[10], Reserved7[6];
 public fixed byte     St6Mm6[10], Reserved8[6];
 public fixed byte     St7Mm7[10], Reserved9[6];
 public fixed byte     Xmm0[16];
 public fixed byte     Xmm1[16];
 public fixed byte     Xmm2[16];
 public fixed byte     Xmm3[16];
 public fixed byte     Xmm4[16];
 public fixed byte     Xmm5[16];
 public fixed byte     Xmm6[16];
 public fixed byte     Xmm7[16];
  //
  // NOTE: UEFI 2.0 spec definition as follows.
  //
public  bytepublic  public   Reserved11[14 * 16];
}

///
///  x64 processor context definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_X64 {
 public ulong                   ExceptionData;
 public EFI_FX_SAVE_STATE_X64    FxSaveState;
 public ulong                   Dr0;
 public ulong                   Dr1;
 public ulong                   Dr2;
 public ulong                   Dr3;
 public ulong                   Dr6;
 public ulong                   Dr7;
 public ulong                   Cr0;
 public ulong                   Cr1; /* Reserved */
 public ulong                   Cr2;
 public ulong                   Cr3;
 public ulong                   Cr4;
 public ulong                   Cr8;
 public ulong                   Rflags;
 public ulong                   Ldtr;
 public ulong                   Tr;
 public fixed ulong                   Gdtr[2];
 public fixed ulong                   Idtr[2];
 public ulong                   Rip;
 public ulong                   Gs;
 public ulong                   Fs;
 public ulong                   Es;
 public ulong                   Ds;
 public ulong                   Cs;
 public ulong                   Ss;
 public ulong                   Rdi;
 public ulong                   Rsi;
 public ulong                   Rbp;
 public ulong                   Rsp;
 public ulong                   Rbx;
 public ulong                   Rdx;
 public ulong                   Rcx;
 public ulong                   Rax;
 public ulong                   R8;
 public ulong                   R9;
 public ulong                   R10;
 public ulong                   R11;
 public ulong                   R12;
 public ulong                   R13;
 public ulong                   R14;
 public ulong                   R15;
}

///
///  Itanium Processor Family Exception types.
///
public static ulong EXCEPT_IPF_VHTP_TRANSLATION = 0;
public static ulong EXCEPT_IPF_INSTRUCTION_TLB = 1;
public static ulong EXCEPT_IPF_DATA_TLB = 2;
public static ulong EXCEPT_IPF_ALT_INSTRUCTION_TLB = 3;
public static ulong EXCEPT_IPF_ALT_DATA_TLB = 4;
public static ulong EXCEPT_IPF_DATA_NESTED_TLB = 5;
public static ulong EXCEPT_IPF_INSTRUCTION_KEY_MISSED = 6;
public static ulong EXCEPT_IPF_DATA_KEY_MISSED = 7;
public static ulong EXCEPT_IPF_DIRTY_BIT = 8;
public static ulong EXCEPT_IPF_INSTRUCTION_ACCESS_BIT = 9;
public static ulong EXCEPT_IPF_DATA_ACCESS_BIT = 10;
public static ulong EXCEPT_IPF_BREAKPOINT = 11;
public static ulong EXCEPT_IPF_EXTERNAL_INTERRUPT = 12;
//
// 13 - 19 reserved
//
public static ulong EXCEPT_IPF_PAGE_NOT_PRESENT = 20;
public static ulong EXCEPT_IPF_KEY_PERMISSION = 21;
public static ulong EXCEPT_IPF_INSTRUCTION_ACCESS_RIGHTS = 22;
public static ulong EXCEPT_IPF_DATA_ACCESS_RIGHTS = 23;
public static ulong EXCEPT_IPF_GENERAL_EXCEPTION = 24;
public static ulong EXCEPT_IPF_DISABLED_FP_REGISTER = 25;
public static ulong EXCEPT_IPF_NAT_CONSUMPTION = 26;
public static ulong EXCEPT_IPF_SPECULATION = 27;
//
// 28 reserved
//
public static ulong EXCEPT_IPF_DEBUG = 29;
public static ulong EXCEPT_IPF_UNALIGNED_REFERENCE = 30;
public static ulong EXCEPT_IPF_UNSUPPORTED_DATA_REFERENCE = 31;
public static ulong EXCEPT_IPF_FP_FAULT = 32;
public static ulong EXCEPT_IPF_FP_TRAP = 33;
public static ulong EXCEPT_IPF_LOWER_PRIVILEGE_TRANSFER_TRAP = 34;
public static ulong EXCEPT_IPF_TAKEN_BRANCH = 35;
public static ulong EXCEPT_IPF_SINGLE_STEP = 36;
//
// 37 - 44 reserved
//
public static ulong EXCEPT_IPF_IA32_EXCEPTION = 45;
public static ulong EXCEPT_IPF_IA32_INTERCEPT = 46;
public static ulong EXCEPT_IPF_IA32_INTERRUPT = 47;

///
///  IPF processor context definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_IPF {
  //
  // The first reserved field is necessary to preserve alignment for the correct
  // bits in UNAT and to insure F2 is 16 byte aligned.
  //
 public ulong    Reserved;
 public ulong    R1;
 public ulong    R2;
 public ulong    R3;
 public ulong    R4;
 public ulong    R5;
 public ulong    R6;
 public ulong    R7;
 public ulong    R8;
 public ulong    R9;
 public ulong    R10;
 public ulong    R11;
 public ulong    R12;
 public ulong    R13;
 public ulong    R14;
 public ulong    R15;
 public ulong    R16;
 public ulong    R17;
 public ulong    R18;
 public ulong    R19;
 public ulong    R20;
 public ulong    R21;
 public ulong    R22;
 public ulong    R23;
 public ulong    R24;
 public ulong    R25;
 public ulong    R26;
 public ulong    R27;
 public ulong    R28;
 public ulong    R29;
 public ulong    R30;
 public ulong    R31;

 public fixed ulong    F2[2];
 public fixed ulong    F3[2];
 public fixed ulong    F4[2];
 public fixed ulong    F5[2];
 public fixed ulong    F6[2];
 public fixed ulong    F7[2];
 public fixed ulong    F8[2];
 public fixed ulong    F9[2];
 public fixed ulong    F10[2];
 public fixed ulong    F11[2];
 public fixed ulong    F12[2];
 public fixed ulong    F13[2];
 public fixed ulong    F14[2];
 public fixed ulong    F15[2];
 public fixed ulong    F16[2];
 public fixed ulong    F17[2];
 public fixed ulong    F18[2];
 public fixed ulong    F19[2];
 public fixed ulong    F20[2];
 public fixed ulong    F21[2];
 public fixed ulong    F22[2];
 public fixed ulong    F23[2];
 public fixed ulong    F24[2];
 public fixed ulong    F25[2];
 public fixed ulong    F26[2];
 public fixed ulong    F27[2];
 public fixed ulong    F28[2];
 public fixed ulong    F29[2];
 public fixed ulong    F30[2];
 public fixed ulong    F31[2];

 public ulong    Pr;

 public ulong    B0;
 public ulong    B1;
 public ulong    B2;
 public ulong    B3;
 public ulong    B4;
 public ulong    B5;
 public ulong    B6;
 public ulong    B7;

  //
  // application registers
  //
 public ulong    ArRsc;
 public ulong    ArBsp;
 public ulong    ArBspstore;
 public ulong    ArRnat;

 public ulong    ArFcr;

 public ulong    ArEflag;
 public ulong    ArCsd;
 public ulong    ArSsd;
 public ulong    ArCflg;
 public ulong    ArFsr;
 public ulong    ArFir;
 public ulong    ArFdr;

 public ulong    ArCcv;

 public ulong    ArUnat;

 public ulong    ArFpsr;

 public ulong    ArPfs;
 public ulong    ArLc;
 public ulong    ArEc;

  //
  // control registers
  //
 public ulong    CrDcr;
 public ulong    CrItm;
 public ulong    CrIva;
 public ulong    CrPta;
 public ulong    CrIpsr;
 public ulong    CrIsr;
 public ulong    CrIip;
 public ulong    CrIfa;
 public ulong    CrItir;
 public ulong    CrIipa;
 public ulong    CrIfs;
 public ulong    CrIim;
 public ulong    CrIha;

  //
  // debug registers
  //
 public ulong    Dbr0;
 public ulong    Dbr1;
 public ulong    Dbr2;
 public ulong    Dbr3;
 public ulong    Dbr4;
 public ulong    Dbr5;
 public ulong    Dbr6;
 public ulong    Dbr7;

 public ulong    Ibr0;
 public ulong    Ibr1;
 public ulong    Ibr2;
 public ulong    Ibr3;
 public ulong    Ibr4;
 public ulong    Ibr5;
 public ulong    Ibr6;
 public ulong    Ibr7;

  //
  // virtual registers - nat bits for R1-R31
  //
 public ulong    IntNat;
}

///
///  EBC processor exception types.
///
public static ulong EXCEPT_EBC_UNDEFINED = 0;
public static ulong EXCEPT_EBC_DIVIDE_ERROR = 1;
public static ulong EXCEPT_EBC_DEBUG = 2;
public static ulong EXCEPT_EBC_BREAKPOINT = 3;
public static ulong EXCEPT_EBC_OVERFLOW = 4;
public static ulong EXCEPT_EBC_INVALID_OPCODE = 5  ///< Opcode out of range.;
public static ulong EXCEPT_EBC_STACK_FAULT = 6;
public static ulong EXCEPT_EBC_ALIGNMENT_CHECK = 7;
public static ulong EXCEPT_EBC_INSTRUCTION_ENCODING = 8  ///< Malformed instruction.;
public static ulong EXCEPT_EBC_BAD_BREAK = 9  ///< BREAK 0 or undefined BREAK.;
public static ulong EXCEPT_EBC_STEP = 10 ///< To support debug stepping.;
///
/// For coding convenience, define the maximum valid EBC exception.
///
public static ulong MAX_EBC_EXCEPTION = EXCEPT_EBC_STEP;

///
///  EBC processor context definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_EBC {
 public ulong    R0;
 public ulong    R1;
 public ulong    R2;
 public ulong    R3;
 public ulong    R4;
 public ulong    R5;
 public ulong    R6;
 public ulong    R7;
 public ulong    Flags;
 public ulong    ControlFlags;
 public ulong    Ip;
}

///
///  ARM processor exception types.
///
public static ulong EXCEPT_ARM_RESET = 0;
public static ulong EXCEPT_ARM_UNDEFINED_INSTRUCTION = 1;
public static ulong EXCEPT_ARM_SOFTWARE_INTERRUPT = 2;
public static ulong EXCEPT_ARM_PREFETCH_ABORT = 3;
public static ulong EXCEPT_ARM_DATA_ABORT = 4;
public static ulong EXCEPT_ARM_RESERVED = 5;
public static ulong EXCEPT_ARM_IRQ = 6;
public static ulong EXCEPT_ARM_FIQ = 7;

///
/// For coding convenience, define the maximum valid ARM exception.
///
public static ulong MAX_ARM_EXCEPTION = EXCEPT_ARM_FIQ;

///
///  ARM processor context definition.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_ARM {
 public uint    R0;
 public uint    R1;
 public uint    R2;
 public uint    R3;
 public uint    R4;
 public uint    R5;
 public uint    R6;
 public uint    R7;
 public uint    R8;
 public uint    R9;
 public uint    R10;
 public uint    R11;
 public uint    R12;
 public uint    SP;
 public uint    LR;
 public uint    PC;
 public uint    CPSR;
 public uint    DFSR;
 public uint    DFAR;
 public uint    IFSR;
 public uint    IFAR;
}

///
///  AARCH64 processor exception types.
///
public static ulong EXCEPT_AARCH64_SYNCHRONOUS_EXCEPTIONS = 0;
public static ulong EXCEPT_AARCH64_IRQ = 1;
public static ulong EXCEPT_AARCH64_FIQ = 2;
public static ulong EXCEPT_AARCH64_SERROR = 3;

///
/// For coding convenience, define the maximum valid ARM exception.
///
public static ulong MAX_AARCH64_EXCEPTION = EXCEPT_AARCH64_SERROR;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_AARCH64 {
  // General Purpose Registers
 public ulong    X0;
 public ulong    X1;
 public ulong    X2;
 public ulong    X3;
 public ulong    X4;
 public ulong    X5;
 public ulong    X6;
 public ulong    X7;
 public ulong    X8;
 public ulong    X9;
 public ulong    X10;
 public ulong    X11;
 public ulong    X12;
 public ulong    X13;
 public ulong    X14;
 public ulong    X15;
 public ulong    X16;
 public ulong    X17;
 public ulong    X18;
 public ulong    X19;
 public ulong    X20;
 public ulong    X21;
 public ulong    X22;
 public ulong    X23;
 public ulong    X24;
 public ulong    X25;
 public ulong    X26;
 public ulong    X27;
 public ulong    X28;
 public ulong    FP; // x29 - Frame pointer
 public ulong    LR; // x30 - Link Register
 public ulong    SP; // x31 - Stack pointer

  // FP/SIMD Registers
 public fixed ulong    V0[2];
 public fixed ulong    V1[2];
 public fixed ulong    V2[2];
 public fixed ulong    V3[2];
 public fixed ulong    V4[2];
 public fixed ulong    V5[2];
 public fixed ulong    V6[2];
 public fixed ulong    V7[2];
 public fixed ulong    V8[2];
 public fixed ulong    V9[2];
 public fixed ulong    V10[2];
 public fixed ulong    V11[2];
 public fixed ulong    V12[2];
 public fixed ulong    V13[2];
 public fixed ulong    V14[2];
 public fixed ulong    V15[2];
 public fixed ulong    V16[2];
 public fixed ulong    V17[2];
 public fixed ulong    V18[2];
 public fixed ulong    V19[2];
 public fixed ulong    V20[2];
 public fixed ulong    V21[2];
 public fixed ulong    V22[2];
 public fixed ulong    V23[2];
 public fixed ulong    V24[2];
 public fixed ulong    V25[2];
 public fixed ulong    V26[2];
 public fixed ulong    V27[2];
 public fixed ulong    V28[2];
 public fixed ulong    V29[2];
 public fixed ulong    V30[2];
 public fixed ulong    V31[2];

 public ulong    ELR;  // Exception Link Register
 public ulong    SPSR; // Saved Processor Status Register
 public ulong    FPSR; // Floating Point Status Register
 public ulong    ESR;  // Exception syndrome register
 public ulong    FAR;  // Fault Address Register
}

///
/// RISC-V processor exception types.
///
public static ulong EXCEPT_RISCV_INST_MISALIGNED = 0;
public static ulong EXCEPT_RISCV_INST_ACCESS_FAULT = 1;
public static ulong EXCEPT_RISCV_ILLEGAL_INST = 2;
public static ulong EXCEPT_RISCV_BREAKPOINT = 3;
public static ulong EXCEPT_RISCV_LOAD_ADDRESS_MISALIGNED = 4;
public static ulong EXCEPT_RISCV_LOAD_ACCESS_FAULT = 5;
public static ulong EXCEPT_RISCV_STORE_AMO_ADDRESS_MISALIGNED = 6;
public static ulong EXCEPT_RISCV_STORE_AMO_ACCESS_FAULT = 7;
public static ulong EXCEPT_RISCV_ENV_CALL_FROM_UMODE = 8;
public static ulong EXCEPT_RISCV_ENV_CALL_FROM_SMODE = 9;
public static ulong EXCEPT_RISCV_ENV_CALL_FROM_VS_MODE = 10;
public static ulong EXCEPT_RISCV_ENV_CALL_FROM_MMODE = 11;
public static ulong EXCEPT_RISCV_INST_ACCESS_PAGE_FAULT = 12;
public static ulong EXCEPT_RISCV_LOAD_ACCESS_PAGE_FAULT = 13;
public static ulong EXCEPT_RISCV_14 = 14;
public static ulong EXCEPT_RISCV_STORE_ACCESS_PAGE_FAULT = 15;
public static ulong EXCEPT_RISCV_16 = 16;
public static ulong EXCEPT_RISCV_17 = 17;
public static ulong EXCEPT_RISCV_18 = 18;
public static ulong EXCEPT_RISCV_19 = 19;
public static ulong EXCEPT_RISCV_INST_GUEST_PAGE_FAULT = 20;
public static ulong EXCEPT_RISCV_LOAD_GUEST_PAGE_FAULT = 21;
public static ulong EXCEPT_RISCV_VIRTUAL_INSTRUCTION = 22;
public static ulong EXCEPT_RISCV_STORE_GUEST_PAGE_FAULT = 23;
public static ulong EXCEPT_RISCV_MAX_EXCEPTIONS = (EXCEPT_RISCV_STORE_GUEST_PAGE_FAULT);

///
/// RISC-V processor exception types for interrupts.
///
public static ulong EXCEPT_RISCV_IS_IRQ = (x)     ((x & 0x8000000000000000UL) != 0);
public static ulong EXCEPT_RISCV_IRQ_INDEX = (x)  (x & 0x7FFFFFFFFFFFFFFFUL);
public static ulong EXCEPT_RISCV_IRQ_0 = 0x8000000000000000UL;
public static ulong EXCEPT_RISCV_IRQ_SOFT_FROM_SMODE = 0x8000000000000001UL;
public static ulong EXCEPT_RISCV_IRQ_SOFT_FROM_VSMODE = 0x8000000000000002UL;
public static ulong EXCEPT_RISCV_IRQ_SOFT_FROM_MMODE = 0x8000000000000003UL;
public static ulong EXCEPT_RISCV_IRQ_4 = 0x8000000000000004UL;
public static ulong EXCEPT_RISCV_IRQ_TIMER_FROM_SMODE = 0x8000000000000005UL;
public static ulong EXCEPT_RISCV_MAX_IRQS = (EXCEPT_RISCV_IRQ_INDEX(EXCEPT_RISCV_IRQ_TIMER_FROM_SMODE));

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_RISCV64 {
 public ulong    X0;
 public ulong    X1;
 public ulong    X2;
 public ulong    X3;
 public ulong    X4;
 public ulong    X5;
 public ulong    X6;
 public ulong    X7;
 public ulong    X8;
 public ulong    X9;
 public ulong    X10;
 public ulong    X11;
 public ulong    X12;
 public ulong    X13;
 public ulong    X14;
 public ulong    X15;
 public ulong    X16;
 public ulong    X17;
 public ulong    X18;
 public ulong    X19;
 public ulong    X20;
 public ulong    X21;
 public ulong    X22;
 public ulong    X23;
 public ulong    X24;
 public ulong    X25;
 public ulong    X26;
 public ulong    X27;
 public ulong    X28;
 public ulong    X29;
 public ulong    X30;
 public ulong    X31;
 public ulong    SEPC;
 public uint    SSTATUS;
 public uint    STVAL;
}

//
// LoongArch processor exception types.
//
public static ulong EXCEPT_LOONGARCH_INT = 0;
public static ulong EXCEPT_LOONGARCH_PIL = 1;
public static ulong EXCEPT_LOONGARCH_PIS = 2;
public static ulong EXCEPT_LOONGARCH_PIF = 3;
public static ulong EXCEPT_LOONGARCH_PME = 4;
public static ulong EXCEPT_LOONGARCH_PNR = 5;
public static ulong EXCEPT_LOONGARCH_PNX = 6;
public static ulong EXCEPT_LOONGARCH_PPI = 7;
public static ulong EXCEPT_LOONGARCH_ADE = 8;
public static ulong EXCEPT_LOONGARCH_ALE = 9;
public static ulong EXCEPT_LOONGARCH_BCE = 10;
public static ulong EXCEPT_LOONGARCH_SYS = 11;
public static ulong EXCEPT_LOONGARCH_BRK = 12;
public static ulong EXCEPT_LOONGARCH_INE = 13;
public static ulong EXCEPT_LOONGARCH_IPE = 14;
public static ulong EXCEPT_LOONGARCH_FPD = 15;
public static ulong EXCEPT_LOONGARCH_SXD = 16;
public static ulong EXCEPT_LOONGARCH_ASXD = 17;
public static ulong EXCEPT_LOONGARCH_FPE = 18;
public static ulong EXCEPT_LOONGARCH_TBR = 64 // For code only, there is no such type in the ISA spec, the TLB refill is defined for an independent exception.;

//
// LoongArch processor Interrupt types.
//
public static ulong EXCEPT_LOONGARCH_INT_SIP0 = 0;
public static ulong EXCEPT_LOONGARCH_INT_SIP1 = 1;
public static ulong EXCEPT_LOONGARCH_INT_IP0 = 2;
public static ulong EXCEPT_LOONGARCH_INT_IP1 = 3;
public static ulong EXCEPT_LOONGARCH_INT_IP2 = 4;
public static ulong EXCEPT_LOONGARCH_INT_IP3 = 5;
public static ulong EXCEPT_LOONGARCH_INT_IP4 = 6;
public static ulong EXCEPT_LOONGARCH_INT_IP5 = 7;
public static ulong EXCEPT_LOONGARCH_INT_IP6 = 8;
public static ulong EXCEPT_LOONGARCH_INT_IP7 = 9;
public static ulong EXCEPT_LOONGARCH_INT_PMC = 10;
public static ulong EXCEPT_LOONGARCH_INT_TIMER = 11;
public static ulong EXCEPT_LOONGARCH_INT_IPI = 12;

//
// For coding convenience, define the maximum valid
// LoongArch interrupt.
//
public static ulong MAX_LOONGARCH_INTERRUPT = 14;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_CONTEXT_LOONGARCH64 {
 public ulong    R0;
 public ulong    R1;
 public ulong    R2;
 public ulong    R3;
 public ulong    R4;
 public ulong    R5;
 public ulong    R6;
 public ulong    R7;
 public ulong    R8;
 public ulong    R9;
 public ulong    R10;
 public ulong    R11;
 public ulong    R12;
 public ulong    R13;
 public ulong    R14;
 public ulong    R15;
 public ulong    R16;
 public ulong    R17;
 public ulong    R18;
 public ulong    R19;
 public ulong    R20;
 public ulong    R21;
 public ulong    R22;
 public ulong    R23;
 public ulong    R24;
 public ulong    R25;
 public ulong    R26;
 public ulong    R27;
 public ulong    R28;
 public ulong    R29;
 public ulong    R30;
 public ulong    R31;

 public ulong    CRMD;  // CuRrent MoDe information
 public ulong    PRMD;  // PRe-exception MoDe information
 public ulong    EUEN;  // Extended component Unit ENable
 public ulong    MISC;  // MISCellaneous controller
 public ulong    ECFG;  // Exception ConFiGuration
 public ulong    ESTAT; // Exception STATus
 public ulong    ERA;   // Exception Return Address
 public ulong    BADV;  // BAD Virtual address
 public ulong    BADI;  // BAD Instruction
}

///
/// Universal EFI_SYSTEM_CONTEXT definition.
///
[StructLayout(LayoutKind.Explicit)] public unsafe struct EFI_SYSTEM_CONTEXT {
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_EBC            *SystemContextEbc;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_IA32           *SystemContextIa32;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_X64            *SystemContextX64;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_IPF            *SystemContextIpf;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_ARM            *SystemContextArm;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_AARCH64        *SystemContextAArch64;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_RISCV64        *SystemContextRiscV64;
 [FieldOffset(0)] public EFI_SYSTEM_CONTEXT_LOONGARCH64    *SystemContextLoongArch64;
}

//
// DebugSupport callback function prototypes
//



























///
/// Machine type definition
///
public enum EFI_INSTRUCTION_SET_ARCHITECTURE {
  IsaIa32    = IMAGE_FILE_MACHINE_I386,           ///< 0x014C
  IsaX64     = IMAGE_FILE_MACHINE_X64,            ///< 0x8664
  IsaIpf     = IMAGE_FILE_MACHINE_IA64,           ///< 0x0200
  IsaEbc     = IMAGE_FILE_MACHINE_EBC,            ///< 0x0EBC
  IsaArm     = IMAGE_FILE_MACHINE_ARMTHUMB_MIXED, ///< 0x01c2
  IsaAArch64 = IMAGE_FILE_MACHINE_ARM64           ///< 0xAA64
}

//
// DebugSupport member function definitions
//

























































































///
/// This protocol provides the services to allow the debug agent to register
/// callback functions that are called either periodically or when specific
/// processor exceptions occur.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEBUG_SUPPORT_PROTOCOL {
  ///
  /// Declares the processor architecture for this instance of the EFI Debug Support protocol.
  ///
 public EFI_INSTRUCTION_SET_ARCHITECTURE    Isa;
/**
  Returns the maximum value that may be used for the ProcessorIndex parameter in
  RegisterPeriodicCallback() and RegisterExceptionCallback().

  @param  This                  A pointer to the EFI_DEBUG_SUPPORT_PROTOCOL instance.
  @param  MaxProcessorIndex     Pointer to a caller-allocated ulong in which the maximum supported
                                processor index is returned.

  @retval EFI_SUCCESS           The function completed successfully.

**/
public readonly delegate* unmanaged<EFI_DEBUG_SUPPORT_PROTOCOL*,ulong*, EFI_STATUS> GetMaximumProcessorIndex;
/**
  Registers a function to be called back periodically in interrupt context.

  @param  This                  A pointer to the EFI_DEBUG_SUPPORT_PROTOCOL instance.
  @param  ProcessorIndex        Specifies which processor the callback function applies to.
  @param  PeriodicCallback      A pointer to a function of type PERIODIC_CALLBACK that is the main
                                periodic entry point of the debug agent.

  @retval EFI_SUCCESS           The function completed successfully.
  @retval EFI_ALREADY_STARTED   Non-NULL PeriodicCallback parameter when a callback
                                function was previously registered.
  @retval EFI_OUT_OF_RESOURCES  System has insufficient memory resources to register new callback
                                function.

**/
public readonly delegate* unmanaged<EFI_DEBUG_SUPPORT_PROTOCOL*,ulong,EFI_PERIODIC_CALLBACK, EFI_STATUS> RegisterPeriodicCallback;
/**
  Registers a function to be called when a given processor exception occurs.

  @param  This                  A pointer to the EFI_DEBUG_SUPPORT_PROTOCOL instance.
  @param  ProcessorIndex        Specifies which processor the callback function applies to.
  @param  ExceptionCallback     A pointer to a function of type EXCEPTION_CALLBACK that is called
                                when the processor exception specified by ExceptionType occurs.
  @param  ExceptionType         Specifies which processor exception to hook.

  @retval EFI_SUCCESS           The function completed successfully.
  @retval EFI_ALREADY_STARTED   Non-NULL PeriodicCallback parameter when a callback
                                function was previously registered.
  @retval EFI_OUT_OF_RESOURCES  System has insufficient memory resources to register new callback
                                function.

**/
public readonly delegate* unmanaged<EFI_DEBUG_SUPPORT_PROTOCOL*,ulong,EFI_EXCEPTION_CALLBACK,EFI_EXCEPTION_TYPE, EFI_STATUS> RegisterExceptionCallback;
/**
  Invalidates processor instruction cache for a memory range. Subsequent execution in this range
  causes a fresh memory fetch to retrieve code to be executed.

  @param  This                  A pointer to the EFI_DEBUG_SUPPORT_PROTOCOL instance.
  @param  ProcessorIndex        Specifies which processor's instruction cache is to be invalidated.
  @param  Start                 Specifies the physical base of the memory range to be invalidated.
  @param  Length                Specifies the minimum number of bytes in the processor's instruction
                                cache to invalidate.

  @retval EFI_SUCCESS           The function completed successfully.

**/
public readonly delegate* unmanaged<EFI_DEBUG_SUPPORT_PROTOCOL*,ulong,void*,ulong, EFI_STATUS> InvalidateInstructionCache;
}

// extern EFI_GUID  gEfiDebugSupportProtocolGuid;

// #endif
