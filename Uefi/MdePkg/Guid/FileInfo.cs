using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Provides a GUID and a data structure that can be used with EFI_FILE_PROTOCOL.SetInfo()
  and EFI_FILE_PROTOCOL.GetInfo() to set or get generic file information.
  This GUID is defined in UEFI specification.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __FILE_INFO_H__
// #define __FILE_INFO_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_FILE_INFO_ID => new GUID(0x9576e92, 0x6d3f, 0x11d2, 0x8e, 0x39, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE_INFO
{
  ///
  /// The size of the EFI_FILE_INFO structure, including the Null-terminated FileName string.
  ///
  public ulong Size;
  ///
  /// The size of the file in bytes.
  ///
  public ulong FileSize;
  ///
  /// PhysicalSize The amount of physical space the file consumes on the file system volume.
  ///
  public ulong PhysicalSize;
  ///
  /// The time the file was created.
  ///
  public EFI_TIME CreateTime;
  ///
  /// The time when the file was last accessed.
  ///
  public EFI_TIME LastAccessTime;
  ///
  /// The time when the file's contents were last modified.
  ///
  public EFI_TIME ModificationTime;
  ///
  /// The attribute bits for the file.
  ///
  public ulong Attribute;
  ///
  /// The Null-terminated name of the file.
  ///
  public fixed char FileName[1];
}

public unsafe partial class EFI
{
  ///
  /// The FileName field of the EFI_FILE_INFO data structure is variable length.
  /// Whenever code needs to know the size of the EFI_FILE_INFO data structure, it needs to
  /// be the size of the data structure without the FileName field.  The following macro
  /// computes this size correctly no matter how big the FileName array is declared.
  /// This is required to make the EFI_FILE_INFO data structure ANSI compilant.
  ///
  //public const ulong SIZE_OF_EFI_FILE_INFO = OFFSET_OF(EFI_FILE_INFO, FileName);

  // extern EFI_GUID  gEfiFileInfoGuid;
}

// #endif
