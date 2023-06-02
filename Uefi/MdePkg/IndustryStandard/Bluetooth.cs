using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file contains the Bluetooth definitions that are consumed by drivers.
  These definitions are from Bluetooth Core Specification Version 4.0 June, 2010

  Copyright (c) 2015 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _BLUETOOTH_H_
// #define _BLUETOOTH_H_

// #pragma pack(1)

///
/// BLUETOOTH_ADDRESS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BLUETOOTH_ADDRESS
{
  ///
  /// 48bit Bluetooth device address.
  ///
  public fixed byte Address[6];
}

///
/// BLUETOOTH_CLASS_OF_DEVICE. See Bluetooth specification for detail.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BLUETOOTH_CLASS_OF_DEVICE
{
  public byte FormatType = 2;
  public byte MinorDeviceClass = 6;
  public ushort MajorDeviceClass = 5;
  public ushort MajorServiceClass = 11;
}

///
/// BLUETOOTH_LE_ADDRESS
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct BLUETOOTH_LE_ADDRESS
{
  ///
  /// 48-bit Bluetooth device address
  ///
  public fixed byte Address[6];
  ///
  /// 0x00 - Public Device Address
  /// 0x01 - Random Device Address
  ///
  public byte Type;
}

// #pragma pack()

public unsafe partial class EFI
{
  public const ulong BLUETOOTH_HCI_COMMAND_LOCAL_READABLE_NAME_MAX_SIZE = 248;

  public const ulong BLUETOOTH_HCI_LINK_KEY_SIZE = 16;
}

// #endif
