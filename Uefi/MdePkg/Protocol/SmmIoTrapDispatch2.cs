using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  SMM IO Trap Dispatch2 Protocol as defined in PI 1.1 Specification
  Volume 4 System Management Mode Core Interface.

  This protocol provides a parent dispatch service for IO trap SMI sources.

  Copyright (c) 2009 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.1.

**/

// #ifndef _SMM_IO_TRAP_DISPATCH2_H_
// #define _SMM_IO_TRAP_DISPATCH2_H_

// #include <Protocol/MmIoTrapDispatch.h>

public unsafe partial class EFI
{
  public const ulong EFI_SMM_IO_TRAP_DISPATCH2_PROTOCOL_GUID = EFI_MM_IO_TRAP_DISPATCH_PROTOCOL_GUID;
}

///
/// IO Trap valid types
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_DISPATCH_TYPE { EFI_MM_IO_TRAP_DISPATCH_TYPE Value; public static implicit operator EFI_SMM_IO_TRAP_DISPATCH_TYPE(EFI_MM_IO_TRAP_DISPATCH_TYPE value) => new EFI_SMM_IO_TRAP_DISPATCH_TYPE() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_DISPATCH_TYPE(EFI_SMM_IO_TRAP_DISPATCH_TYPE value) => value.Value; }

///
/// IO Trap context structure containing information about the
/// IO trap event that should invoke the handler
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_REGISTER_CONTEXT { EFI_MM_IO_TRAP_REGISTER_CONTEXT Value; public static implicit operator EFI_SMM_IO_TRAP_REGISTER_CONTEXT(EFI_MM_IO_TRAP_REGISTER_CONTEXT value) => new EFI_SMM_IO_TRAP_REGISTER_CONTEXT() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_REGISTER_CONTEXT(EFI_SMM_IO_TRAP_REGISTER_CONTEXT value) => value.Value; }

///
/// IO Trap context structure containing information about the IO trap that occurred
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_CONTEXT { EFI_MM_IO_TRAP_CONTEXT Value; public static implicit operator EFI_SMM_IO_TRAP_CONTEXT(EFI_MM_IO_TRAP_CONTEXT value) => new EFI_SMM_IO_TRAP_CONTEXT() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_CONTEXT(EFI_SMM_IO_TRAP_CONTEXT value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_DISPATCH2_PROTOCOL { EFI_MM_IO_TRAP_DISPATCH_PROTOCOL Value; public static implicit operator EFI_SMM_IO_TRAP_DISPATCH2_PROTOCOL(EFI_MM_IO_TRAP_DISPATCH_PROTOCOL value) => new EFI_SMM_IO_TRAP_DISPATCH2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_DISPATCH_PROTOCOL(EFI_SMM_IO_TRAP_DISPATCH2_PROTOCOL value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_DISPATCH2_REGISTER { EFI_MM_IO_TRAP_DISPATCH_REGISTER Value; public static implicit operator EFI_SMM_IO_TRAP_DISPATCH2_REGISTER(EFI_MM_IO_TRAP_DISPATCH_REGISTER value) => new EFI_SMM_IO_TRAP_DISPATCH2_REGISTER() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_DISPATCH_REGISTER(EFI_SMM_IO_TRAP_DISPATCH2_REGISTER value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_IO_TRAP_DISPATCH2_UNREGISTER { EFI_MM_IO_TRAP_DISPATCH_UNREGISTER Value; public static implicit operator EFI_SMM_IO_TRAP_DISPATCH2_UNREGISTER(EFI_MM_IO_TRAP_DISPATCH_UNREGISTER value) => new EFI_SMM_IO_TRAP_DISPATCH2_UNREGISTER() { Value = value }; public static implicit operator EFI_MM_IO_TRAP_DISPATCH_UNREGISTER(EFI_SMM_IO_TRAP_DISPATCH2_UNREGISTER value) => value.Value; }

// extern EFI_GUID  gEfiSmmIoTrapDispatch2ProtocolGuid;

// #endif
