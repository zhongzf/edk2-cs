using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The firmware volume related definitions in PI.

  Copyright (c) 2006 - 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  PI Version 1.6

**/

// #ifndef __PI_FIRMWAREVOLUME_H__
// #define __PI_FIRMWAREVOLUME_H__

///
/// EFI_FV_FILE_ATTRIBUTES
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FV_FILE_ATTRIBUTES { uint Value; public static implicit operator EFI_FV_FILE_ATTRIBUTES(uint value) => new EFI_FV_FILE_ATTRIBUTES() { Value = value }; public static implicit operator uint(EFI_FV_FILE_ATTRIBUTES value) => value.Value; }

public unsafe partial class EFI
{
  //
  // Value of EFI_FV_FILE_ATTRIBUTES.
  //
  public const ulong EFI_FV_FILE_ATTRIB_ALIGNMENT = 0x0000001F;
  public const ulong EFI_FV_FILE_ATTRIB_FIXED = 0x00000100;
  public const ulong EFI_FV_FILE_ATTRIB_MEMORY_MAPPED = 0x00000200;
}

///
/// type of EFI FVB attribute
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FVB_ATTRIBUTES_2 { uint Value; public static implicit operator EFI_FVB_ATTRIBUTES_2(uint value) => new EFI_FVB_ATTRIBUTES_2() { Value = value }; public static implicit operator uint(EFI_FVB_ATTRIBUTES_2 value) => value.Value; }

public unsafe partial class EFI
{
  //
  // Attributes bit definitions
  //
  public const ulong EFI_FVB2_READ_DISABLED_CAP = 0x00000001;
  public const ulong EFI_FVB2_READ_ENABLED_CAP = 0x00000002;
  public const ulong EFI_FVB2_READ_STATUS = 0x00000004;
  public const ulong EFI_FVB2_WRITE_DISABLED_CAP = 0x00000008;
  public const ulong EFI_FVB2_WRITE_ENABLED_CAP = 0x00000010;
  public const ulong EFI_FVB2_WRITE_STATUS = 0x00000020;
  public const ulong EFI_FVB2_LOCK_CAP = 0x00000040;
  public const ulong EFI_FVB2_LOCK_STATUS = 0x00000080;
  public const ulong EFI_FVB2_STICKY_WRITE = 0x00000200;
  public const ulong EFI_FVB2_MEMORY_MAPPED = 0x00000400;
  public const ulong EFI_FVB2_ERASE_POLARITY = 0x00000800;
  public const ulong EFI_FVB2_READ_LOCK_CAP = 0x00001000;
  public const ulong EFI_FVB2_READ_LOCK_STATUS = 0x00002000;
  public const ulong EFI_FVB2_WRITE_LOCK_CAP = 0x00004000;
  public const ulong EFI_FVB2_WRITE_LOCK_STATUS = 0x00008000;
  public const ulong EFI_FVB2_ALIGNMENT = 0x001F0000;
  public const ulong EFI_FVB2_ALIGNMENT_1 = 0x00000000;
  public const ulong EFI_FVB2_ALIGNMENT_2 = 0x00010000;
  public const ulong EFI_FVB2_ALIGNMENT_4 = 0x00020000;
  public const ulong EFI_FVB2_ALIGNMENT_8 = 0x00030000;
  public const ulong EFI_FVB2_ALIGNMENT_16 = 0x00040000;
  public const ulong EFI_FVB2_ALIGNMENT_32 = 0x00050000;
  public const ulong EFI_FVB2_ALIGNMENT_64 = 0x00060000;
  public const ulong EFI_FVB2_ALIGNMENT_128 = 0x00070000;
  public const ulong EFI_FVB2_ALIGNMENT_256 = 0x00080000;
  public const ulong EFI_FVB2_ALIGNMENT_512 = 0x00090000;
  public const ulong EFI_FVB2_ALIGNMENT_1K = 0x000A0000;
  public const ulong EFI_FVB2_ALIGNMENT_2K = 0x000B0000;
  public const ulong EFI_FVB2_ALIGNMENT_4K = 0x000C0000;
  public const ulong EFI_FVB2_ALIGNMENT_8K = 0x000D0000;
  public const ulong EFI_FVB2_ALIGNMENT_16K = 0x000E0000;
  public const ulong EFI_FVB2_ALIGNMENT_32K = 0x000F0000;
  public const ulong EFI_FVB2_ALIGNMENT_64K = 0x00100000;
  public const ulong EFI_FVB2_ALIGNMENT_128K = 0x00110000;
  public const ulong EFI_FVB2_ALIGNMENT_256K = 0x00120000;
  public const ulong EFI_FVB2_ALIGNMENT_512K = 0x00130000;
  public const ulong EFI_FVB2_ALIGNMENT_1M = 0x00140000;
  public const ulong EFI_FVB2_ALIGNMENT_2M = 0x00150000;
  public const ulong EFI_FVB2_ALIGNMENT_4M = 0x00160000;
  public const ulong EFI_FVB2_ALIGNMENT_8M = 0x00170000;
  public const ulong EFI_FVB2_ALIGNMENT_16M = 0x00180000;
  public const ulong EFI_FVB2_ALIGNMENT_32M = 0x00190000;
  public const ulong EFI_FVB2_ALIGNMENT_64M = 0x001A0000;
  public const ulong EFI_FVB2_ALIGNMENT_128M = 0x001B0000;
  public const ulong EFI_FVB2_ALIGNMENT_256M = 0x001C0000;
  public const ulong EFI_FVB2_ALIGNMENT_512M = 0x001D0000;
  public const ulong EFI_FVB2_ALIGNMENT_1G = 0x001E0000;
  public const ulong EFI_FVB2_ALIGNMENT_2G = 0x001F0000;
  public const ulong EFI_FVB2_WEAK_ALIGNMENT = 0x80000000;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FV_BLOCK_MAP_ENTRY
{
  ///
  /// The number of sequential blocks which are of the same size.
  ///
  public uint NumBlocks;
  ///
  /// The size of the blocks.
  ///
  public uint Length;
}

///
/// Describes the features and layout of the firmware volume.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_HEADER
{
  ///
  /// The first 16 bytes are reserved to allow for the reset vector of
  /// processors whose reset vector is at address 0.
  ///
  public fixed byte ZeroVector[16];
  ///
  /// Declares the file system with which the firmware volume is formatted.
  ///
  public EFI_GUID FileSystemGuid;
  ///
  /// Length in bytes of the complete firmware volume, including the header.
  ///
  public ulong FvLength;
  ///
  /// Set to EFI_FVH_SIGNATURE
  ///
  public uint Signature;
  ///
  /// Declares capabilities and power-on defaults for the firmware volume.
  ///
  public EFI_FVB_ATTRIBUTES_2 Attributes;
  ///
  /// Length in bytes of the complete firmware volume header.
  ///
  public ushort HeaderLength;
  ///
  /// A 16-bit checksum of the firmware volume header. A valid header sums to zero.
  ///
  public ushort Checksum;
  ///
  /// Offset, relative to the start of the header, of the extended header
  /// (EFI_FIRMWARE_VOLUME_EXT_HEADER) or zero if there is no extended header.
  ///
  public ushort ExtHeaderOffset;
  ///
  /// This field must always be set to zero.
  ///
  public fixed byte Reserved[1];
  ///
  /// Set to 2. Future versions of this specification may define new header fields and will
  /// increment the Revision field accordingly.
  ///
  public byte Revision;
  ///
  /// An array of run-length encoded FvBlockMapEntry structures. The array is
  ///
  public EFI_FV_BLOCK_MAP_ENTRY[/*1*/] BlockMap;
}

public unsafe partial class EFI
{
  //public const ulong EFI_FVH_SIGNATURE = SIGNATURE_32 ('_', 'F', 'V', 'H');

