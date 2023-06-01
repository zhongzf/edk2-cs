using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  SMM General Purpose Input (GPI) Dispatch2 Protocol as defined in PI 1.1 Specification
  Volume 4 System Management Mode Core Interface.

  This protocol provides the parent dispatch service for the General Purpose Input
  (GPI) SMI source generator.

  The EFI_SMM_GPI_DISPATCH2_PROTOCOL provides the ability to install child handlers for the
  given event types.  Several inputs can be enabled.  This purpose of this interface is to generate an
  SMI in response to any of these inputs having a true value provided.

  Copyright (c) 2009 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.1.

**/

// #ifndef _SMM_GPI_DISPATCH2_H_
// #define _SMM_GPI_DISPATCH2_H_

// #include <Protocol/MmGpiDispatch.h>
// #include <Pi/PiSmmCis.h>

public const ulong EFI_SMM_GPI_DISPATCH2_PROTOCOL_GUID = EFI_MM_GPI_DISPATCH_PROTOCOL_GUID;
///
/// The dispatch function's context.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_GPI_REGISTER_CONTEXT { EFI_MM_GPI_REGISTER_CONTEXT Value; public static implicit operator EFI_SMM_GPI_REGISTER_CONTEXT(EFI_MM_GPI_REGISTER_CONTEXT value) => new EFI_SMM_GPI_REGISTER_CONTEXT() { Value = value }; public static implicit operator EFI_MM_GPI_REGISTER_CONTEXT(EFI_SMM_GPI_REGISTER_CONTEXT value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_GPI_REGISTER2 { EFI_MM_GPI_REGISTER Value; public static implicit operator EFI_SMM_GPI_REGISTER2(EFI_MM_GPI_REGISTER value) => new EFI_SMM_GPI_REGISTER2() { Value = value }; public static implicit operator EFI_MM_GPI_REGISTER(EFI_SMM_GPI_REGISTER2 value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_GPI_UNREGISTER2 { EFI_MM_GPI_UNREGISTER Value; public static implicit operator EFI_SMM_GPI_UNREGISTER2(EFI_MM_GPI_UNREGISTER value) => new EFI_SMM_GPI_UNREGISTER2() { Value = value }; public static implicit operator EFI_MM_GPI_UNREGISTER(EFI_SMM_GPI_UNREGISTER2 value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_GPI_DISPATCH2_PROTOCOL { EFI_MM_GPI_DISPATCH_PROTOCOL Value; public static implicit operator EFI_SMM_GPI_DISPATCH2_PROTOCOL(EFI_MM_GPI_DISPATCH_PROTOCOL value) => new EFI_SMM_GPI_DISPATCH2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_GPI_DISPATCH_PROTOCOL(EFI_SMM_GPI_DISPATCH2_PROTOCOL value) => value.Value; }

// extern EFI_GUID  gEfiSmmGpiDispatch2ProtocolGuid;

// #endif
