using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Guid & data structure used for Delivering Capsules Containing Updates to Firmware
  Management Protocol

  Copyright (c) 2013 - 2015, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  GUIDs defined in UEFI 2.4 spec.

**/

// #ifndef _FMP_CAPSULE_GUID_H__
// #define _FMP_CAPSULE_GUID_H__

public unsafe partial class EFI
{
  //
  // This is the GUID of the capsule for Firmware Management Protocol.
  //
  public static EFI_GUID EFI_FIRMWARE_MANAGEMENT_CAPSULE_ID_GUID => new GUID(
      0x6dcbd5ed, 0xe82d, 0x4c44, 0xbd, 0xa1, 0x71, 0x94, 0x19, 0x9a, 0xd9, 0x2a);

  // #pragma pack(1)
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_MANAGEMENT_CAPSULE_HEADER
{
  public uint Version;

  ///
  /// The number of drivers included in the capsule and the number of corresponding
  /// offsets stored in ItemOffsetList array.
  ///
  public ushort EmbeddedDriverCount;

  ///
  /// The number of payload items included in the capsule and the number of
  /// corresponding offsets stored in the ItemOffsetList array.
  ///
  public ushort PayloadItemCount;

  ///
  /// Variable length array of dimension [EmbeddedDriverCount + PayloadItemCount]
  /// containing offsets of each of the drivers and payload items contained within the capsule
  ///
  // ulong ItemOffsetList[];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_MANAGEMENT_CAPSULE_IMAGE_HEADER
{
  public uint Version;

  ///
  /// Used to identify device firmware targeted by this update. This guid is matched by
  /// system firmware against ImageTypeId field within a EFI_FIRMWARE_IMAGE_DESCRIPTOR
  ///
  public EFI_GUID UpdateImageTypeId;

  ///
  /// Passed as ImageIndex in call to EFI_FIRMWARE_MANAGEMENT_PROTOCOL.SetImage()
  ///
  public byte UpdateImageIndex;
  public fixed byte reserved_bytes[3];

  ///
  /// Size of the binary update image which immediately follows this structure
  ///
  public uint UpdateImageSize;

  ///
  /// Size of the VendorCode bytes which optionally immediately follow binary update image in the capsule
  ///
  public uint UpdateVendorCodeSize;

  ///
  /// The HardwareInstance to target with this update. If value is zero it means match all
  /// HardwareInstances. This field allows update software to target only a single device in
  /// cases where there are more than one device with the same ImageTypeId GUID.
  /// This header is outside the signed data of the Authentication Info structure and
  /// therefore can be modified without changing the Auth data.
  ///
  public ulong UpdateHardwareInstance;

  ///
  /// A 64-bit bitmask that determines what sections are added to the payload.
  public unsafe partial class EFI
  {
    public const ulong CAPSULE_SUPPORT_AUTHENTICATION = 0x0000000000000001;
    public const ulong CAPSULE_SUPPORT_DEPENDENCY = 0x0000000000000002;
    ///
    public ulong ImageCapsuleSupport;
  }

  // #pragma pack()

  public const ulong EFI_FIRMWARE_MANAGEMENT_CAPSULE_HEADER_INIT_VERSION = 0x00000001;
  public const ulong EFI_FIRMWARE_MANAGEMENT_CAPSULE_IMAGE_HEADER_INIT_VERSION = 0x00000003;
  public const ulong CAPSULE_SUPPORT_AUTHENTICATION = 0x0000000000000001;
  public const ulong CAPSULE_SUPPORT_DEPENDENCY = 0x0000000000000002;

  // extern EFI_GUID  gEfiFmpCapsuleGuid;
}

// #endif
