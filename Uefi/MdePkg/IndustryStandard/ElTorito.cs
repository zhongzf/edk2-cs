using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  ElTorito Partitions Format Definition.
  This file includes some definitions from
  1. "El Torito" Bootable CD-ROM Format Specification, Version 1.0.
  2. Volume and File Structure of CDROM for Information Interchange,
     Standard ECMA-119. (IS0 9660)

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _ELTORITO_H_
// #define _ELTORITO_H_

public unsafe partial class EFI
{
  //
  // CDROM_VOLUME_DESCRIPTOR.Types, defined in ISO 9660
  //
  public const ulong CDVOL_TYPE_STANDARD = 0x0;
  public const ulong CDVOL_TYPE_CODED = 0x1;
  public const ulong CDVOL_TYPE_END = 0xFF;

  ///
  /// CDROM_VOLUME_DESCRIPTOR.Id
  ///
  public const string CDVOL_ID = "CD001";

  ///
  /// CDROM_VOLUME_DESCRIPTOR.SystemId
  ///
  public const string CDVOL_ELTORITO_ID = "EL TORITO SPECIFICATION";

  //
  // Indicator types
  //
  public const ulong ELTORITO_ID_CATALOG = 0x01;
  public const ulong ELTORITO_ID_SECTION_BOOTABLE = 0x88;
  public const ulong ELTORITO_ID_SECTION_NOT_BOOTABLE = 0x00;
  public const ulong ELTORITO_ID_SECTION_HEADER = 0x90;
  public const ulong ELTORITO_ID_SECTION_HEADER_FINAL = 0x91;

  //
  // ELTORITO_CATALOG.Boot.MediaTypes
  //
  public const ulong ELTORITO_NO_EMULATION = 0x00;
  public const ulong ELTORITO_12_DISKETTE = 0x01;
  public const ulong ELTORITO_14_DISKETTE = 0x02;
  public const ulong ELTORITO_28_DISKETTE = 0x03;
  public const ulong ELTORITO_HARD_DISK = 0x04;

  // #pragma pack(1)
}

///
/// CD-ROM Volume Descriptor
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct CDROM_VOLUME_DESCRIPTOR
{
  /*   struct { */
  [FieldOffset(0)] public byte Type;
  [FieldOffset(2)] public fixed byte Id[5];          ///< "CD001"
  [FieldOffset(4)] public fixed byte Reserved[82];
  /*   } Unknown; */

  ///
  /// Boot Record Volume Descriptor, defined in "El Torito" Specification.
  ///
  /*   struct { */
  //[FieldOffset(0)] public byte Type;           ///< Must be 0
  //[FieldOffset(0)] public fixed byte Id[5];          ///< "CD001"
  //[FieldOffset(0)] public byte Version;        ///< Must be 1
  //[FieldOffset(0)] public fixed byte SystemId[32];   ///< "EL TORITO SPECIFICATION"
  //[FieldOffset(0)] public fixed byte Unused[32];     ///< Must be 0
  //[FieldOffset(0)] public fixed byte EltCatalog[4];  ///< Absolute pointer to first sector of Boot Catalog
  //[FieldOffset(0)] public fixed byte Unused2[13];    ///< Must be 0
  /*   } BootRecordVolume; */

  ///
  /// Primary Volume Descriptor, defined in ISO 9660.
  ///
  /*   struct { */
  //[FieldOffset(0)] public byte Type;
  //[FieldOffset(0)] public fixed byte Id[5];         ///< "CD001"
  //[FieldOffset(0)] public byte Version;
  //[FieldOffset(0)] public byte Unused;        ///< Must be 0
  //[FieldOffset(0)] public fixed byte SystemId[32];
  //[FieldOffset(0)] public fixed byte VolumeId[32];
  //[FieldOffset(0)] public fixed byte Unused2[8];      ///< Must be 0
  //[FieldOffset(0)] public fixed uint VolSpaceSize[2]; ///< the number of Logical Blocks
/*   } PrimaryVolume; */
}

///
/// Catalog Entry
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct ELTORITO_CATALOG
{
  /*   struct { */
  [FieldOffset(0)] public fixed byte Reserved[0x20];
  /*   } Unknown; */

  ///
  /// Catalog validation entry (Catalog header)
  ///
  /*   struct { */
  //[FieldOffset(0)] public byte Indicator;     ///< Must be 01
  //[FieldOffset(0)] public byte PlatformId;
  //[FieldOffset(0)] public ushort Reserved;
  //[FieldOffset(0)] public fixed byte ManufacId[24];
  //[FieldOffset(0)] public ushort Checksum;
  //[FieldOffset(0)] public ushort Id55AA;
  /*   } Catalog; */

  ///
  /// Initial/Default Entry or Section Entry
  ///
  /*   struct { */
  //[FieldOffset(0)] public byte Indicator;     ///< 88 = Bootable, 00 = Not Bootable
  //[FieldOffset(0)] public byte MediaType; // = 4;
  //[FieldOffset(0)] public byte Reserved1; // = 4; ///< Must be 0
  //[FieldOffset(0)] public ushort LoadSegment;
  //[FieldOffset(0)] public byte SystemType;
  //[FieldOffset(0)] public byte Reserved2;     ///< Must be 0
  //[FieldOffset(0)] public ushort SectorCount;
  //[FieldOffset(0)] public uint Lba;
  /*   } Boot; */

  ///
  /// Section Header Entry
  ///
  /*   struct { */
  [FieldOffset(0)] public byte Indicator;     ///< 90 - Header, more header follw, 91 - Final Header
  [FieldOffset(0)] public byte PlatformId;
  [FieldOffset(0)] public ushort SectionEntries; ///< Number of section entries following this header
  [FieldOffset(0)] public fixed byte Id[28];
  /*   } Section; */
}

// #pragma pack()

// #endif
