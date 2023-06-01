namespace Uefi;
/** @file
  Status code Runtime Protocol as defined in PI Specification 1.4a VOLUME 2 DXE

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __STATUS_CODE_RUNTIME_PROTOCOL_H__
// #define __STATUS_CODE_RUNTIME_PROTOCOL_H__

public static EFI_GUID EFI_STATUS_CODE_RUNTIME_PROTOCOL_GUID = new GUID(0xd2b2b828, 0x826, 0x48a7, new byte[] { 0xb3, 0xdf, 0x98, 0x3c, 0x0, 0x60, 0x24, 0xf0 });





























///
/// Provides the service required to report a status code to the platform firmware.
/// This protocol must be produced by a runtime DXE driver.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_STATUS_CODE_PROTOCOL
{
  /**
    Provides an interface that a software module can call to report a status code.

    @param  Type             Indicates the type of status code being reported.
    @param  Value            Describes the current status of a hardware or software entity.
                             This included information about the class and subclass that is used to
                             classify the entity as well as an operation.
    @param  Instance         The enumeration of a hardware or software entity within
                             the system. Valid instance numbers start with 1.
    @param  CallerId         This optional parameter may be used to identify the caller.
                             This parameter allows the status code driver to apply different rules to
                             different callers.
    @param  Data             This optional parameter may be used to pass additional data.

    @retval EFI_SUCCESS           The function completed successfully
    @retval EFI_DEVICE_ERROR      The function should not be completed due to a device error.

  **/
  public readonly delegate* unmanaged<EFI_STATUS_CODE_TYPE, EFI_STATUS_CODE_VALUE, uint, EFI_GUID*, EFI_STATUS_CODE_DATA*, EFI_STATUS> ReportStatusCode;
}

// extern EFI_GUID  gEfiStatusCodeRuntimeProtocolGuid;

// #endif
