using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  IPMI Platform Management FRU Information Storage Definitions

  This file contains the definitions for:
    Common Header Format (Chapter 8)
    MultiRecord Header (Section 16.1)

  Copyright (c) 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
    - IPMI Platform Management FRU Information Storage Definition v1.0 Revision
      1.3, Dated March 24, 2015.
      https://www.intel.com/content/dam/www/public/us/en/documents/specification-updates/ipmi-platform-mgt-fru-info-storage-def-v1-0-rev-1-3-spec-update.pdf
**/

// #ifndef _IPMI_FRU_INFORMATION_STORAGE_H_
// #define _IPMI_FRU_INFORMATION_STORAGE_H_

// #pragma pack(1)

//
//  Structure definitions for FRU Common Header
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_FRU_COMMON_HEADER_FORMAT_VERSION
{
  ///
  /// Individual bit fields
  ///
  /*   struct { */
  [FieldOffset(0)] public byte FormatVersionNumber = 4;
  [FieldOffset(0)] public byte Reserved = 4;
  /*   } Bits; */
  ///
  /// All bit fields as a 8-bit value
  ///
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_FRU_COMMON_HEADER
{
  public IPMI_FRU_COMMON_HEADER_FORMAT_VERSION FormatVersion;
  public byte InternalUseStartingOffset;
  public byte ChassisInfoStartingOffset;
  public byte BoardAreaStartingOffset;
  public byte ProductInfoStartingOffset;
  public byte MultiRecInfoStartingOffset;
  public byte Pad;
  public byte Checksum;
}

//
//  Structure definition for FRU MultiRecord Header
//
[StructLayout(LayoutKind.Explicit)]
public unsafe struct IPMI_FRU_MULTI_RECORD_HEADER_FORMAT_VERSION
{
  ///
  /// Individual bit fields
  ///
  /*   struct { */
  [FieldOffset(0)] public byte RecordFormatVersion = 4;
  [FieldOffset(0)] public byte Reserved = 3;
  [FieldOffset(0)] public byte EndofList = 1;
  /*   } Bits; */
  ///
  /// All bit fields as a 8-bit value
  ///
  [FieldOffset(0)] public byte Uint8;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_FRU_MULTI_RECORD_HEADER
{
  public byte RecordTypeId;
  public IPMI_FRU_MULTI_RECORD_HEADER_FORMAT_VERSION FormatVersion;
  public byte RecordLength;
  public byte RecordChecksum;
  public byte HeaderChecksum;
}

//
//  Structure definition for System UUID Subrecord with checksum.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct IPMI_SYSTEM_UUID_SUB_RECORD_WITH_CHECKSUM
{
  public byte RecordCheckSum;
  public byte SubRecordId;
  public EFI_GUID Uuid;
}

// #pragma pack()
// #endif
