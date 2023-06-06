using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Block Translation Table (BTT) metadata layout definition.

  BTT is a layout and set of rules for doing block I/O that provide powerfail
  write atomicity of a single block.

Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This metadata layout definition was introduced in UEFI Specification 2.7.

**/

// #ifndef _BTT_H_
// #define _BTT_H_

public unsafe partial class EFI
{
  ///
  /// The BTT layout and behavior is described by the GUID as below.
  ///
  public static EFI_GUID EFI_BTT_ABSTRACTION_GUID => new GUID(
      0x18633bfc, 0x1735, 0x4217, 0x8a, 0xc9, 0x17, 0x23, 0x92, 0x82, 0xd3, 0xf8);

  //
  // Alignment of all BTT structures
  //
  public const ulong EFI_BTT_ALIGNMENT = 4096;

  public const ulong EFI_BTT_INFO_UNUSED_LEN = 3968;

  public const ulong EFI_BTT_INFO_BLOCK_SIG_LEN = 16;

  ///
  /// Indicate inconsistent metadata or lost metadata due to unrecoverable media errors.
  ///
  public const ulong EFI_BTT_INFO_BLOCK_FLAGS_ERROR = 0x00000001;

  public const ulong EFI_BTT_INFO_BLOCK_MAJOR_VERSION = 2;
  public const ulong EFI_BTT_INFO_BLOCK_MINOR_VERSION = 0;
}

///
/// Block Translation Table (BTT) Info Block
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BTT_INFO_BLOCK
{
  ///
  /// Signature of the BTT Index Block data structure.
  /// Shall be "BTT_ARENA_INFO\0\0".
  ///
  public byte[/*EFI_BTT_INFO_BLOCK_SIG_LEN*/] Sig;

  ///
  /// UUID identifying this BTT instance.
  ///
  public GUID Uuid;

  ///
  /// UUID of containing namespace.
  ///
  public GUID ParentUuid;

  ///
  /// Attributes of this BTT Info Block.
  ///
  public uint Flags;

  ///
  /// Major version number. Currently at version 2.
  ///
  public ushort Major;

  ///
  /// Minor version number. Currently at version 0.
  ///
  public ushort Minor;

  ///
  /// Advertised LBA size in bytes. I/O requests shall be in this size chunk.
  ///
  public uint ExternalLbaSize;

  ///
  /// Advertised number of LBAs in this arena.
  ///
  public uint ExternalNLba;

  ///
  /// Internal LBA size shall be greater than or equal to ExternalLbaSize and shall not be smaller than 512 bytes.
  ///
  public uint InternalLbaSize;

  ///
  /// Number of internal blocks in the arena data area.
  ///
  public uint InternalNLba;

  ///
  /// Number of free blocks maintained for writes to this arena.
  ///
  public uint NFree;

  ///
  /// The size of this info block in bytes.
  ///
  public uint InfoSize;

  ///
  /// Offset of next arena, relative to the beginning of this arena.
  ///
  public ulong NextOff;

  ///
  /// Offset of the data area for this arena, relative to the beginning of this arena.
  ///
  public ulong DataOff;

  ///
  /// Offset of the map for this arena, relative to the beginning of this arena.
  ///
  public ulong MapOff;

  ///
  /// Offset of the flog for this arena, relative to the beginning of this arena.
  ///
  public ulong FlogOff;

  ///
  /// Offset of the backup copy of this arena's info block, relative to the beginning of this arena.
  ///
  public ulong InfoOff;

  ///
  /// Shall be zero.
  ///
  public fixed byte Unused[EFI_BTT_INFO_UNUSED_LEN];

  ///
  /// 64-bit Fletcher64 checksum of all fields.
  ///
  public ulong Checksum;
}

///
/// BTT Map entry maps an LBA that indexes into the arena, to its actual location.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BTT_MAP_ENTRY
{
  ///
  /// Post-map LBA number (block number in this arena's data area)
  ///
  public uint PostMapLba; // = 30;

  ///
  /// When set and Zero is not set, reads on this block return an error.
  /// When set and Zero is set, indicate a map entry in its normal, non-error state.
  ///
  public uint Error; // = 1;

  ///
  /// When set and Error is not set, reads on this block return a full block of zeros.
  /// When set and Error is set, indicate a map entry in its normal, non-error state.
  ///
  public uint Zero; // = 1;
}

public unsafe partial class EFI
{
  ///
  /// Alignment of each flog structure
  ///
  public const ulong EFI_BTT_FLOG_ENTRY_ALIGNMENT = 64;
}

///
/// The BTT Flog is both a free list and a log.
/// The Flog size is determined by the EFI_BTT_INFO_BLOCK.NFree which determines how many of these flog
/// entries there are.
/// The Flog location is the highest aligned address in the arena after space for the backup info block.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_BTT_FLOG
{
  ///
  /// Last pre-map LBA written using this flog entry.
  ///
  public uint Lba0;

  ///
  /// Old post-map LBA.
  ///
  public uint OldMap0;

  ///
  /// New post-map LBA.
  ///
  public uint NewMap0;

  ///
  /// The Seq0 field in each flog entry is used to determine which set of fields is newer between the two sets
  /// (Lba0, OldMap0, NewMpa0, Seq0 vs Lba1, Oldmap1, NewMap1, Seq1).
  ///
  public uint Seq0;

  ///
  /// Alternate lba entry.
  ///
  public uint Lba1;

  ///
  /// Alternate old entry.
  ///
  public uint OldMap1;

  ///
  /// Alternate new entry.
  ///
  public uint NewMap1;

  ///
  /// Alternate Seq entry.
  ///
  public uint Seq1;
}

// extern GUID  gEfiBttAbstractionGuid;

// #endif //_BTT_H_
