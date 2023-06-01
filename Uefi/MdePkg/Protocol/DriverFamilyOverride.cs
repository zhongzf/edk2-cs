namespace Uefi;
/** @file
  UEFI Driver Family Protocol

Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_DRIVER_FAMILY_OVERRIDE_H__
// #define __EFI_DRIVER_FAMILY_OVERRIDE_H__

public static EFI_GUID EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL_GUID = new GUID( 
    0xb1ee129e, 0xda36, 0x4181, new byte[] { 0x91, 0xf8, 0x4, 0xa4, 0x92, 0x37, 0x66, 0xa7 });

// typedef struct _EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL;

//
// Prototypes for the Driver Family Override Protocol
//
//





















///
/// When installed, the Driver Family Override Protocol produces a GUID that represents
/// a family of drivers.  Drivers with the same GUID are members of the same family
/// When drivers are connected to controllers, drivers with a higher revision value
/// in the same driver family are connected with a higher priority than drivers
/// with a lower revision value in the same driver family.  The EFI Boot Service
/// Connect Controller uses five rules to build a prioritized list of drivers when
/// a request is made to connect a driver to a controller.  The Driver Family Protocol
/// rule is between the Platform Specific Driver Override Protocol and above the
/// Bus Specific Driver Override Protocol.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL {
/**
  This function returns the version value associated with the driver specified by This.

  Retrieves the version of the driver that is used by the EFI Boot Service ConnectController()
  to sort the set of Driver Binding Protocols in order from highest priority to lowest priority.
  For drivers that support the Driver Family Override Protocol, those drivers are sorted so that
  the drivers with higher values returned by GetVersion() are higher priority than drivers that
  return lower values from GetVersion().

  @param  This                  A pointer to the EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL instance.

  @return The version value associated with the driver specified by This.

**/
public readonly delegate* unmanaged<EFI_DRIVER_FAMILY_OVERRIDE_PROTOCOL*, EFI_STATUS> GetVersion;
}

// extern EFI_GUID  gEfiDriverFamilyOverrideProtocolGuid;

// #endif
