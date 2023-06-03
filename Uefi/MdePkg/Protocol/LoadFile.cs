using System.Runtime.InteropServices;

namespace Uefi;
/** @file
  Load File protocol as defined in the UEFI 2.0 specification.

  The load file protocol exists to supports the addition of new boot devices,
  and to support booting from devices that do not map well to file system.
  Network boot is done via a LoadFile protocol.

  UEFI 2.0 can boot from any device that produces a LoadFile protocol.

Copyright (c) 2006 - 2018, Intel Corporation. All rights reserved.<BR>
SPDX-License-Identifier: BSD-2-Clause-Patent

**/

// #ifndef __EFI_LOAD_FILE_PROTOCOL_H__
// #define __EFI_LOAD_FILE_PROTOCOL_H__

public unsafe partial class EFI
{
  public static EFI_GUID EFI_LOAD_FILE_PROTOCOL_GUID = new GUID(
      0x56EC3091, 0x954C, 0x11d2, new byte[] { 0x8E, 0x3F, 0x00, 0xA0, 0xC9, 0x69, 0x72, 0x3B });

  ///
  /// Protocol Guid defined by EFI1.1.
  ///
  public const ulong LOAD_FILE_PROTOCOL = EFI_LOAD_FILE_PROTOCOL_GUID;

  // typedef struct _EFI_LOAD_FILE_PROTOCOL EFI_LOAD_FILE_PROTOCOL;
}

///
/// Backward-compatible with EFI1.1
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LOAD_FILE_INTERFACE { EFI_LOAD_FILE_PROTOCOL Value; public static implicit operator EFI_LOAD_FILE_INTERFACE(EFI_LOAD_FILE_PROTOCOL value) => new EFI_LOAD_FILE_INTERFACE() { Value = value }; public static implicit operator EFI_LOAD_FILE_PROTOCOL(EFI_LOAD_FILE_INTERFACE value) => value.Value; }

// /**
//   Causes the driver to load a specified file.
// 
//   @param  This       Protocol instance pointer.
//   @param  FilePath   The device specific path of the file to load.
//   @param  BootPolicy If TRUE, indicates that the request originates from the
//                      boot manager is attempting to load FilePath as a boot
//                      selection. If FALSE, then FilePath must match as exact file
//                      to be loaded.
//   @param  BufferSize On input the size of Buffer in bytes. On output with a return
//                      code of EFI_SUCCESS, the amount of data transferred to
//                      Buffer. On output with a return code of EFI_BUFFER_TOO_SMALL,
//                      the size of Buffer required to retrieve the requested file.
//   @param  Buffer     The memory buffer to transfer the file to. IF Buffer is NULL,
//                      then the size of the requested file is returned in
//                      BufferSize.
// 
//   @retval EFI_SUCCESS           The file was loaded.
//   @retval EFI_UNSUPPORTED       The device does not support the provided BootPolicy
//   @retval EFI_INVALID_PARAMETER FilePath is not a valid device path, or
//                                 BufferSize is NULL.
//   @retval EFI_NO_MEDIA          No medium was present to load the file.
//   @retval EFI_DEVICE_ERROR      The file was not loaded due to a device error.
//   @retval EFI_NO_RESPONSE       The remote system did not respond.
//   @retval EFI_NOT_FOUND         The file was not found.
//   @retval EFI_ABORTED           The file load process was manually cancelled.
//   @retval EFI_WARN_FILE_SYSTEM  The resulting Buffer contains UEFI-compliant file system.
// **/
// typedef
// EFI_STATUS
// (EFIAPI *EFI_LOAD_FILE)(
//   IN EFI_LOAD_FILE_PROTOCOL           *This,
//   IN EFI_DEVICE_PATH_PROTOCOL         *FilePath,
//   IN bool                          BootPolicy,
//   IN OUT ulong                        *BufferSize,
//   IN void                             *Buffer OPTIONAL
//   );

///
/// The EFI_LOAD_FILE_PROTOCOL is a simple protocol used to obtain files from arbitrary devices.
///
[StructLayout(LayoutKind.Sequential)]
public unsafe struct EFI_LOAD_FILE_PROTOCOL
{
  public readonly delegate* unmanaged</* IN */EFI_LOAD_FILE_PROTOCOL* /*This*/,/* IN */EFI_DEVICE_PATH_PROTOCOL* /*FilePath*/,/* IN */bool /*BootPolicy*/,/* IN OUT */ulong* /*BufferSize*/,/* IN */void* /*Buffer*/, EFI_STATUS> /*EFI_LOAD_FILE*/ LoadFile;
}

// extern EFI_GUID  gEfiLoadFileProtocolGuid;

// #endif
