namespace Uefi;
/** @file
  EFI SMM CPU Protocol as defined in the PI 1.2 specification.

  This protocol allows SMM drivers to access architecture-standard registers from any of the CPU
  save state areas. In some cases, difference processors provide the same information in the save state,
  but not in the same format. These so-called pseudo-registers provide this information in a standard
  format.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_CPU_H_
// #define _SMM_CPU_H_

// #include <Protocol/MmCpu.h>

public static ulong EFI_SMM_CPU_PROTOCOL_GUID = EFI_MM_CPU_PROTOCOL_GUID;

public static ulong EFI_SMM_SAVE_STATE_REGISTER_GDTBASE = EFI_MM_SAVE_STATE_REGISTER_GDTBASE;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_IDTBASE = EFI_MM_SAVE_STATE_REGISTER_IDTBASE;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LDTBASE = EFI_MM_SAVE_STATE_REGISTER_LDTBASE;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_GDTLIMIT = EFI_MM_SAVE_STATE_REGISTER_GDTLIMIT;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_IDTLIMIT = EFI_MM_SAVE_STATE_REGISTER_IDTLIMIT;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LDTLIMIT = EFI_MM_SAVE_STATE_REGISTER_LDTLIMIT;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LDTINFO = EFI_MM_SAVE_STATE_REGISTER_LDTINFO;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_ES = EFI_MM_SAVE_STATE_REGISTER_ES;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_CS = EFI_MM_SAVE_STATE_REGISTER_CS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_SS = EFI_MM_SAVE_STATE_REGISTER_SS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_DS = EFI_MM_SAVE_STATE_REGISTER_DS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FS = EFI_MM_SAVE_STATE_REGISTER_FS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_GS = EFI_MM_SAVE_STATE_REGISTER_GS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LDTR_SEL = EFI_MM_SAVE_STATE_REGISTER_LDTR_SEL;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_TR_SEL = EFI_MM_SAVE_STATE_REGISTER_TR_SEL;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_DR7 = EFI_MM_SAVE_STATE_REGISTER_DR7;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_DR6 = EFI_MM_SAVE_STATE_REGISTER_DR6;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R8 = EFI_MM_SAVE_STATE_REGISTER_R8;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R9 = EFI_MM_SAVE_STATE_REGISTER_R9;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R10 = EFI_MM_SAVE_STATE_REGISTER_R10;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R11 = EFI_MM_SAVE_STATE_REGISTER_R11;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R12 = EFI_MM_SAVE_STATE_REGISTER_R12;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R13 = EFI_MM_SAVE_STATE_REGISTER_R13;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R14 = EFI_MM_SAVE_STATE_REGISTER_R14;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_R15 = EFI_MM_SAVE_STATE_REGISTER_R15;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RAX = EFI_MM_SAVE_STATE_REGISTER_RAX;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RBX = EFI_MM_SAVE_STATE_REGISTER_RBX;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RCX = EFI_MM_SAVE_STATE_REGISTER_RCX;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RDX = EFI_MM_SAVE_STATE_REGISTER_RDX;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RSP = EFI_MM_SAVE_STATE_REGISTER_RSP;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RBP = EFI_MM_SAVE_STATE_REGISTER_RBP;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RSI = EFI_MM_SAVE_STATE_REGISTER_RSI;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RDI = EFI_MM_SAVE_STATE_REGISTER_RDI;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RIP = EFI_MM_SAVE_STATE_REGISTER_RIP;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_RFLAGS = EFI_MM_SAVE_STATE_REGISTER_RFLAGS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_CR0 = EFI_MM_SAVE_STATE_REGISTER_CR0;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_CR3 = EFI_MM_SAVE_STATE_REGISTER_CR3;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_CR4 = EFI_MM_SAVE_STATE_REGISTER_CR4;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FCW = EFI_MM_SAVE_STATE_REGISTER_FCW;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FSW = EFI_MM_SAVE_STATE_REGISTER_FSW;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FTW = EFI_MM_SAVE_STATE_REGISTER_FTW;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_OPCODE = EFI_MM_SAVE_STATE_REGISTER_OPCODE;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FP_EIP = EFI_MM_SAVE_STATE_REGISTER_FP_EIP;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FP_CS = EFI_MM_SAVE_STATE_REGISTER_FP_CS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_DATAOFFSET = EFI_MM_SAVE_STATE_REGISTER_DATAOFFSET;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_FP_DS = EFI_MM_SAVE_STATE_REGISTER_FP_DS;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM0 = EFI_MM_SAVE_STATE_REGISTER_MM0;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM1 = EFI_MM_SAVE_STATE_REGISTER_MM1;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM2 = EFI_MM_SAVE_STATE_REGISTER_MM2;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM3 = EFI_MM_SAVE_STATE_REGISTER_MM3;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM4 = EFI_MM_SAVE_STATE_REGISTER_MM4;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM5 = EFI_MM_SAVE_STATE_REGISTER_MM5;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM6 = EFI_MM_SAVE_STATE_REGISTER_MM6;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_MM7 = EFI_MM_SAVE_STATE_REGISTER_MM7;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM0 = EFI_MM_SAVE_STATE_REGISTER_XMM0;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM1 = EFI_MM_SAVE_STATE_REGISTER_XMM1;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM2 = EFI_MM_SAVE_STATE_REGISTER_XMM2;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM3 = EFI_MM_SAVE_STATE_REGISTER_XMM3;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM4 = EFI_MM_SAVE_STATE_REGISTER_XMM4;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM5 = EFI_MM_SAVE_STATE_REGISTER_XMM5;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM6 = EFI_MM_SAVE_STATE_REGISTER_XMM6;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM7 = EFI_MM_SAVE_STATE_REGISTER_XMM7;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM8 = EFI_MM_SAVE_STATE_REGISTER_XMM8;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM9 = EFI_MM_SAVE_STATE_REGISTER_XMM9;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM10 = EFI_MM_SAVE_STATE_REGISTER_XMM10;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM11 = EFI_MM_SAVE_STATE_REGISTER_XMM11;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM12 = EFI_MM_SAVE_STATE_REGISTER_XMM12;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM13 = EFI_MM_SAVE_STATE_REGISTER_XMM13;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM14 = EFI_MM_SAVE_STATE_REGISTER_XMM14;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_XMM15 = EFI_MM_SAVE_STATE_REGISTER_XMM15;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_IO = EFI_MM_SAVE_STATE_REGISTER_IO;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LMA = EFI_MM_SAVE_STATE_REGISTER_LMA;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_PROCESSOR_ID = EFI_MM_SAVE_STATE_REGISTER_PROCESSOR_ID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SAVE_STATE_REGISTER { EFI_MM_SAVE_STATE_REGISTER Value; public static implicit operator EFI_SMM_SAVE_STATE_REGISTER(EFI_MM_SAVE_STATE_REGISTER value) => new EFI_SMM_SAVE_STATE_REGISTER() { Value = value }; public static implicit operator EFI_MM_SAVE_STATE_REGISTER(EFI_SMM_SAVE_STATE_REGISTER value) => value.Value; }

public static ulong EFI_SMM_SAVE_STATE_REGISTER_LMA_32BIT = EFI_MM_SAVE_STATE_REGISTER_LMA_32BIT;
public static ulong EFI_SMM_SAVE_STATE_REGISTER_LMA_64BIT = EFI_MM_SAVE_STATE_REGISTER_LMA_64BIT;

///
/// Size width of I/O instruction
///
public static ulong EFI_SMM_SAVE_STATE_IO_WIDTH_UINT8 = EFI_MM_SAVE_STATE_IO_WIDTH_UINT8;
public static ulong EFI_SMM_SAVE_STATE_IO_WIDTH_UINT16 = EFI_MM_SAVE_STATE_IO_WIDTH_UINT16;
public static ulong EFI_SMM_SAVE_STATE_IO_WIDTH_UINT32 = EFI_MM_SAVE_STATE_IO_WIDTH_UINT32;
public static ulong EFI_SMM_SAVE_STATE_IO_WIDTH_UINT64 = EFI_MM_SAVE_STATE_IO_WIDTH_UINT64;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SAVE_STATE_IO_WIDTH { EFI_MM_SAVE_STATE_IO_WIDTH Value; public static implicit operator EFI_SMM_SAVE_STATE_IO_WIDTH(EFI_MM_SAVE_STATE_IO_WIDTH value) => new EFI_SMM_SAVE_STATE_IO_WIDTH() { Value = value }; public static implicit operator EFI_MM_SAVE_STATE_IO_WIDTH(EFI_SMM_SAVE_STATE_IO_WIDTH value) => value.Value; }

///
/// Types of I/O instruction
///
public static ulong EFI_SMM_SAVE_STATE_IO_TYPE_INPUT = EFI_MM_SAVE_STATE_IO_TYPE_INPUT;
public static ulong EFI_SMM_SAVE_STATE_IO_TYPE_OUTPUT = EFI_MM_SAVE_STATE_IO_TYPE_OUTPUT;
public static ulong EFI_SMM_SAVE_STATE_IO_TYPE_STRING = EFI_MM_SAVE_STATE_IO_TYPE_STRING;
public static ulong EFI_SMM_SAVE_STATE_IO_TYPE_REP_PREFIX = EFI_MM_SAVE_STATE_IO_TYPE_REP_PREFIX;
typedef EFI_MM_SAVE_STATE_IO_TYPE EFI_SMM_SAVE_STATE_IO_TYPE;

typedef EFI_MM_SAVE_STATE_IO_INFO EFI_SMM_SAVE_STATE_IO_INFO;

typedef EFI_MM_CPU_PROTOCOL EFI_SMM_CPU_PROTOCOL;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_READ_SAVE_STATE { EFI_MM_READ_SAVE_STATE Value; public static implicit operator EFI_SMM_READ_SAVE_STATE(EFI_MM_READ_SAVE_STATE value) => new EFI_SMM_READ_SAVE_STATE() { Value = value }; public static implicit operator EFI_MM_READ_SAVE_STATE(EFI_SMM_READ_SAVE_STATE value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_WRITE_SAVE_STATE { EFI_MM_WRITE_SAVE_STATE Value; public static implicit operator EFI_SMM_WRITE_SAVE_STATE(EFI_MM_WRITE_SAVE_STATE value) => new EFI_SMM_WRITE_SAVE_STATE() { Value = value }; public static implicit operator EFI_MM_WRITE_SAVE_STATE(EFI_SMM_WRITE_SAVE_STATE value) => value.Value; }
// extern EFI_GUID  gEfiSmmCpuProtocolGuid;

// #endif
