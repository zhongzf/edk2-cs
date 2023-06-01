namespace Uefi;
/** @file
  SMM CPU I/O 2 protocol as defined in the PI 1.2 specification.

  This protocol provides CPU I/O and memory access within SMM.

  Copyright (c) 2009 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_CPU_IO2_H_
// #define _SMM_CPU_IO2_H_

// #include <Protocol/MmCpuIo.h>

public static ulong EFI_SMM_CPU_IO2_PROTOCOL_GUID = EFI_MM_CPU_IO_PROTOCOL_GUID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_CPU_IO2_PROTOCOL { EFI_MM_CPU_IO_PROTOCOL Value; public static implicit operator EFI_SMM_CPU_IO2_PROTOCOL(EFI_MM_CPU_IO_PROTOCOL value) => new EFI_SMM_CPU_IO2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_CPU_IO_PROTOCOL(EFI_SMM_CPU_IO2_PROTOCOL value) => value.Value;}

///
/// Width of the SMM CPU I/O operations
///
public static ulong SMM_IO_UINT8 = MM_IO_UINT8;
public static ulong SMM_IO_UINT16 = MM_IO_UINT16;
public static ulong SMM_IO_UINT32 = MM_IO_UINT32;
public static ulong SMM_IO_UINT64 = MM_IO_UINT64;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_WIDTH { EFI_MM_IO_WIDTH Value; public static implicit operator EFI_SMM_IO_WIDTH(EFI_MM_IO_WIDTH value) => new EFI_SMM_IO_WIDTH() { Value = value }; public static implicit operator EFI_MM_IO_WIDTH(EFI_SMM_IO_WIDTH value) => value.Value;}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_CPU_IO2 { EFI_MM_CPU_IO Value; public static implicit operator EFI_SMM_CPU_IO2(EFI_MM_CPU_IO value) => new EFI_SMM_CPU_IO2() { Value = value }; public static implicit operator EFI_MM_CPU_IO(EFI_SMM_CPU_IO2 value) => value.Value;}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_ACCESS2 { EFI_MM_IO_ACCESS Value; public static implicit operator EFI_SMM_IO_ACCESS2(EFI_MM_IO_ACCESS value) => new EFI_SMM_IO_ACCESS2() { Value = value }; public static implicit operator EFI_MM_IO_ACCESS(EFI_SMM_IO_ACCESS2 value) => value.Value;}

// extern EFI_GUID  gEfiSmmCpuIo2ProtocolGuid;

// #endif
