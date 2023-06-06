using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  This file provides location and format of a firmware volume.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This PPI is introduced in PI Version 1.0.

**/

// #ifndef __EFI_PEI_FIRMWARE_VOLUME_INFO_H__
// #define __EFI_PEI_FIRMWARE_VOLUME_INFO_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_PEI_FIRMWARE_VOLUME_INFO_PPI_GUID => new GUID(0x49edb1c1, 0xbf21, 0x4761, 0xbb, 0x12, 0xeb, 0x0, 0x31, 0xaa, 0xbb, 0x39);

  // typedef struct _EFI_PEI_FIRMWARE_VOLUME_INFO_PPI EFI_PEI_FIRMWARE_VOLUME_INFO_PPI;
}

///
///  This PPI describes the location and format of a firmware volume.
///  The FvFormat can be EFI_FIRMWARE_FILE_SYSTEM2_GUID or the GUID for
///  a user-defined format. The  EFI_FIRMWARE_FILE_SYSTEM2_GUID is
///  the PI Firmware Volume format.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_FIRMWARE_VOLUME_INFO_PPI
{
  ///
  /// Unique identifier of the format of the memory-mapped firmware volume.
  ///
  public EFI_GUID FvFormat;
  ///
  /// Points to a buffer which allows the EFI_PEI_FIRMWARE_VOLUME_PPI to process
  /// the volume. The format of this buffer is specific to the FvFormat.
  /// For memory-mapped firmware volumes, this typically points to the first byte
  /// of the firmware volume.
  ///
  public void* FvInfo;
  ///
  /// Size of the data provided by FvInfo. For memory-mapped firmware volumes,
  /// this is typically the size of the firmware volume.
  ///
  public uint FvInfoSize;
  ///
  /// If the firmware volume originally came from a firmware file, then these
  /// point to the parent firmware volume name and firmware volume file.
  /// If it did not originally come from a firmware file, these should be NULL.
  ///
  public EFI_GUID* ParentFvName;
  ///
  /// If the firmware volume originally came from a firmware file, then these
  /// point to the parent firmware volume name and firmware volume file.
  /// If it did not originally come from a firmware file, these should be NULL.
  ///
  public EFI_GUID* ParentFileName;
}

// extern EFI_GUID  gEfiPeiFirmwareVolumeInfoPpiGuid;

// #endif
