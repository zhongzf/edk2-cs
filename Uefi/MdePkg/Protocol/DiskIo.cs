using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Disk IO protocol as defined in the UEFI 2.0 specification.

  The Disk IO protocol is used to convert block oriented devices into byte
  oriented devices. The Disk IO protocol is intended to layer on top of the
  Block IO protocol.

  Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
  SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __DISK_IO_H__
// #define __DISK_IO_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_DISK_IO_PROTOCOL_GUID => new GUID(
      0xce345171, 0xba0b, 0x11d2, 0x8e, 0x4f, 0x0, 0xa0, 0xc9, 0x69, 0x72, 0x3b);

  ///
  /// Protocol GUID name defined in EFI1.1.
  ///
  public static EFI_GUID DISK_IO_PROTOCOL = EFI_DISK_IO_PROTOCOL_GUID;

  // typedef struct _EFI_DISK_IO_PROTOCOL EFI_DISK_IO_PROTOCOL;
}

///
/// Protocol defined in EFI1.1.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DISK_IO { EFI_DISK_IO_PROTOCOL Value; public static implicit operator EFI_DISK_IO(EFI_DISK_IO_PROTOCOL value) => new EFI_DISK_IO() { Value = value }; public static implicit operator EFI_DISK_IO_PROTOCOL(EFI_DISK_IO value) => value.Value; }

// /**
//   Read BufferSize bytes from Offset into Buffer.
// 
//   @param  This                  Protocol instance pointer.
//   @param  MediaId               Id of the media, changes every time the media is replaced.
//   @param  Offset                The starting byte offset to read from
//   @param  BufferSize            Size of Buffer
//   @param  Buffer                Buffer containing read data
// 
//   @retval EFI_SUCCESS           The data was read correctly from the device.
//   @retval EFI_DEVICE_ERROR      The device reported an error while performing the read.
//   @retval EFI_NO_MEDIA          There is no media in the device.
//   @retval EFI_MEDIA_CHNAGED     The MediaId does not matched the current device.
//   @retval EFI_INVALID_PARAMETER The read request contains device addresses that are not
//                                 valid for the device.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_DISK_READ)(
//   IN EFI_DISK_IO_PROTOCOL         *This,
//   IN uint                       MediaId,
//   IN ulong                       Offset,
//   IN ulong                        BufferSize,
//   OUT void                        *Buffer
//   );

// /**
//   Writes a specified number of bytes to a device.
// 
//   @param  This       Indicates a pointer to the calling context.
//   @param  MediaId    ID of the medium to be written.
//   @param  Offset     The starting byte offset on the logical block I/O device to write.
//   @param  BufferSize The size in bytes of Buffer. The number of bytes to write to the device.
//   @param  Buffer     A pointer to the buffer containing the data to be written.
// 
//   @retval EFI_SUCCESS           The data was written correctly to the device.
//   @retval EFI_WRITE_PROTECTED   The device can not be written to.
//   @retval EFI_DEVICE_ERROR      The device reported an error while performing the write.
//   @retval EFI_NO_MEDIA          There is no media in the device.
//   @retval EFI_MEDIA_CHNAGED     The MediaId does not matched the current device.
//   @retval EFI_INVALID_PARAMETER The write request contains device addresses that are not
//                                  valid for the device.
// 
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_DISK_WRITE)(
//   IN EFI_DISK_IO_PROTOCOL         *This,
//   IN uint                       MediaId,
//   IN ulong                       Offset,
//   IN ulong                        BufferSize,
//   IN void                         *Buffer
//   );

public unsafe partial class EFI
{
  public const ulong EFI_DISK_IO_PROTOCOL_REVISION = 0x00010000;

  ///
  /// Revision defined in EFI1.1
  ///
  public const ulong EFI_DISK_IO_INTERFACE_REVISION = EFI_DISK_IO_PROTOCOL_REVISION;
}

///
/// This protocol is used to abstract Block I/O interfaces.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_DISK_IO_PROTOCOL
{
  ///
  /// The revision to which the disk I/O interface adheres. All future
  /// revisions must be backwards compatible. If a future version is not
  /// backwards compatible, it is not the same GUID.
  ///
  public ulong Revision;
  public readonly delegate* unmanaged</* IN */EFI_DISK_IO_PROTOCOL* /*This*/,/* IN */uint /*MediaId*/,/* IN */ulong /*Offset*/,/* IN */ulong /*BufferSize*/,/* OUT */void* /*Buffer*/, EFI_STATUS> /*EFI_DISK_READ*/ ReadDisk;
  public readonly delegate* unmanaged</* IN */EFI_DISK_IO_PROTOCOL* /*This*/,/* IN */uint /*MediaId*/,/* IN */ulong /*Offset*/,/* IN */ulong /*BufferSize*/,/* IN */void* /*Buffer*/, EFI_STATUS> /*EFI_DISK_WRITE*/ WriteDisk;
}

// extern EFI_GUID  gEfiDiskIoProtocolGuid;

// #endif
