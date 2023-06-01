namespace Uefi;
/** @file
  SMM Sx Dispatch Protocol as defined in PI 1.2 Specification
  Volume 4 System Management Mode Core Interface.

  Provides the parent dispatch service for a given Sx-state source generator.

  Copyright (c) 2009 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMM_SX_DISPATCH2_H_
// #define _SMM_SX_DISPATCH2_H_

// #include <Protocol/MmSxDispatch.h>

public const ulong EFI_SMM_SX_DISPATCH2_PROTOCOL_GUID = EFI_MM_SX_DISPATCH_PROTOCOL_GUID;

///
/// The dispatch function's context
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SX_REGISTER_CONTEXT { EFI_MM_SX_REGISTER_CONTEXT Value; public static implicit operator EFI_SMM_SX_REGISTER_CONTEXT(EFI_MM_SX_REGISTER_CONTEXT value) => new EFI_SMM_SX_REGISTER_CONTEXT() { Value = value }; public static implicit operator EFI_MM_SX_REGISTER_CONTEXT(EFI_SMM_SX_REGISTER_CONTEXT value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SX_DISPATCH2_PROTOCOL { EFI_MM_SX_DISPATCH_PROTOCOL Value; public static implicit operator EFI_SMM_SX_DISPATCH2_PROTOCOL(EFI_MM_SX_DISPATCH_PROTOCOL value) => new EFI_SMM_SX_DISPATCH2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_SX_DISPATCH_PROTOCOL(EFI_SMM_SX_DISPATCH2_PROTOCOL value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SX_REGISTER2 { EFI_MM_SX_REGISTER Value; public static implicit operator EFI_SMM_SX_REGISTER2(EFI_MM_SX_REGISTER value) => new EFI_SMM_SX_REGISTER2() { Value = value }; public static implicit operator EFI_MM_SX_REGISTER(EFI_SMM_SX_REGISTER2 value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_SX_UNREGISTER2 { EFI_MM_SX_UNREGISTER Value; public static implicit operator EFI_SMM_SX_UNREGISTER2(EFI_MM_SX_UNREGISTER value) => new EFI_SMM_SX_UNREGISTER2() { Value = value }; public static implicit operator EFI_MM_SX_UNREGISTER(EFI_SMM_SX_UNREGISTER2 value) => value.Value; }

// extern EFI_GUID  gEfiSmmSxDispatch2ProtocolGuid;

// #endif
