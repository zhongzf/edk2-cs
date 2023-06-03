using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file declares the SMBus definitions defined in SmBus Specification V2.0
  and defined in PI1.0 specification volume 5.

  Copyright (c) 2007 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _SMBUS_H_
// #define _SMBUS_H_

///
/// UDID of SMBUS device.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMBUS_UDID
{
  public uint VendorSpecificId;
  public ushort SubsystemDeviceId;
  public ushort SubsystemVendorId;
  public ushort Interface;
  public ushort DeviceId;
  public ushort VendorId;
  public byte VendorRevision;
  public byte DeviceCapabilities;
}

///
/// Smbus Device Address
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMBUS_DEVICE_ADDRESS
{
  ///
  /// The SMBUS hardware address to which the SMBUS device is preassigned or allocated.
  ///
  public ulong SmbusDeviceAddress = 7;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMBUS_DEVICE_MAP
{
  ///
  /// The SMBUS hardware address to which the SMBUS device is preassigned or
  /// allocated. Type EFI_SMBUS_DEVICE_ADDRESS is defined in EFI_PEI_SMBUS2_PPI.Execute().
  ///
  public EFI_SMBUS_DEVICE_ADDRESS SmbusDeviceAddress;
  ///
  /// The SMBUS Unique Device Identifier (UDID) as defined in EFI_SMBUS_UDID.
  /// Type EFI_SMBUS_UDID is defined in EFI_PEI_SMBUS2_PPI.ArpDevice().
  ///
  public EFI_SMBUS_UDID SmbusDeviceUdid;
}

///
/// Smbus Operations
///
public enum EFI_SMBUS_OPERATION
{
  EfiSmbusQuickRead,
  EfiSmbusQuickWrite,
  EfiSmbusReceiveByte,
  EfiSmbusSendByte,
  EfiSmbusReadByte,
  EfiSmbusWriteByte,
  EfiSmbusReadWord,
  EfiSmbusWriteWord,
  EfiSmbusReadBlock,
  EfiSmbusWriteBlock,
  EfiSmbusProcessCall,
  EfiSmbusBWBRProcessCall
}

///
/// EFI_SMBUS_DEVICE_COMMAND
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SMBUS_DEVICE_COMMAND { ulong Value; public static implicit operator EFI_SMBUS_DEVICE_COMMAND(ulong value) => new EFI_SMBUS_DEVICE_COMMAND() { Value = value }; public static implicit operator ulong(EFI_SMBUS_DEVICE_COMMAND value) => value.Value; }

// #endif
