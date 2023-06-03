using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  MM Power Button Dispatch Protocol as defined in PI 1.5 Specification
  Volume 4 Management Mode Core Interface.

  This protocol provides the parent dispatch service for the power button MMI source generator.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This protocol is from PI Version 1.5.

**/

// #ifndef _MM_POWER_BUTTON_DISPATCH_H_
// #define _MM_POWER_BUTTON_DISPATCH_H_

// #include <Pi/PiMmCis.h>

public unsafe partial class EFI
{
  public static EFI_GUID EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL_GUID = new GUID(
      0x1b1183fa, 0x1823, 0x46a7, new byte[] { 0x88, 0x72, 0x9c, 0x57, 0x87, 0x55, 0x40, 0x9d });
}

///
/// Power Button phases.
///
public enum EFI_POWER_BUTTON_PHASE
{
  EfiPowerButtonEntry,
  EfiPowerButtonExit,
  EfiPowerButtonMax
}

///
/// The dispatch function's context.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_POWER_BUTTON_REGISTER_CONTEXT
{
  ///
  /// Designates whether this handler should be invoked upon entry or exit.
  ///
  public EFI_POWER_BUTTON_PHASE Phase;
}

// typedef struct _EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL;

// /**
//   Provides the parent dispatch service for a power button event.
// 
//   This service registers a function (DispatchFunction) which will be called when an MMI is
//   generated because the power button was pressed or released, as specified by RegisterContext.
//   On return, DispatchHandle contains a unique handle which may be used later to unregister the
//   function using UnRegister().
//   The DispatchFunction will be called with Context set to the same value as was passed into
//   this function in RegisterContext and with CommBuffer and CommBufferSize set to NULL.
// 
//   @param[in]  This               Pointer to the EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL instance.
//   @param[in]  DispatchFunction   Function to register for handler when power button is pressed or released.
//   @param[in]  RegisterContext    Pointer to the dispatch function's context. The caller fills in this context
//                                  before calling the Register() function to indicate to the Register() function
//                                  the power button MMI phase for which the dispatch function should be invoked.
//   @param[out] DispatchHandle     Handle generated by the dispatcher to track the function instance.
// 
//   @retval EFI_SUCCESS            The dispatch function has been successfully
//                                  registered and the MMI source has been enabled.
//   @retval EFI_DEVICE_ERROR       The driver was unable to enable the MMI source.
//   @retval EFI_INVALID_PARAMETER  RegisterContext is invalid. The power button input value
//                                  is not within valid range.
//   @retval EFI_OUT_OF_RESOURCES   There is not enough memory (system or MM) to manage this child.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_MM_POWER_BUTTON_REGISTER)(
//   IN CONST EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL  *This,
//   IN       EFI_MM_HANDLER_ENTRY_POINT             DispatchFunction,
//   IN       EFI_MM_POWER_BUTTON_REGISTER_CONTEXT   *RegisterContext,
//   OUT      EFI_HANDLE                             *DispatchHandle
//   );

// /**
//   Unregisters a power-button service.
// 
//   This service removes the handler associated with DispatchHandle so that it will no longer be
//   called when the standby button is pressed or released.
// 
//   @param[in] This                Pointer to the EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL instance.
//   @param[in] DispatchHandle      Handle of the service to remove.
// 
//   @retval EFI_SUCCESS            The service has been successfully removed.
//   @retval EFI_INVALID_PARAMETER  The DispatchHandle was not valid.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_MM_POWER_BUTTON_UNREGISTER)(
//   IN CONST EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL  *This,
//   IN       EFI_HANDLE                             DispatchHandle
//   );

///
/// Interface structure for the MM Power Button Dispatch Protocol.
///
/// This protocol provides the parent dispatch service for the power button MMI source generator.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL
{
  public readonly delegate* unmanaged</* IN CONST */EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL* /*This*/,/* IN */EFI_MM_HANDLER_ENTRY_POINT /*DispatchFunction*/,/* IN */EFI_MM_POWER_BUTTON_REGISTER_CONTEXT* /*RegisterContext*/,/* OUT */EFI_HANDLE* /*DispatchHandle*/, EFI_STATUS> /*EFI_MM_POWER_BUTTON_REGISTER*/ Register;
  public readonly delegate* unmanaged</* IN CONST */EFI_MM_POWER_BUTTON_DISPATCH_PROTOCOL* /*This*/,/* IN */EFI_HANDLE /*DispatchHandle*/, EFI_STATUS> /*EFI_MM_POWER_BUTTON_UNREGISTER*/ UnRegister;
}

// extern EFI_GUID  gEfiMmPowerButtonDispatchProtocolGuid;

// #endif
