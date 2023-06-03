using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  SMM Power Button Dispatch2 Protocol as defined in PI 1.1 Specification
  Volume 4 System Management Mode Core Interface.

  This protocol provides the parent dispatch service for the power button SMI source generator.

  Copyright (c) 2009 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.1.

**/

// #ifndef _SMM_POWER_BUTTON_DISPATCH2_H_
// #define _SMM_POWER_BUTTON_DISPATCH2_H_

// #include <Protocol/MmPowerButtonDispatch.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_SMM_POWER_BUTTON_DISPATCH2_PROTOCOL_GUID = EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL_GUID;
}

///
/// The dispatch function's context.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_POWER_BUTTON_REGISTER_CONTEXT { EFI_MM_POWER_BUTTON_REGISTER_CONTEXT Value; public static implicit operator EFI_SMM_POWER_BUTTON_REGISTER_CONTEXT(EFI_MM_POWER_BUTTON_REGISTER_CONTEXT value) => new EFI_SMM_POWER_BUTTON_REGISTER_CONTEXT() { Value = value }; public static implicit operator EFI_MM_POWER_BUTTON_REGISTER_CONTEXT(EFI_SMM_POWER_BUTTON_REGISTER_CONTEXT value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_POWER_BUTTON_DISPATCH2_PROTOCOL { EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL Value; public static implicit operator EFI_SMM_POWER_BUTTON_DISPATCH2_PROTOCOL(EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL value) => new EFI_SMM_POWER_BUTTON_DISPATCH2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL(EFI_SMM_POWER_BUTTON_DISPATCH2_PROTOCOL value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_POWER_BUTTON_REGISTER2 { EFI_MM_POWER_BUTTON_REGISTER Value; public static implicit operator EFI_SMM_POWER_BUTTON_REGISTER2(EFI_MM_POWER_BUTTON_REGISTER value) => new EFI_SMM_POWER_BUTTON_REGISTER2() { Value = value }; public static implicit operator EFI_MM_POWER_BUTTON_REGISTER(EFI_SMM_POWER_BUTTON_REGISTER2 value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_POWER_BUTTON_UNREGISTER2 { EFI_MM_POWER_BUTTON_UNREGISTER Value; public static implicit operator EFI_SMM_POWER_BUTTON_UNREGISTER2(EFI_MM_POWER_BUTTON_UNREGISTER value) => new EFI_SMM_POWER_BUTTON_UNREGISTER2() { Value = value }; public static implicit operator EFI_MM_POWER_BUTTON_UNREGISTER(EFI_SMM_POWER_BUTTON_UNREGISTER2 value) => value.Value; }

// extern EFI_GUID  gEfiSmmPowerButtonDispatch2ProtocolGuid;

// #endif
