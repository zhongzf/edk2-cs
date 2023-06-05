using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  MM USB Dispatch Protocol as defined in PI 1.5 Specification
  Volume 4 Management Mode Core Interface.

  Provides the parent dispatch service for the USB MMI source generator.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.5.

**/

// #ifndef _MM_USB_DISPATCH_H_
// #define _MM_USB_DISPATCH_H_

// #include <Pi/PiMmCis.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_MM_USB_DISPATCH_PROTOCOL_GUID = new GUID(
      0xee9b8d90, 0xc5a6, 0x40a2, 0xbd, 0xe2, 0x52, 0x55, 0x8d, 0x33, 0xcc, 0xa1);
}

///
/// USB MMI event types
///
public enum EFI_USB_MMI_TYPE
{
  UsbLegacy,
  UsbWake
}

///
/// The dispatch function's context.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_USB_REGISTER_CONTEXT
{
  ///
  /// Describes whether this child handler will be invoked in response to a USB legacy
  /// emulation event, such as port-trap on the PS/2* keyboard control registers, or to a
  /// USB wake event, such as resumption from a sleep state.
  ///
  public EFI_USB_MMI_TYPE Type;
  ///
  /// The device path is part of the context structure and describes the location of the
  /// particular USB host controller in the system for which this register event will occur.
  /// This location is important because of the possible integration of several USB host
  /// controllers in a system.
  ///
  public EFI_DEVICE_PATH_PROTOCOL* Device;
}

// typedef struct _EFI_MM_USB_DISPATCH_PROTOCOL EFI_MM_USB_DISPATCH_PROTOCOL;

// /**
//   Provides the parent dispatch service for the USB MMI source generator.
// 
//   This service registers a function (DispatchFunction) which will be called when the USB-
//   related MMI specified by RegisterContext has occurred. On return, DispatchHandle
//   contains a unique handle which may be used later to unregister the function using UnRegister().
//   The DispatchFunction will be called with Context set to the same value as was passed into
//   this function in RegisterContext and with CommBuffer containing NULL and
//   CommBufferSize containing zero.
// 
//   @param[in]  This               Pointer to the EFI_MM_USB_DISPATCH_PROTOCOL instance.
//   @param[in]  DispatchFunction   Function to register for handler when a USB-related MMI occurs.
//   @param[in]  RegisterContext    Pointer to the dispatch function's context.
//                                  The caller fills this context in before calling
//                                  the register function to indicate to the register
//                                  function the USB MMI types for which the dispatch
//                                  function should be invoked.
//   @param[out] DispatchHandle     Handle generated by the dispatcher to track the function instance.
// 
//   @retval EFI_SUCCESS            The dispatch function has been successfully
//                                  registered and the MMI source has been enabled.
//   @retval EFI_DEVICE_ERROR       The driver was unable to enable the MMI source.
//   @retval EFI_INVALID_PARAMETER  RegisterContext is invalid. The USB MMI type
//                                  is not within valid range.
//   @retval EFI_OUT_OF_RESOURCES   There is not enough memory (system or MM) to manage this child.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_MM_USB_REGISTER)(
//   IN  CONST EFI_MM_USB_DISPATCH_PROTOCOL  *This,
//   IN        EFI_MM_HANDLER_ENTRY_POINT    DispatchFunction,
//   IN  CONST EFI_MM_USB_REGISTER_CONTEXT   *RegisterContext,
//   OUT       EFI_HANDLE                    *DispatchHandle
//   );

// /**
//   Unregisters a USB service.
// 
//   This service removes the handler associated with DispatchHandle so that it will no longer be
//   called when the USB event occurs.
// 
//   @param[in]  This               Pointer to the EFI_MM_USB_DISPATCH_PROTOCOL instance.
//   @param[in]  DispatchHandle     Handle of the service to remove.
// 
//   @retval EFI_SUCCESS            The dispatch function has been successfully
//                                  unregistered and the MMI source has been disabled
//                                  if there are no other registered child dispatch
//                                  functions for this MMI source.
//   @retval EFI_INVALID_PARAMETER  The DispatchHandle was not valid.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_MM_USB_UNREGISTER)(
//   IN CONST EFI_MM_USB_DISPATCH_PROTOCOL  *This,
//   IN       EFI_HANDLE                    DispatchHandle
//   );

///
/// Interface structure for the MM USB MMI Dispatch Protocol
///
/// This protocol provides the parent dispatch service for the USB MMI source generator.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_USB_DISPATCH_PROTOCOL
{
  //public readonly delegate* unmanaged</* IN CONST */EFI_MM_USB_DISPATCH_PROTOCOL*,/* IN */EFI_MM_HANDLER_ENTRY_POINT /*DispatchFunction*/,/* IN */CONST /*EFI_MM_USB_REGISTER_CONTEXT*/,/* OUT */EFI_HANDLE* /*DispatchHandle*/, EFI_STATUS> /*EFI_MM_USB_REGISTER*/ Register;
  public void* Register;

  public readonly delegate* unmanaged</* IN CONST */EFI_MM_USB_DISPATCH_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*DispatchHandle*/, EFI_STATUS> /*EFI_MM_USB_UNREGISTER*/ UnRegister;
}

// extern EFI_GUID  gEfiMmUsbDispatchProtocolGuid;

// #endif
