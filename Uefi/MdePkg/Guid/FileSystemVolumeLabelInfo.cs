using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Provides a GUID and a data structure that can be used with EFI_FILE_PROTOCOL.GetInfo()
  or EFI_FILE_PROTOCOL.SetInfo() to get or set the system's volume label.
  This GUID is defined in UEFI specification.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __FILE_SYSTEM_VOLUME_LABEL_INFO_H__
// #define __FILE_SYSTEM_VOLUME_LABEL_INFO_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_FILE_SYSTEM_VOLUME_LABEL_ID => new GUID(0xDB47D7D3, 0xFE81, 0x11d3, 0x9A, 0x35, 0x00, 0x90, 0x27, 0x3F, 0xC1, 0x4D);
}

[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_FILE_SYSTEM_VOLUME_LABEL
{
  ///
  /// The Null-terminated string that is the volume's label.
  ///
  public fixed char VolumeLabel[1];
}

//#define SIZE_OF_EFI_FILE_SYSTEM_VOLUME_LABEL \
//OFFSET_OF(EFI_FILE_SYSTEM_VOLUME_LABEL, VolumeLabel)

// extern EFI_GUID  gEfiFileSystemVolumeLabelInfoIdGuid;

// #endif
