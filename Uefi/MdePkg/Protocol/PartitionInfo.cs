using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file defines the EFI Partition Information Protocol.

  Copyright (c) 2017, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This Protocol is introduced in UEFI Specification 2.7

**/

// #ifndef __PARTITION_INFO_PROTOCOL_H__
// #define __PARTITION_INFO_PROTOCOL_H__

// #include <IndustryStandard/Mbr.h>
// #include <Uefi/UefiGpt.h>

public unsafe partial class EFI
{
  //
  // EFI Partition Information Protocol GUID value
  //
  public static EFI_GUID EFI_PARTITION_INFO_PROTOCOL_GUID => new GUID(0x8cf2f62c, 0xbc9b, 0x4821, 0x80, 0x8d, 0xec, 0x9e, 0xc4, 0x21, 0xa1, 0xa0);

  public const ulong EFI_PARTITION_INFO_PROTOCOL_REVISION = 0x0001000;
  public const ulong PARTITION_TYPE_OTHER = 0x00;
  public const ulong PARTITION_TYPE_MBR = 0x01;
  public const ulong PARTITION_TYPE_GPT = 0x02;

  // #pragma pack(1)
}

///
/// Partition Information Protocol structure.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PARTITION_INFO_PROTOCOL
{
  //
  // Set to EFI_PARTITION_INFO_PROTOCOL_REVISION.
  //
  public uint Revision;
  //
  // Partition info type (PARTITION_TYPE_MBR, PARTITION_TYPE_GPT, or PARTITION_TYPE_OTHER).
  //
  public uint Type;
  //
  // If 1, partition describes an EFI System Partition.
  //
  public byte System;
  public fixed byte Reserved[7];
  //union {
  ///
  /// MBR data
  ///
  public MBR_PARTITION_RECORD Mbr;
  //  ///
  //  /// GPT data
  //  ///
  //  public EFI_PARTITION_ENTRY Gpt;
  //}
}

// #pragma pack()

///
/// Partition Information Protocol GUID variable.
///
// extern EFI_GUID  gEfiPartitionInfoProtocolGuid;

// #endif
