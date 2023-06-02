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

//
// CDROM_VOLUME_DESCRIPTOR.Types, defined in ISO 9660
//
public unsafe partial class EFI
{
  public const ulong CDVOL_TYPE_STANDARD = 0x0;
  public const ulong CDVOL_TYPE_CODED = 0x1;
  public const ulong CDVOL_TYPE_END = 0xFF;

  ///
  /// CDROM_VOLUME_DESCRIPTOR.Id
  ///
  public const ulong CDVOL_ID = "CD001";

  ///
  /// CDROM_VOLUME_DESCRIPTOR.SystemId
  ///
  public const ulong CDVOL_ELTORITO_ID = "EL TORITO SPECIFICATION";

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
public unsafe struct Unknown
{
  struct {
   [FieldOffset(0)] public byte Type;
  [FieldOffset(0)] public fixed byte Id[5];          ///< "CD001"
  [FieldOffset(0)] public fixed byte Reserved[82];
}

///
/// Boot Record Volume Descriptor, defined in "El Torito" Specification.
///
struct {
    byte Type;           ///< Must be 0
byte Id[5];          ///< "CD001"
byte Version;        ///< Must be 1
byte SystemId[32];   ///< "EL TORITO SPECIFICATION"
byte Unused[32];     ///< Must be 0
byte EltCatalog[4];  ///< Absolute pointer to first sector of Boot Catalog
byte Unused2[13];    ///< Must be 0
  } BootRecordVolume;

///
/// Primary Volume Descriptor, defined in ISO 9660.
///
struct {
    byte Type;
byte Id[5];         ///< "CD001"
byte Version;
byte Unused;        ///< Must be 0
byte SystemId[32];
byte VolumeId[32];
byte Unused2[8];      ///< Must be 0
uint VolSpaceSize[2]; ///< the number of Logical Blocks
  } PrimaryVolume;
} CDROM_VOLUME_DESCRIPTOR;

///
/// Catalog Entry
///
[StructLayout(LayoutKind.Explicit)]
public unsafe struct Unknown
{
  struct {
   [FieldOffset(0)] public fixed byte Reserved[0x20];
}

///
/// Catalog validation entry (Catalog header)
///
struct {
    byte Indicator;     ///< Must be 01
byte PlatformId;
ushort Reserved;
byte ManufacId[24];
ushort Checksum;
ushort Id55AA;
  } Catalog;

///
/// Initial/Default Entry or Section Entry
///
struct {
    byte Indicator;     ///< 88 = Bootable, 00 = Not Bootable
byte MediaType : 4;
byte Reserved1 : 4; ///< Must be 0
ushort LoadSegment;
byte SystemType;
byte Reserved2;     ///< Must be 0
ushort SectorCount;
uint Lba;
  } Boot;

///
/// Section Header Entry
///
struct {
    byte Indicator;     ///< 90 - Header, more header follw, 91 - Final Header
byte PlatformId;
ushort SectionEntries; ///< Number of section entries following this header
byte Id[28];
  } Section;
} ELTORITO_CATALOG;

// #pragma pack()

// #endif
