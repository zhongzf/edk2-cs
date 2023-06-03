using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  OSTA Universal Disk Format (UDF) definitions.

  Copyright (C) 2014-2017 Paulo Alcantara <pcacjr@zytor.com>

  SPDX-License-Identifier: BSD-2-Clause-Patent
**/

// #ifndef __UDF_H__
// #define __UDF_H__

public unsafe partial class EFI
{
  public const ulong UDF_BEA_IDENTIFIER = "BEA01";
  public const ulong UDF_NSR2_IDENTIFIER = "NSR02";
  public const ulong UDF_NSR3_IDENTIFIER = "NSR03";
  public const ulong UDF_TEA_IDENTIFIER = "TEA01";

  public const ulong UDF_LOGICAL_SECTOR_SHIFT = 11;
  public const ulong UDF_LOGICAL_SECTOR_SIZE = ((ulong)(1u << UDF_LOGICAL_SECTOR_SHIFT));
  public const ulong UDF_VRS_START_OFFSET = ((ulong)(16u << UDF_LOGICAL_SECTOR_SHIFT));
}

public enum UDF_VOLUME_DESCRIPTOR_ID
{
  UdfPrimaryVolumeDescriptor = 1,
  UdfAnchorVolumeDescriptorPointer = 2,
  UdfVolumeDescriptorPointer = 3,
  UdfImplemenationUseVolumeDescriptor = 4,
  UdfPartitionDescriptor = 5,
  UdfLogicalVolumeDescriptor = 6,
  UdfUnallocatedSpaceDescriptor = 7,
  UdfTerminatingDescriptor = 8,
  UdfLogicalVolumeIntegrityDescriptor = 9,
  UdfFileSetDescriptor = 256,
  UdfFileIdentifierDescriptor = 257,
  UdfAllocationExtentDescriptor = 258,
  UdfFileEntry = 261,
  UdfExtendedFileEntry = 266,
}

// #pragma pack(1)

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_DESCRIPTOR_TAG
{
  public ushort TagIdentifier;
  public ushort DescriptorVersion;
  public byte TagChecksum;
  public byte Reserved;
  public ushort TagSerialNumber;
  public ushort DescriptorCRC;
  public ushort DescriptorCRCLength;
  public uint TagLocation;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_EXTENT_AD
{
  public uint ExtentLength;
  public uint ExtentLocation;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_CHAR_SPEC
{
  public byte CharacterSetType;
  public fixed byte CharacterSetInfo[63];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Domain
{
  public byte Flags;
  public fixed byte Identifier[23];
  union {
    //
    // Domain Entity Identifier
    //
    struct {
      public ushort UdfRevision;
  public byte DomainFlags;
  public fixed byte Reserved[5];
}
//
// UDF Entity Identifier
//
struct {
      ushort UdfRevision;
byte OSClass;
byte OSIdentifier;
byte Reserved[4];
    } Entity;
//
// Implementation Entity Identifier
//
struct {
      byte OSClass;
byte OSIdentifier;
byte ImplementationUseArea[6];
    } ImplementationEntity;
//
// Application Entity Identifier
//
struct {
      byte ApplicationUseArea[8];
    } ApplicationEntity;
//
// Raw Identifier Suffix
//
struct {
      byte Data[8];
    } Raw;
  } Suffix;
} UDF_ENTITY_ID;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_LB_ADDR
{
  public uint LogicalBlockNumber;
  public ushort PartitionReferenceNumber;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_LONG_ALLOCATION_DESCRIPTOR
{
  public uint ExtentLength;
  public UDF_LB_ADDR ExtentLocation;
  public fixed byte ImplementationUse[6];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_ANCHOR_VOLUME_DESCRIPTOR_POINTER
{
  public UDF_DESCRIPTOR_TAG DescriptorTag;
  public UDF_EXTENT_AD MainVolumeDescriptorSequenceExtent;
  public UDF_EXTENT_AD ReserveVolumeDescriptorSequenceExtent;
  public fixed byte Reserved[480];
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct UDF_LOGICAL_VOLUME_DESCRIPTOR
{
  public UDF_DESCRIPTOR_TAG DescriptorTag;
  public uint VolumeDescriptorSequenceNumber;
  public UDF_CHAR_SPEC DescriptorCharacterSet;
  public fixed byte LogicalVolumeIdentifier[128];
  public uint LogicalBlockSize;
  public UDF_ENTITY_ID DomainIdentifier;
  public UDF_LONG_ALLOCATION_DESCRIPTOR LogicalVolumeContentsUse;
  public uint MapTableLength;
  public uint NumberOfPartitionMaps;
  public UDF_ENTITY_ID ImplementationIdentifier;
  public fixed byte ImplementationUse[128];
  public UDF_EXTENT_AD IntegritySequenceExtent;
  public fixed byte PartitionMaps[6];
}

// #pragma pack()

// #endif
