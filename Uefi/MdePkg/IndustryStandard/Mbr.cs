using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Legacy Master Boot Record Format Definition.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef _MBR_H_
// #define _MBR_H_

public const ulong MBR_SIGNATURE = 0xaa55;

public const ulong EXTENDED_DOS_PARTITION = 0x05;
public const ulong EXTENDED_WINDOWS_PARTITION = 0x0F;

public const ulong MAX_MBR_PARTITIONS = 4;

public const ulong PMBR_GPT_PARTITION = 0xEE;
public const ulong EFI_PARTITION = 0xEF;

public const ulong MBR_SIZE = 512;

// #pragma pack(1)
///
/// MBR Partition Entry
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MBR_PARTITION_RECORD
{
  public byte BootIndicator;
  public byte StartHead;
  public byte StartSector;
  public byte StartTrack;
  public byte OSIndicator;
  public byte EndHead;
  public byte EndSector;
  public byte EndTrack;
  public fixed byte StartingLBA[4];
  public fixed byte SizeInLBA[4];
}

///
/// MBR Partition Table
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct MASTER_BOOT_RECORD
{
  public fixed byte BootStrapCode[440];
  public fixed byte UniqueMbrSignature[4];
  public fixed byte Unknown[2];
  public fixed MBR_PARTITION_RECORD Partition[MAX_MBR_PARTITIONS];
  public ushort Signature;
}

// #pragma pack()

// #endif
