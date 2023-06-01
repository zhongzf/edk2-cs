namespace Uefi;
/** @file
  SMM USB Dispatch2 Protocol as defined in PI 1.1 Specification
  Volume 4 System Management Mode Core Interface.

  Provides the parent dispatch service for the USB SMI source generator.

  Copyright (c) 2009 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.1.

**/

// #ifndef _SMM_USB_DISPATCH2_H_
// #define _SMM_USB_DISPATCH2_H_

// #include <Protocol/MmUsbDispatch.h>

public static ulong EFI_SMM_USB_DISPATCH2_PROTOCOL_GUID = EFI_MM_USB_DISPATCH_PROTOCOL_GUID;

///
/// USB SMI event types
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_USB_SMI_TYPE { EFI_USB_MMI_TYPE Value; public static implicit operator EFI_USB_SMI_TYPE(EFI_USB_MMI_TYPE value) => new EFI_USB_SMI_TYPE() { Value = value }; public static implicit operator EFI_USB_MMI_TYPE(EFI_USB_SMI_TYPE value) => value.Value; }

///
/// The dispatch function's context.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_USB_REGISTER_CONTEXT { EFI_MM_USB_REGISTER_CONTEXT Value; public static implicit operator EFI_SMM_USB_REGISTER_CONTEXT(EFI_MM_USB_REGISTER_CONTEXT value) => new EFI_SMM_USB_REGISTER_CONTEXT() { Value = value }; public static implicit operator EFI_MM_USB_REGISTER_CONTEXT(EFI_SMM_USB_REGISTER_CONTEXT value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_USB_DISPATCH2_PROTOCOL { EFI_MM_USB_DISPATCH_PROTOCOL Value; public static implicit operator EFI_SMM_USB_DISPATCH2_PROTOCOL(EFI_MM_USB_DISPATCH_PROTOCOL value) => new EFI_SMM_USB_DISPATCH2_PROTOCOL() { Value = value }; public static implicit operator EFI_MM_USB_DISPATCH_PROTOCOL(EFI_SMM_USB_DISPATCH2_PROTOCOL value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_USB_REGISTER2 { EFI_MM_USB_REGISTER Value; public static implicit operator EFI_SMM_USB_REGISTER2(EFI_MM_USB_REGISTER value) => new EFI_SMM_USB_REGISTER2() { Value = value }; public static implicit operator EFI_MM_USB_REGISTER(EFI_SMM_USB_REGISTER2 value) => value.Value; }

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMM_USB_UNREGISTER2 { EFI_MM_USB_UNREGISTER Value; public static implicit operator EFI_SMM_USB_UNREGISTER2(EFI_MM_USB_UNREGISTER value) => new EFI_SMM_USB_UNREGISTER2() { Value = value }; public static implicit operator EFI_MM_USB_UNREGISTER(EFI_SMM_USB_UNREGISTER2 value) => value.Value; }

// extern EFI_GUID  gEfiSmmUsbDispatch2ProtocolGuid;

// #endif
