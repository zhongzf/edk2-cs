namespace Uefi;
/** @file
  UEFI 2.0 Loaded image protocol definition.

  Every EFI driver and application is passed an image handle when it is loaded.
  This image handle will contain a Loaded Image Protocol.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __LOADED_IMAGE_PROTOCOL_H__
// #define __LOADED_IMAGE_PROTOCOL_H__

public static EFI_GUID EFI_LOADED_IMAGE_PROTOCOL_GUID = new GUID(
    0x5B1B31A1, 0x9562, 0x11d2, new byte[] { 0x8E, 0x3F, 0x00, 0xA0, 0xC9, 0x69, 0x72, 0x3B });

public static EFI_GUID EFI_LOADED_IMAGE_DEVICE_PATH_PROTOCOL_GUID = new GUID(
    0xbc62157e, 0x3e33, 0x4fec, new byte[] { 0x99, 0x20, 0x2d, 0x3b, 0x36, 0xd7, 0x50, 0xdf });

///
/// Protocol GUID defined in EFI1.1.
///
public const ulong LOADED_IMAGE_PROTOCOL = EFI_LOADED_IMAGE_PROTOCOL_GUID;

///
/// EFI_SYSTEM_TABLE & EFI_IMAGE_UNLOAD are defined in EfiApi.h
///
public const ulong EFI_LOADED_IMAGE_PROTOCOL_REVISION = 0x1000;

///
/// Revision defined in EFI1.1.
///
public const ulong EFI_LOADED_IMAGE_INFORMATION_REVISION = EFI_LOADED_IMAGE_PROTOCOL_REVISION;

///
/// Can be used on any image handle to obtain information about the loaded image.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LOADED_IMAGE_PROTOCOL
{
  public uint Revision;     ///< Defines the revision of the EFI_LOADED_IMAGE_PROTOCOL structure.
                            ///< All future revisions will be backward compatible to the current revision.
  public EFI_HANDLE ParentHandle; ///< Parent image's image handle. NULL if the image is loaded directly from
                                  ///< the firmware's boot manager.
  public EFI_SYSTEM_TABLE* SystemTable; ///< the image's EFI system table pointer.

  //
  // Source location of image
  //
  public EFI_HANDLE DeviceHandle; ///< The device handle that the EFI Image was loaded from.
  public EFI_DEVICE_PATH_PROTOCOL* FilePath;    ///< A pointer to the file path portion specific to DeviceHandle
                                                ///< that the EFI Image was loaded from.
  public void* Reserved;    ///< Reserved. DO NOT USE.

  //
  // Images load options
  //
  public uint LoadOptionsSize; ///< The size in bytes of LoadOptions.
  public void* LoadOptions;    ///< A pointer to the image's binary load options.

  //
  // Location of where image was loaded
  //
  public void* ImageBase;    ///< The base address at which the image was loaded.
  public ulong ImageSize;     ///< The size in bytes of the loaded image.
  public EFI_MEMORY_TYPE ImageCodeType; ///< The memory type that the code sections were loaded as.
  public EFI_MEMORY_TYPE ImageDataType; ///< The memory type that the data sections were loaded as.
  public EFI_IMAGE_UNLOAD Unload;
}

//
// For backward-compatible with EFI1.1.
//
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LOADED_IMAGE { EFI_LOADED_IMAGE_PROTOCOL Value; public static implicit operator EFI_LOADED_IMAGE(EFI_LOADED_IMAGE_PROTOCOL value) => new EFI_LOADED_IMAGE() { Value = value }; public static implicit operator EFI_LOADED_IMAGE_PROTOCOL(EFI_LOADED_IMAGE value) => value.Value; }

// extern EFI_GUID  gEfiLoadedImageProtocolGuid;
// extern EFI_GUID  gEfiLoadedImageDevicePathProtocolGuid;

// #endif
