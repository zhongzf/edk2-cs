using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI RAM Disk Protocol.

  Copyright (c) 2016, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.6

**/

// #ifndef __RAM_DISK_PROTOCOL_H__
// #define __RAM_DISK_PROTOCOL_H__

//
// EFI RAM Disk Protocol GUID value
//
public static EFI_GUID EFI_RAM_DISK_PROTOCOL_GUID = new GUID(0xab38a0df, 0x6873, 0x44a9, new byte[] { 0x87, 0xe6, 0xd4, 0xeb, 0x56, 0x14, 0x84, 0x49 });;

//
// Forward reference for pure ANSI compatability
//
// typedef struct _EFI_RAM_DISK_PROTOCOL EFI_RAM_DISK_PROTOCOL;






























































///
/// RAM Disk Protocol structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_RAM_DISK_PROTOCOL
{
  /**
    Register a RAM disk with specified address, size and type.

    @param[in]  RamDiskBase    The base address of registered RAM disk.
    @param[in]  RamDiskSize    The size of registered RAM disk.
    @param[in]  RamDiskType    The type of registered RAM disk. The GUID can be
                               any of the values defined in section 9.3.6.9, or a
                               vendor defined GUID.
    @param[in]  ParentDevicePath
                               Pointer to the parent device path. If there is no
                               parent device path then ParentDevicePath is NULL.
    @param[out] DevicePath     On return, points to a pointer to the device path
                               of the RAM disk device.
                               If ParentDevicePath is not NULL, the returned
                               DevicePath is created by appending a RAM disk node
                               to the parent device path. If ParentDevicePath is
                               NULL, the returned DevicePath is a RAM disk device
                               path without appending. This function is
                               responsible for allocating the buffer DevicePath
                               with the boot service AllocatePool().

    @retval EFI_SUCCESS             The RAM disk is registered successfully.
    @retval EFI_INVALID_PARAMETER   DevicePath or RamDiskType is NULL.
                                    RamDiskSize is 0.
    @retval EFI_ALREADY_STARTED     A Device Path Protocol instance to be created
                                    is already present in the handle database.
    @retval EFI_OUT_OF_RESOURCES    The RAM disk register operation fails due to
                                    resource limitation.

  **/
  public readonly delegate* unmanaged<ulong, ulong, EFI_GUID*, EFI_DEVICE_PATH*, EFI_DEVICE_PATH_PROTOCOL**, EFI_STATUS> Register;
  /**
    Unregister a RAM disk specified by DevicePath.

    @param[in] DevicePath      A pointer to the device path that describes a RAM
                               Disk device.

    @retval EFI_SUCCESS             The RAM disk is unregistered successfully.
    @retval EFI_INVALID_PARAMETER   DevicePath is NULL.
    @retval EFI_UNSUPPORTED         The device specified by DevicePath is not a
                                    valid ramdisk device path and not supported
                                    by the driver.
    @retval EFI_NOT_FOUND           The RAM disk pointed by DevicePath doesn't
                                    exist.

  **/
  public readonly delegate* unmanaged<EFI_DEVICE_PATH_PROTOCOL*, EFI_STATUS> Unregister;
}

///
/// RAM Disk Protocol GUID variable.
///
// extern EFI_GUID  gEfiRamDiskProtocolGuid;

// #endif