  ///
  /// Firmware Volume Header Revision definition
  ///
  public const ulong EFI_FVH_REVISION = 0x02;
}

///
/// Extension header pointed by ExtHeaderOffset of volume header.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_EXT_HEADER
{
  ///
  /// Firmware volume name.
  ///
  public EFI_GUID FvName;
  ///
  /// Size of the rest of the extension header, including this structure.
  ///
  public uint ExtHeaderSize;
}

///
/// Entry struture for describing FV extension header
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_EXT_ENTRY
{
  ///
  /// Size of this header extension.
  ///
  public ushort ExtEntrySize;
  ///
  /// Type of the header.
  ///
  public ushort ExtEntryType;
}

public unsafe partial class EFI
{
  public const ulong EFI_FV_EXT_TYPE_OEM_TYPE = 0x01;
  ///
  /// This extension header provides a mapping between a GUID and an OEM file type.
  ///
}
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_EXT_ENTRY_OEM_TYPE
{
  ///
  /// Standard extension entry, with the type EFI_FV_EXT_TYPE_OEM_TYPE.
  ///
  public EFI_FIRMWARE_VOLUME_EXT_ENTRY Hdr;
  ///
  /// A bit mask, one bit for each file type between 0xC0 (bit 0) and 0xDF (bit 31). If a bit
  /// is '1', then the GUID entry exists in Types. If a bit is '0' then no GUID entry exists in Types.
  ///
  public uint TypeMask;
  ///
  /// An array of GUIDs, each GUID representing an OEM file type.
  ///
  /// EFI_GUID  Types[1];
  ///
}

public unsafe partial class EFI
{
  public const ulong EFI_FV_EXT_TYPE_GUID_TYPE = 0x0002;
}

///
/// This extension header EFI_FIRMWARE_VOLUME_EXT_ENTRY_GUID_TYPE provides a vendor specific
/// GUID FormatType type which includes a length and a successive series of data bytes.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_EXT_ENTRY_GUID_TYPE
{
  ///
  /// Standard extension entry, with the type EFI_FV_EXT_TYPE_OEM_TYPE.
  ///
  public EFI_FIRMWARE_VOLUME_EXT_ENTRY Hdr;
  ///
  /// Vendor-specific GUID.
  ///
  public EFI_GUID FormatType;
  ///
  /// An arry of bytes of length Length.
  ///
  /// byte                             Data[1];
  ///
}

public unsafe partial class EFI
{
  public const ulong EFI_FV_EXT_TYPE_USED_SIZE_TYPE = 0x03;
}

///
/// The EFI_FIRMWARE_VOLUME_EXT_ENTRY_USED_SIZE_TYPE can be used to find
/// out how many EFI_FVB2_ERASE_POLARITY bytes are at the end of the FV.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FIRMWARE_VOLUME_EXT_ENTRY_USED_SIZE_TYPE
{
  ///
  /// Standard extension entry, with the type EFI_FV_EXT_TYPE_USED_SIZE_TYPE.
  ///
  public EFI_FIRMWARE_VOLUME_EXT_ENTRY Hdr;
  ///
  /// The number of bytes of the FV that are in uses. The remaining
  /// EFI_FIRMWARE_VOLUME_HEADER FvLength minus UsedSize bytes in
  /// the FV must contain the value implied by EFI_FVB2_ERASE_POLARITY.
  ///
  public uint UsedSize;
}

// #endif
