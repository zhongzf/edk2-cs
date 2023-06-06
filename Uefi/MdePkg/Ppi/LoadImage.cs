using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  The file describes the PPI which notifies other drivers
  of the PEIM being initialized by the PEI Dispatcher.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

  @par Revision Reference:
  This PPI is introduced in PI Version 1.0.

**/

// #ifndef __LOADED_IMAGE_PPI_H__
// #define __LOADED_IMAGE_PPI_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_PEI_LOADED_IMAGE_PPI_GUID => new GUID(0xc1fcd448, 0x6300, 0x4458, 0xb8, 0x64, 0x28, 0xdf, 0x1, 0x53, 0x64, 0xbc);

  // typedef struct _EFI_PEI_LOADED_IMAGE_PPI EFI_PEI_LOADED_IMAGE_PPI;
}

///
/// This interface is installed by the PEI Dispatcher after the image has been
/// loaded and after all security checks have been performed,
/// to notify other PEIMs of the files which are being loaded.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_PEI_LOADED_IMAGE_PPI
{
  ///
  /// Address of the image at the address where it will be executed.
  ///
  public EFI_PHYSICAL_ADDRESS ImageAddress;
  ///
  /// Size of the image as it will be executed.
  ///
  public ulong ImageSize;
  ///
  /// File handle from which the image was loaded.
  /// Can be NULL, indicating the image was not loaded from a handle.
  ///
  public EFI_PEI_FILE_HANDLE FileHandle;
}

// extern EFI_GUID  gEfiPeiLoadedImagePpiGuid;

// #endif
