using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  GUID and related data structures used with the Debug Image Info Table.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  GUID defined in UEFI 2.0 spec.

**/

// #ifndef __DEBUG_IMAGE_INFO_GUID_H__
// #define __DEBUG_IMAGE_INFO_GUID_H__

// #include <Protocol/LoadedImage.h>

public unsafe partial class EFI
{
  ///
  /// EFI_DEBUG_IMAGE_INFO_TABLE configuration table GUID declaration.
  ///
  public static EFI_GUID EFI_DEBUG_IMAGE_INFO_TABLE_GUID => new GUID(
      0x49152e77, 0x1ada, 0x4764, 0xb7, 0xa2, 0x7a, 0xfe, 0xfe, 0xd9, 0x5e, 0x8b);

  public const ulong EFI_DEBUG_IMAGE_INFO_UPDATE_IN_PROGRESS = 0x01;
  public const ulong EFI_DEBUG_IMAGE_INFO_TABLE_MODIFIED = 0x02;

  public const ulong EFI_DEBUG_IMAGE_INFO_TYPE_NORMAL = 0x01;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_SYSTEM_TABLE_POINTER
{
  public ulong Signature;          ///< A constant ulong that has the value EFI_SYSTEM_TABLE_SIGNATURE
  public EFI_PHYSICAL_ADDRESS EfiSystemTableBase; ///< The physical address of the EFI system table.
  public uint Crc32;              ///< A 32-bit CRC value that is used to verify the EFI_SYSTEM_TABLE_POINTER structure is valid.
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEBUG_IMAGE_INFO_NORMAL
{
  ///
  /// Indicates the type of image info structure. For PE32 EFI images,
  /// this is set to EFI_DEBUG_IMAGE_INFO_TYPE_NORMAL.
  ///
  public uint ImageInfoType;
  ///
  /// A pointer to an instance of the loaded image protocol for the associated image.
  ///
  public EFI_LOADED_IMAGE_PROTOCOL* LoadedImageProtocolInstance;
  ///
  /// Indicates the image handle of the associated image.
  ///
  public EFI_HANDLE ImageHandle;
}

[StructLayout(LayoutKind.Explicit)]
public unsafe struct EFI_DEBUG_IMAGE_INFO
{
  [FieldOffset(0)] public uint* ImageInfoType;
  [FieldOffset(0)] public EFI_DEBUG_IMAGE_INFO_NORMAL* NormalImage;
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DEBUG_IMAGE_INFO_TABLE_HEADER
{
  ///
  /// UpdateStatus is used by the system to indicate the state of the debug image info table.
  ///
  public volatile uint UpdateStatus;
  ///
  /// The number of EFI_DEBUG_IMAGE_INFO elements in the array pointed to by EfiDebugImageInfoTable.
  ///
  public uint TableSize;
  ///
  /// A pointer to the first element of an array of EFI_DEBUG_IMAGE_INFO structures.
  ///
  public EFI_DEBUG_IMAGE_INFO* EfiDebugImageInfoTable;
}

// extern EFI_GUID  gEfiDebugImageInfoTableGuid;

// #endif
